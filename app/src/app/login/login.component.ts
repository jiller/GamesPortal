import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { first } from "rxjs/operators";

import { AuthService } from "../services/auth.service";

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  loading = false;
  loginError = "";

  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private router: Router) {
    // redirect to home if already logged in
    if (this.authService.currentAuthData) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: '',
      password: ''
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit(loginData: any) {
    this.submitted = true;

    if (this.loginForm.invalid) {
      return;
    }

    this.disableLoginForm();

    this.authService
      .login(loginData.email, loginData.password)
      .pipe(first())
      .subscribe(
        data => this.router.navigate(['/']),
        error => this.showLoginError(error)
      );
  }

  disableLoginForm() {
    this.loading = true;
  }

  enableLoginForm(loginFailed: boolean) {
    this.loading = false;
  }

  showLoginError(message: string) {
    this.loginError = message || "Service unavailable";
    this.enableLoginForm(true);
  }
}
