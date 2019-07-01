import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RootComponent } from './root/root.component';
import { AuthGuard } from '../auth.guard';
import { AuthGuardService } from '../core/auth.guard.service';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
    path: 'mycountries', /*canActivate: [AuthGuardService],*/ component: RootComponent,
 
        children: [

        ]
    }
]);

