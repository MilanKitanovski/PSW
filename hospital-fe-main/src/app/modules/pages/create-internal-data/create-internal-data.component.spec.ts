import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateInternalDataComponent } from './create-internal-data.component';

describe('CreateInternalDataComponent', () => {
  let component: CreateInternalDataComponent;
  let fixture: ComponentFixture<CreateInternalDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateInternalDataComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateInternalDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
