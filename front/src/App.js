
import React, { Component } from 'react';
import 'font-awesome/css/font-awesome.min.css';
import 'bootstrap/dist/css/bootstrap.min.css'; 
import 'mdbreact/dist/css/mdb.css';

import { Container } from 'mdbreact';
import Content from './Content';
import Navigation from "./Navigation";

class App extends Component {

  state = {
    authToken: null,
  }
  

  render() {
    return (
      <div>
        <Navigation isAuthenticated={!!(this.state.authToken)}/>
        <main>
        <Container className="mt-6">
          <Content />
        </Container>
        </main>
      </div>
    );
  }
}
export default App;
