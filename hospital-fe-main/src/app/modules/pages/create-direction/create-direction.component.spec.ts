import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDirectionComponent } from './create-direction.component';

describe('CreateDirectionComponent', () => {
  let component: CreateDirectionComponent;
  let fixture: ComponentFixture<CreateDirectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDirectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateDirectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
