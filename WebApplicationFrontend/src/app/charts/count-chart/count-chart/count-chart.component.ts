import { style } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { EventStatisticService } from 'src/app/service/event-statistics/event-statistic.service';

@Component({
  selector: 'app-count-chart',
  templateUrl: './count-chart.component.html',
  styleUrls: ['./count-chart.component.css'],
})
export class CountChartComponent implements OnInit {
  

  constructor(private eventStatisticService : EventStatisticService) { }

  chartData : number[] = [];
  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.getCreatedCount();
  }

  getCreatedCount(){
    this.eventStatisticService.getCreatedCount().subscribe(data => {
      this.chartData.push(data);
      this.getBackStepCount();
    });
  }

  getBackStepCount() {
    this.eventStatisticService.getBackStepCount().subscribe(data => {
      this.chartData.push(data);
      this.getQuitCount();
    })
  }
  
  getQuitCount() {
    this.eventStatisticService.getQuitCount().subscribe(data => {
      this.chartData.push(data);
      this.getAverageNumberOfStepsForSuccessful();
    })
  }

  getAverageNumberOfStepsForSuccessful() {
    this.eventStatisticService.getAverageNumberOfStepsForSuccessful().subscribe(data => {
      this.chartData.push(data);
    })
  }

  public barChartOptions: ChartOptions = {
    responsive: true,
    // We use these empty structures as placeholders for dynamic theming.
    scales: { xAxes: [{}], yAxes: [{
      ticks : {
        beginAtZero : true,
        min : 0,
      }
    }] },
    animation : {
      easing : 'linear',
      duration : 1500
    },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };
  public barChartLabels: Label[] = ['Number of scheduled', 'Number of back steps', 'Number of quit', 'Average number of steps for successful'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = false;


  public barChartData: ChartDataSets[] = [
    { data: this.chartData},

  ];
}
