import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { EventStatisticService } from 'src/app/service/event-statistics/event-statistic.service';

@Component({
  selector: 'app-average-time-chart',
  templateUrl: './average-time-chart.component.html',
  styleUrls: ['./average-time-chart.component.css']
})
export class AverageTimeChartComponent implements OnInit {

  chartData : number[] = [];

  constructor(private eventStatisticService : EventStatisticService) { }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.getAverageSchedulingTime();
  }

  getAverageSchedulingTime(){
    this.eventStatisticService.getAverageSchedulingTime().subscribe(data => {
      this.chartData.push(parseFloat(data.toFixed(2)));
      this.getAverageTimeFromStartToSpecialization();
    });
  }

  getAverageTimeFromStartToSpecialization(){
    this.eventStatisticService.getAverageTimeFromStartedToSpecialization().subscribe(data => {
      this.chartData.push(parseFloat(data.toFixed(2)));
      this.getAverageTimeFromSpecializationToDoctor();
    });
  }

  getAverageTimeFromSpecializationToDoctor(){
    this.eventStatisticService.getAverageTimeFromSpecializationToDoctor().subscribe(data => {
      this.chartData.push(parseFloat(data.toFixed(2)));
      this.getAverageTimeFromDoctorToAppointment();
    });
  }

  getAverageTimeFromDoctorToAppointment(){
    this.eventStatisticService.getAverageTimeFromDoctorToAppointment().subscribe(data => {
      this.chartData.push(parseFloat(data.toFixed(2)));
    });
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
  public barChartLabels: Label[] = ['Average scheduling time', 'Average time from start to specialization select', 'Average time from specialization select to doctor select', 'Average time from doctor select to appointment select'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = false;


  public barChartData: ChartDataSets[] = [
    { data: this.chartData},

  ];

}
