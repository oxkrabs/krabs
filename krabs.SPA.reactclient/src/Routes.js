import React from "react";
import axios from 'axios';
import {App} from "./components/App";
import Callback from "./components/Callback";
import {Route} from 'react-router-dom';
import { withRouter } from "react-router";
import {AuthService} from "./services/AuthService";
import {UserManager} from "oidc-client";
import {Unauthorized} from "./pages/Unauthorized";
import Layout from "./components/Layout";
import UserList from "./pages/UserList";

function makeUserManager(
  config,
  umClass
) {
  const UMClass = umClass || UserManager;
  return new UMClass(config);
}
const userManagerConfig = {
  client_id: "spa",
  redirect_uri: "http://localhost:5100/callback",
  response_type: "token id_token",
  scope: "openid profile api1",
  authority: "http://localhost:5000",
  silent_redirect_uri: "http://localhost:5100/silent_renew.html",
  automaticSilentRenew: true,
  filterProtocolClaims: true,
  loadUserInfo: true,
  monitorSession: true
};
const userManager = makeUserManager(userManagerConfig);

class Routes extends React.Component {
  authService;

  constructor(props) {
    super(props);
    this.authService = new AuthService();
    this.state = {
      shouldRender: false,
      loggedIn: false
    }
  }

  render () {

    if (this.props.location.pathname === '/callback') {
      return <Route path="/callback" render={routeProps => (
        <Callback
          onSuccess={user => {
            // `user.state` will reflect the state that was passed in via signinArgs.
            routeProps.history.push('/')
          }}
          userManager={userManager}
        />
      )}/>
    }

    if (!this.state.shouldRender) {
      console.log('Dont render');
      userManager.getUser().then(user => {
        console.log("RENDER");
        if (user && !user.expired) {
          console.log("USER LOGGED IN");

          // Setup the axios headers
          if(user && !user.expired) {
            axios.defaults.headers.common["Authorization"] = 'Bearer ' + user.access_token;
          }

          this.setState({
            shouldRender: true,
            loggedIn: true
          })
        } else {
          console.log("USER NOT LOGGED IN");
          this.setState({
            shouldRender: true,
            loggedIn: false
          })
        }
      });
      return null;
    }

    if (this.state.shouldRender && !this.state.loggedIn) {
      return (
        <div>
          <Route path="/" component={Unauthorized}/>
        </div>
      )
    }

    return (
      <Layout>
        <Route path="/" exact component={App}/>
        <Route path="/user-list" component={UserList} />
      </Layout>
    )
  }
}

export default withRouter(Routes);


