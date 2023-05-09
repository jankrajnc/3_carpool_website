import { TestBed } from '@angular/core/testing';

import { CarpoolEntryApi } from './carpool-entry-api';

describe('CarRest', () => {
  let service: CarpoolEntryApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarpoolEntryApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
