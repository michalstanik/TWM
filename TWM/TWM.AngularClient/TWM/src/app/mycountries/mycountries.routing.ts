import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RootComponent } from './root/root.component';
import { AuthGuard } from '../auth.guard';

export const routing: ModuleWithProviders = RouterModule.forChild([
  {
        path: 'mycountries',
    component: RootComponent,
    canActivate: [AuthGuard],

        children: [

        ]
    }
]);

