import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BloodBankNewsComponent } from './blood-bank-news.component';

describe('BloodBankNewsComponent', () => {
  let component: BloodBankNewsComponent;
  let fixture: ComponentFixture<BloodBankNewsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BloodBankNewsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BloodBankNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
