import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { User } from '../user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
    user: User = new User();
    users: User[] = [];
    tableMode: boolean = true;


    constructor(public dataService: DataService, private router:Router) { }

    ngOnInit() {
      this.loadUsers();
  }
  loadUsers() {
    this.dataService.getUsers()
      .subscribe((data:any)=>this.users = data as User[])
  }
  save() {
    if (this.user.id == null) {
        this.dataService.createUser(this.user)
            .subscribe((data: User) => this.users.push(data));
        this.dataService.isAuthorization = true
        this.dataService.name = this.user?.firstname
    } else {
        this.dataService.updateUser(this.user)
            .subscribe(data => this.loadUsers());
    }
    this.cancel();
}
editProduct(u: User) {
    this.user = u;
}

delete(u: User) {
  this.dataService.deleteUser(u.id)
      .subscribe(data => this.loadUsers());
}
cancel() {
    this.user = new User();
    this.tableMode = true;
}
goHome(){
  this.router.navigate(['']);
}

}
