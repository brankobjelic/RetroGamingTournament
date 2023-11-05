import { TestBed } from '@angular/core/testing';

import { GamingEventService } from './gaming-event.service';

describe('GamingEventService', () => {
  let service: GamingEventService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GamingEventService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
