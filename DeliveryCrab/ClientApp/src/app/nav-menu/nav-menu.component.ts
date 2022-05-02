import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],

})
export class NavMenuComponent implements OnInit  {
  constructor(public userService: UserService, private router:Router){}
  ngOnInit() {
  }
  exit(){
    this.userService.isAuthorization = false;
    this.router.navigate(['']);
  }


}
