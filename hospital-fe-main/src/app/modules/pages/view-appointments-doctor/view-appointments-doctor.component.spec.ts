import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAppointmentsDoctorComponent } from './view-appointments-doctor.component';

describe('ViewAppointmentsDoctorComponent', () => {
  let component: ViewAppointmentsDoctorComponent;
  let fixture: ComponentFixture<ViewAppointmentsDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAppointmentsDoctorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewAppointmentsDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
