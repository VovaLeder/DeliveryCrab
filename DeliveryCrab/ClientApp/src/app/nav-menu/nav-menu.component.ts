import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit  {
  constructor(public dataService: DataService){}
  ngOnInit() {
  }
  exit(){
    this.dataService.isAuthorization = false;
  }


}
