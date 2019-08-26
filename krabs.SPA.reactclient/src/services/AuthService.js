import { Log, UserManager } from 'oidc-client';

import { constants } from '../helpers/constants';

export class AuthService {
  userManager;

  constructor() {
    const settings = {
      authority: constants.stsAuthority,
      client_id: constants.clientId,
      redirect_uri: `${constants.clientRoot}callback`,
      silent_redirect_uri: `${constants.clientRoot}silent-renew.html`,
      // tslint:disable-next-line:object-literal-sort-keys
      post_logout_redirect_uri: `${constants.clientRoot}`,
      response_type: 'token id_token',
      scope: constants.clientScope
    };
    this.userManager = new UserManager(settings);

    Log.logger = console;
    Log.level = Log.INFO;
  }

  getUser() {
    return this.userManager.getUser();
  }

  login() {
    return this.userManager.signinRedirect();
  }

  renewToken() {
    return this.userManager.signinSilent();
  }

  logout() {
    return this.userManager.signoutRedirect();
  }
}
