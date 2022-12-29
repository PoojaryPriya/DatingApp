import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode=false;
  users:any;

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.http.get("http://localhost:5096/api/users").subscribe({
      next: response => this.users=response,
      error: error=>console.error(),
      complete: ()=> console.log('Request has completed')
      
    })
  }

  registerToggle() {
    this.registerMode=!this.registerMode;
  }

  cancelRegisterMode(event:boolean){
    this.registerMode=event;
  }

}