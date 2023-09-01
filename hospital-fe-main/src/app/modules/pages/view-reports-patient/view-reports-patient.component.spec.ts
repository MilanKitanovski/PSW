import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewReportsPatientComponent } from './view-reports-patient.component';

describe('ViewReportsPatientComponent', () => {
  let component: ViewReportsPatientComponent;
  let fixture: ComponentFixture<ViewReportsPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewReportsPatientComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewReportsPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
