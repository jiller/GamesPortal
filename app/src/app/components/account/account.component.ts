import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { first } from "rxjs/operators";

import { UserService } from "../../services/user.service";
import { ConfirmedValidator } from "../../validators/confirmedValidator";

import { User } from "../../model/user";

@Component({
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.less']
})
export class AccountComponent implements OnInit {
  currentUser: User;
  accountForm: FormGroup;
  submitted: boolean = false;
  accountError: string;
  loading: boolean = false;
  success: boolean = false;

  constructor(private userService: UserService,
              private formBuilder: FormBuilder,
              private router: Router) {
    this.userService.currentUser
      .subscribe(user => {
        this.currentUser = user;
      });
  }

  ngOnInit(): void {
    this.accountForm = this.formBuilder.group({
      emailAddress: '',
      firstName: '',
      lastName: '',
      password: '',
      confirmPassword: ''
    }, {
      validators: ConfirmedValidator("password", "confirmPassword")
    });

    if (!this.userService.currentUserValue) {
      this.loading = true;
      this.userService.load()
        .subscribe(response => this.loading = false);
    }
  }

  get f() { return this.accountForm.controls; }

  onSubmit(userData: any) {
    this.submitted = true;
    this.success = false;
    this.accountError = null;

    if (this.accountForm.invalid) {
      return;
    }

    this.loading = true;

    this.userService
      .setUserData(userData)
      .pipe(first())
      .subscribe(
        data => this.success = true,
        error => this.accountError = error
      )
      .add(() => this.loading = false);
  }

  cancel() {
    this.router.navigate(['/']);
  }

  errorIsText() {
    return this.accountError && this.getErrorKeys().length == 0;
  }

  errorIsObject() {
    return this.accountError && this.getErrorKeys().length > 0;
  }

  getErrorKeys() {
    return Object.keys(this.accountError);
  }
}
