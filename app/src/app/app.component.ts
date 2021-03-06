import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

import { AuthService } from "./services/auth.service";
import { UserService } from "./services/user.service";
import { User } from "./model/user";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  userAuthorized: boolean;
  currentUser: User;

  constructor(private authService: AuthService,
              private userService: UserService,
              private router: Router) {

    this.userService.currentUser
      .subscribe(user => this.currentUser = user);

    this.authService.authData
      .subscribe(auth => {
        this.userAuthorized = !!auth;

        if (this.userAuthorized) {
          this.userService.load().subscribe(user => true);
        }
      });
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
