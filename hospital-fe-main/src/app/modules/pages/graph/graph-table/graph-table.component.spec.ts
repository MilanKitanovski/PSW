import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphTableComponent } from './graph-table.component';

describe('GraphTableComponent', () => {
  let component: GraphTableComponent;
  let fixture: ComponentFixture<GraphTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GraphTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraphTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
