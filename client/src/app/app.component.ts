import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'client';
  users:any;
  url:string='https://localhost:5001/api/';

  constructor(private http:HttpClient) {}

  ngOnInit(): void {
   
    this.http.get(this.url+'users').subscribe({
    next:response=>this.users=response,
    error:error=>console.log("Hata var :"+error)

    })

  }


}
