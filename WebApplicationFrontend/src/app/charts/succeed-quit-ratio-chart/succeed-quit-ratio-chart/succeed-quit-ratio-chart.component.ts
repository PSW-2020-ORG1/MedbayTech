import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { EventStatisticService } from 'src/app/service/event-statistics/event-statistic.service';

@Component({
  selector: 'app-succeed-quit-ratio-chart',
  templateUrl: './succeed-quit-ratio-chart.component.html',
  styleUrls: ['./succeed-quit-ratio-chart.component.css']
})
export class SucceedQuitRatioChartComponent implements OnInit {

  constructor(private eventStatisticService : EventStatisticService) { }

  chartData : number[] = [];
  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.eventStatisticService.getSucceedQuitRatio().subscribe(data => {
      data.forEach(element => {
        this.pieChartData.push(parseFloat(element.toFixed(2)));
      });
      
    })
  }
  public pieChartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: 'top',
    },
    animation : {
      easing: 'easeOutQuart',
      duration : 6000
    },
    plugins: {
      datalabels: {
        formatter: (value, ctx) => {
          const label = ctx.chart.data.labels[ctx.dataIndex];
          return label;
        },
      },
    }
  };

  public pieChartLabels: Label[] = [['Success %'], ['Quit %']];
  public pieChartData: number[] = [];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = ['Download', 'Dada', 'DAD']
  public pieChartColors = [
    {
      backgroundColor: ['rgba(0,255,0,0.3)', 'rgba(255,0,0,0.3)'],
    },
  ];
}
