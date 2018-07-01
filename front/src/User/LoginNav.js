import React from "react";
import PropTypes from "prop-types";
import { NavbarNav, NavItem, NavLink } from 'mdbreact';

function authenticatedUserMenuItems() {
    return (
        <NavbarNav>
            <NavItem>
                <NavLink to="#">Account</NavLink>
            </NavItem>
            <NavItem>
                <NavLink to="#">Log out</NavLink>
            </NavItem>
        </NavbarNav>
    );
}

function anonymousUserMenuItems() {
    return (
        <NavbarNav>
            <NavItem>
                <NavLink to="/user/login">
                    Login
                </NavLink>
            </NavItem>
            <NavItem>
                <NavLink to="/user/register">Register</NavLink>
            </NavItem>
        </NavbarNav>
    );
}

const LoginNav = (props) => (
    props.isAuthenticated ? authenticatedUserMenuItems() : anonymousUserMenuItems()
);


LoginNav.propTypes = {
    isAuthenticated: PropTypes.bool.isRequired,
}

export default LoginNav;