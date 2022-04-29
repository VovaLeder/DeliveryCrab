import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../user.service';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit  {
  constructor(public dataService: DataService, private router:Router){}
  ngOnInit() {
  }
  exit(){
    this.dataService.isAuthorization = false;
    this.router.navigate(['']);
  }


}
