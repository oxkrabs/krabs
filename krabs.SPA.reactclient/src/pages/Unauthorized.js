import React, { Component } from 'react';
import * as toastr from 'toastr';
import { AuthService } from '../services/AuthService';

export class Unauthorized extends Component {
  authService;
  shouldCancel;

  constructor(props) {
    super(props);
    this.authService = new AuthService();
    this.shouldCancel = false;
    this.state = { user: {}, api: {} };
  };

  login = () => {
    this.authService.login();
  };

  getUser = () => {
    this.authService.getUser().then(user => {
      if (!this.shouldCancel) {
        this.setState({ user });
      }
    });
  };

  renewToken = () => {
    this.authService
      .renewToken()
      .then(user => {
        toastr.success('Token has been sucessfully renewed. :-)');
        this.getUser();
      })
      .catch(error => {
        toastr.error(error);
      });
  };

  componentDidMount() {
    this.getUser();
  }

  componentWillUnmount() {
    this.shouldCancel = true;
  }

  render() {
    return (
      <div>
        <button onClick={() => this.login()}>Login</button>
      </div>
    )
  }
}

