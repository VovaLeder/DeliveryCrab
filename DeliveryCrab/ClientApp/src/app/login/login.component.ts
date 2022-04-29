import { getLocaleMonthNames } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../user.service';
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
  list_id:Array<any> = [];
  list_firstnames:Array<any> = [];
  list_lastnames:Array<any> = [];
  list_ages:Array<any> = [];
  list_login:Array<any> = [];
  list_email:Array<any> = [];
  list_password:Array<any> = [];

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
      this.list_id.push(u.id)
      this.list_firstnames.push(u.firstname);
      this.list_lastnames.push(u.lastname);
      this.list_ages.push(u.age)
      this.list_login.push(u.login);
      this.list_email.push(u.email);
      this.list_password.push(u.password);

    }
    for (let i=0;i<this.list_login.length;i++){
      if(this.login == this.list_login[i] && this.password == this.list_password[i]){
        this.dataService.log_user.id = this.list_id[i];
        this.dataService.log_user.firstname = this.list_firstnames[i];
        this.dataService.log_user.lastname = this.list_lastnames[i];
        this.dataService.log_user.age = this.list_ages[i];
        this.dataService.log_user.login = this.list_login[i];
        this.dataService.log_user.email = this.list_email[i];
        this.dataService.log_user.password = this.list_password[i];
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


