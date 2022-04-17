import { Component, Inject} from '@angular/core';
import { DataService } from '../data.service';
import { User } from '../user';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [DataService]
})
export class RegisterComponent  {
    user: User = new User();
    users: User[] = [];
    tableMode: boolean = true;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,private dataService: DataService) {
      http.get<User[]>(baseUrl + 'users/getusers').subscribe(result => {
        this.users = result;
      }, error => console.error(error));
    }

  //   loadProducts() {
  //     this.dataService.getUsers()
  //         .subscribe((data: User[]) => this.users = data);
  // }
    save() {
      if (this.user.id == null) {
          this.dataService.createUser(this.user)
              .subscribe((data: User) => this.users.push(data));
}}}
