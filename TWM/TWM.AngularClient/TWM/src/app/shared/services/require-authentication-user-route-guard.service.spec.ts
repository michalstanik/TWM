import { TestBed } from '@angular/core/testing';

import { RequireAuthenticatedUserRouteGuardService } from './require-authentication-user-route-guard.service';

describe('RequireAuthenticationUserRouteGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RequireAuthenticatedUserRouteGuardService = TestBed.get(RequireAuthenticatedUserRouteGuardService);
    expect(service).toBeTruthy();
  });
});
