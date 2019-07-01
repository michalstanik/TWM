import { NgModule, ModuleWithProviders } from '@angular/core';
import { OpenIdConnectService } from '../services/open-id-connect.service';
import { AuthGuard } from 'src/app/auth.guard';


@NgModule({
  providers: [OpenIdConnectService, AuthGuard]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [OpenIdConnectService, AuthGuard]
    };
  }
}
