import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";

import { map } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { AuthData } from "../model/authData";

@Injectable({providedIn: 'root'})
export class AuthService {

  private url: string;
  private authDataBehaviorSubject: BehaviorSubject<AuthData>;
  public authData: Observable<AuthData>;

  constructor(private http: HttpClient) {
    this.url = (environment.api_url.endsWith("/")
      ? environment.api_url
      : environment.api_url + "/") + "api/login";

    this.authDataBehaviorSubject = new BehaviorSubject<AuthData>(JSON.parse(sessionStorage.getItem("token")));
    this.authData = this.authDataBehaviorSubject.asObservable();
  }

  public get currentAuthData(): AuthData {
    return this.authDataBehaviorSubject.value;
  }

  login(email, password) {
    return this.http.post<AuthData>(this.url, {
        EmailAddress: email,
        Password: password
      })
      .pipe(map(response => {
        // store jwt token in local storage to keep user logged in between page refreshes
        sessionStorage.setItem("token", JSON.stringify(response));
        this.authDataBehaviorSubject.next(response);
        return response;
      }));
  }

  logout() {
    // remove jwt token from local storage to log user out
    sessionStorage.removeItem("token");
    this.authDataBehaviorSubject.next(null);
  }
}
