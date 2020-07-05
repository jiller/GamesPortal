import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";

import { map } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { User } from "../model/user";
import {ChangeUserData} from "../model/changeUserData";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url: string;

  public currentUser: BehaviorSubject<User>;

  constructor(private http: HttpClient) {
    this.url = (environment.api_url.endsWith("/")
      ? environment.api_url
      : environment.api_url + "/") + "api/user";

    this.currentUser = new BehaviorSubject<User>(null);
  }

  public get currentUserValue() {
    return this.currentUser.value;
  }

  load() {
    return this.http.get<User>(this.url)
      .pipe(map(user => {
        this.currentUser.next(user);
        return user;
      }));
  }

  setUserData(userData: ChangeUserData) {
    return this.http.put<User>(this.url, userData)
      .pipe(map(user => {
        this.currentUser.next(user);
        return user;
      }));
  }
}
