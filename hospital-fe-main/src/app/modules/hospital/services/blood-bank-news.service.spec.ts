import { TestBed } from '@angular/core/testing';

import { BloodBankNewsService } from './blood-bank-news.service';

describe('BloodBankNewsService', () => {
  let service: BloodBankNewsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BloodBankNewsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
