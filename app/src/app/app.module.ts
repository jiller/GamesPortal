import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { CookieService } from "ngx-cookie-service";

import { AppComponent } from './app.component';
import { appRoutingModule } from "./app.routing";

import { JwtInterceptor } from "./helpers/jwt.interceptor";
import { ErrorInterceptor } from "./helpers/error.interceptor";
import { LoginComponent } from './components/login/login.component';
import { GamesComponent } from './components/game/games.component';
import { AccountComponent } from './components/account/account.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    GamesComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    appRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
