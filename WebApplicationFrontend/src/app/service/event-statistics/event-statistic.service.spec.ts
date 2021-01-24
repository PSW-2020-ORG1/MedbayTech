import { TestBed } from '@angular/core/testing';

import { EventStatisticService } from './event-statistic.service';

describe('EventStatisticService', () => {
  let service: EventStatisticService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventStatisticService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
