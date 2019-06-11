import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//Commponents
import { HomeComponent } from './home/home.component';
import { SigninOidcComponent } from './signin-oidc/signin-oidc.component';

//Services
import { RequireAuthenticatedUserRouteGuardService } from './shared/services/require-authentication-user-route-guard.service';

const appRoutes: Routes = [
//canActivate: [RequireAuthenticatedUserRouteGuardService]
  { path: '', component: HomeComponent },
  { path: 'signin-oidc', component: SigninOidcComponent}

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes, { useHash: false });
