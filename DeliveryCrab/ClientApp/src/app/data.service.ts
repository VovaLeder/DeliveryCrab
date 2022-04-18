import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { User } from './user';

@Injectable()
export class DataService {

  constructor(private http: HttpClient) {
    }

    getUsers() {
        return this.http.get("https://localhost:44432/user/getuser");
    }

    getUser(id: number) {
        return this.http.get("https://localhost:44432/user/getuser" + '/' + id);
    }

    createUser(user: User) {
        return this.http.post("https://localhost:44432/user/getuser", user);
    }
    updateUser(user: User) {

        return this.http.put("https://localhost:44432/user/getuser", user);
    }
    deleteUser(id: number) {
        return this.http.delete("https://localhost:44432/user/getuser" + '/' + id);
    }
}
