import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit  {
  
  model:any= {};
  loggedIn=false;
  user:any={};
  constructor(private accountService:AccountService) {}
  ngOnInit(): void {
   
  }

  login(){
    this.accountService.login(this.model).subscribe({
      next:response=> { 
        this.user=response;
      
        console.log("user:"+this.user.userName+" token:"+this.user.token);
        this.loggedIn=true;
       },
       error:error=> console.log("hata :"+error)
    })
  }

  logout() {
    this.loggedIn=false;
  }
}
