using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VisiitkaartBackend.Data.Models;
using VisiitkaartBackend.Data.Models.Enums;
using VisiitkaartBackend.Services.Interfaces;
using VisiitkaartBackend.Services.Repositories.Interfaces;

namespace VisiitkaartBackend.Services
{
    public class CustomSignInService : ICustomSignInService
    {
        IUserRepository _userRepository;
        IConfiguration _configuration;

        public CustomSignInService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public User RegisterNewUser(string email, string password, List<UserRoleEnum> roles)
        {
            User user = CreateUserEntity(email, password, roles);
            _userRepository.Add(user);

            return user;
        }

        public static User CreateUserEntity(string email, string password, List<UserRoleEnum> roles)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return new User()
            {
                Email = email,
                PasswordHash = GetCompleteHashBase64String(password, salt),
                Roles = roles,
            };
        }

        public string GetJwtToken(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            User user = _userRepository.Get(email);
            if (user == null)
            {
                return null;
            }

            if (!IsPasswordMatching(password, user.PasswordHash))
            {
                return null;
            }

            return BuildJwtToken(user);
        }

        private bool IsPasswordMatching(string password, string passwordHash)
        {
            byte[] completeHash = Convert.FromBase64String(passwordHash);
            byte[] salt = new byte[16];
            Array.Copy(completeHash, 0, salt, 0, 16);

            byte[] calculatedHash = GetPdkdf2Hash(password, salt);

            byte[] storedHash = new byte[20];
            Array.Copy(completeHash, 16, storedHash, 0, 20);

            return calculatedHash.SequenceEqual(storedHash);
        }

        private string BuildJwtToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (UserRoleEnum role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:LifeTimeMinutes"])),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GetCompleteHashBase64String(string password, byte[] salt)
        {
            byte[] hash = GetPdkdf2Hash(password, salt);
            byte[] completeHash = new byte[36];
            Array.Copy(salt, 0, completeHash, 0, 16);
            Array.Copy(hash, 0, completeHash, 16, 20);
            return Convert.ToBase64String(completeHash);
        }

        private static byte[] GetPdkdf2Hash(string password, byte[] salt)
        {
            var pdkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pdkdf2.GetBytes(20);
            return hash;
        }
    }
}
