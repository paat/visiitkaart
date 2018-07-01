import React from 'react';
import { Container, Row, Col, Input, Button } from 'mdbreact';

const LoginPage = () => (
  <Container>
    <Row>
      <Col md="6">
        <form>
          <p className="h5 text-center mb-4">Sign in</p>
          <div className="grey-text">
            <Input label="Type your email" icon="envelope" group type="email" validate error="wrong" success="right" />
            <Input label="Type your password" icon="lock" group type="password" validate />
          </div>
          <div className="text-center">
            <Button>Login</Button>
          </div>
        </form>
      </Col>
    </Row>
  </Container>
);


export default LoginPage;
