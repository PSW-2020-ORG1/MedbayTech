import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AverageTimeChartComponent } from './average-time-chart.component';

describe('AverageTimeChartComponent', () => {
  let component: AverageTimeChartComponent;
  let fixture: ComponentFixture<AverageTimeChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AverageTimeChartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AverageTimeChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
