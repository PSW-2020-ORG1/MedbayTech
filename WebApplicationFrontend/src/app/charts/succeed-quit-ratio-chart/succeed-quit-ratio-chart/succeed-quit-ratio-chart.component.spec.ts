import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SucceedQuitRatioChartComponent } from './succeed-quit-ratio-chart.component';

describe('SucceedQuitRatioChartComponent', () => {
  let component: SucceedQuitRatioChartComponent;
  let fixture: ComponentFixture<SucceedQuitRatioChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SucceedQuitRatioChartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SucceedQuitRatioChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
