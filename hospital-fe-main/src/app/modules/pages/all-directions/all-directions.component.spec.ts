import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllDIrectionsComponent } from './all-directions.component';

describe('AllDIrectionsComponent', () => {
  let component: AllDIrectionsComponent;
  let fixture: ComponentFixture<AllDIrectionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllDIrectionsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllDIrectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
