import React from 'react';
import { Route, Switch } from 'react-router-dom';
import HomePage from './HomePage';
import LoginPage from './User/LoginPage';
import RegisterPage from './User/RegisterPage';

const Content = () => (
    <Switch>
        <Route exact path="/" component={HomePage} />
        <Route path="/user/login" component={LoginPage} />
        <Route path="/user/register" component={RegisterPage} />
    </Switch>
);

export default Content;