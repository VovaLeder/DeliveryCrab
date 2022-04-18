import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { User } from '../user';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [DataService]
})
export class RegisterComponent implements OnInit {
    user: User = new User();
    users: User[] = [];
    tableMode: boolean = true;

    constructor(private dataService: DataService) { }

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
    } else {
        this.dataService.updateUser(this.user)
            .subscribe(data => this.loadUsers());
    }
    this.cancel();
}
editProduct(u: User) {
    this.user = u;
}
cancel() {
    this.user = new User();
    this.tableMode = true;
}

}
