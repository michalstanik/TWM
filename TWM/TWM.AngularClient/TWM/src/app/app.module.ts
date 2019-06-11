import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Components
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { SigninOidcComponent } from './signin-oidc/signin-oidc.component';

import { routing } from "./app.routing";

import { OpenIdConnectService } from './shared/services/open-id-connect.service';
import { RequireAuthenticatedUserRouteGuardService } from './shared/services/require-authentication-user-route-guard.service';

import { MDBBootstrapModulesPro, MDBSpinningPreloader } from 'ng-uikit-pro-standard';





@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    SigninOidcComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MDBBootstrapModulesPro.forRoot(),
    routing

  ],
  providers: [MDBSpinningPreloader, OpenIdConnectService, RequireAuthenticatedUserRouteGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
