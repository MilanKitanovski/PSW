import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialistScheduleComponent } from './specialist-schedule.component';

describe('SpecialistScheduleComponent', () => {
  let component: SpecialistScheduleComponent;
  let fixture: ComponentFixture<SpecialistScheduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpecialistScheduleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SpecialistScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
