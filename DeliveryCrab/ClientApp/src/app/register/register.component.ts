import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../user.service';
import { User } from '../user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
    user: User = new User();
    users: User[] = [];
    constructor(public dataService: DataService, private router:Router) { }

    ngOnInit() {
      this.loadUsers();
  }
  loadUsers() {
    this.dataService.getUsers()
      .subscribe((data:any)=>this.users = data as User[])
  }

  save() {

        this.dataService.createUser(this.user)
            .subscribe((data: User) => this.users.push(data));
        this.dataService.isAuthorization = true
        this.dataService.log_user.firstname = this.user?.firstname
        this.dataService.log_user.lastname = this.user?.lastname
        this.dataService.log_user.age = this.user?.age
        this.dataService.log_user.login = this.user?.login
        this.dataService.log_user.email = this.user?.email
        this.dataService.log_user.password = this.user?.password
}
goHome(){
  this.router.navigate(['']);
}

}
