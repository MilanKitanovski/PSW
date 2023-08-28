import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewInternalDataPatientComponent } from './view-internal-data-patient.component';

describe('ViewInternalDataPatientComponent', () => {
  let component: ViewInternalDataPatientComponent;
  let fixture: ComponentFixture<ViewInternalDataPatientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewInternalDataPatientComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewInternalDataPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
