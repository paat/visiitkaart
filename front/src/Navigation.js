import React from "react";
import { Navbar, NavbarBrand, NavbarNav, NavItem, NavLink } from 'mdbreact';
import LoginNav from './User/LoginNav';
import PropTypes from "prop-types";

const Navigation = (props) => (
    <Navbar color="default-color" dark expand="md" scrolling>
        <NavbarBrand href="/">
            <strong>visiitkaart.ee</strong>
        </NavbarBrand>
        <NavbarNav left>
            <NavItem active>
                <NavLink to="#">Home</NavLink>
            </NavItem>
            <NavItem>
                <NavLink to="#">Features</NavLink>
            </NavItem>
            <NavItem>
                <NavLink to="#">Pricing</NavLink>
            </NavItem>
            <NavItem>
                <NavLink to="#">Options</NavLink>
            </NavItem>
        </NavbarNav>
        <NavbarNav right>
            <LoginNav isAuthenticated={props.isAuthenticated} />
        </NavbarNav>
    </Navbar>
);

Navigation.propTypes = {
    isAuthenticated: PropTypes.bool.isRequired,
}

export default Navigation;
