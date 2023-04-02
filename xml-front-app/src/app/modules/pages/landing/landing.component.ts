import { Component, OnInit } from '@angular/core';
import { MatLegacyTableDataSource as MatTableDataSource } from '@angular/material/legacy-table';
import { Flight } from 'app/model/flight';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {

  public dataSource = new MatTableDataSource<Flight>();
  public displayedColumns = ['takeoffLoc','landingLoc','takeoffTime','landingTime'];



  constructor() { }

  ngOnInit(): void {
  }

}
