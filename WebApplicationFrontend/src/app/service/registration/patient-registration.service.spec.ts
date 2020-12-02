import { TestBed } from '@angular/core/testing';

import { PatientRegistrationService } from './patient-registration.service';

describe('PatientRegistrationService', () => {
  let service: PatientRegistrationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PatientRegistrationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
