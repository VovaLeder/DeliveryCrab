import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { User } from './user';

@Injectable()
export class DataService {

  private url = "https://localhost:44432/user/getusers";

    constructor(private http: HttpClient) {
    }

    getUsers() {
        return this.http.get(this.url);
    }

    getUser(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createUser(user: User) {
        return this.http.post(this.url, user);
    }
    updateUser(user: User) {

        return this.http.put(this.url, user);
    }
    deleteUser(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}
