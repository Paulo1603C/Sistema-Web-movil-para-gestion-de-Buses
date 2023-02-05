import { TestBed } from '@angular/core/testing';

import { FrecuenciabusService } from './frecuenciabus.service';

describe('FrecuenciabusService', () => {
  let service: FrecuenciabusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FrecuenciabusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
