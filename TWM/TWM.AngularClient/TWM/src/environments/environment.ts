import { WebStorageStateStore } from 'oidc-client';

// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.


export const environment = {
  production: false,
  apiUrl: 'https://localhost:9001/api',
  openIdConnectSettings: {
    authority: 'https://localhost:8001/',
    client_id: 'tripwithmeclient',
    redirect_uri: 'https://localhost:4200/signin-oidc',
    scope: 'openid profile roles',
    response_type: 'id_token',
    post_logout_redirect_uri: 'https://localhost:4200/',
    userStore: new WebStorageStateStore({ store: window.localStorage })
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
