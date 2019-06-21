import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

//Modules
import { MyCountriesModule } from './mycountries/mycountries.module';

//Components
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { SigninOidcComponent } from './signin-oidc/signin-oidc.component';

import { routing } from "./app.routing";

import { OpenIdConnectService } from './shared/services/open-id-connect.service';

import { MDBBootstrapModulesPro, MDBSpinningPreloader } from 'ng-uikit-pro-standard';
import { EnsureAcceptHeaderInterceptor } from './shared/services/ensure-accept-header-interceptor';






@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    SigninOidcComponent
  ],
  imports: [
    MyCountriesModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MDBBootstrapModulesPro.forRoot(),
    routing

  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: EnsureAcceptHeaderInterceptor,
      multi: true
    },
    //{
    //  provide: HTTP_INTERCEPTORS,
    //  useClass: WriteOutJsonInterceptor,
    //  multi: true
    //},
    //{
    //  provide: HTTP_INTERCEPTORS,
    //  useClass: HandleHttpErrorInterceptor,
    //  multi: true,
    //},
    MDBSpinningPreloader, OpenIdConnectService],
  bootstrap: [AppComponent]
})
export class AppModule { }
