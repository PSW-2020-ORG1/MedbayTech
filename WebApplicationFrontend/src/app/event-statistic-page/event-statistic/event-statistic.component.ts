import { SucceedQuitRatioChartComponent } from './../../charts/succeed-quit-ratio-chart/succeed-quit-ratio-chart/succeed-quit-ratio-chart.component';
import { Component, OnInit } from '@angular/core';
import { EventStatisticService } from 'src/app/service/event-statistics/event-statistic.service';
import { CountChartComponent } from 'src/app/charts/count-chart/count-chart/count-chart.component';
import { AverageTimeChartComponent } from 'src/app/charts/average-time-chart/average-time-chart/average-time-chart.component';

@Component({
  selector: 'app-event-statistic',
  templateUrl: './event-statistic.component.html',
  styleUrls: ['./event-statistic.component.css']
})
export class EventStatisticComponent implements OnInit {

  constructor(private eventStatisticService : EventStatisticService) { }

  succeedQuitRatioChart : SucceedQuitRatioChartComponent;
  countChart : CountChartComponent;
  averageTimeChart: AverageTimeChartComponent;
  ngOnInit(): void {
    this.succeedQuitRatioChart = new SucceedQuitRatioChartComponent(this.eventStatisticService);
    this.countChart = new CountChartComponent(this.eventStatisticService);
    this.averageTimeChart = new AverageTimeChartComponent(this.eventStatisticService);
  }

  gtePieData() {
    this.succeedQuitRatioChart.getData();
    console.log("dsadas");
  }
}
