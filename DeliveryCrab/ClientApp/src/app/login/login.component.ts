import { getLocaleMonthNames } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { User } from '../user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = new User();
  users: User[] = [];
  login:string = '';
  password:string = '';
  list_login:Array<any> = [];
  list_password:Array<any> = [];
  list_names:Array<any> = [];
  error_login:string = '';
  constructor(public dataService: DataService, private router:Router) { }

  ngOnInit(): void {
    this.loadUsers()
  }
  loadUsers() {
    this.dataService.getUsers()
      .subscribe((data:any)=>this.users = data as User[])
  }
  log(){
    for(let u of this.users){
      this.list_login.push(u.login);
      this.list_password.push(u.password);
      this.list_names.push(u.firstname);
    }
    for (let i=0;i<this.list_login.length;i++){
      if(this.login == this.list_login[i] && this.password == this.list_password[i]){
        this.dataService.name = this.list_names[i];
        this.dataService.isAuthorization = true;
        this.goHome();
      }else{
        this.error_login = "Неправильный логин или пароль!!!";
      }
    }
    this.list_login = [];
    this.list_password = [];
  }
  goHome(){
    this.router.navigate(['']);
  }
  }


