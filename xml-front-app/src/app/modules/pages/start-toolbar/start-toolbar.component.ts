import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'start-toolbar',
  templateUrl: './start-toolbar.component.html',
  styleUrls: ['./start-toolbar.component.css']
})
export class StartToolbarComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  HomeClick(){

  }

  RegisterClick(){
    this.router.navigate(['register']);

  }

  LoginClick(){
    this.router.navigate(['login']);
  }

}
