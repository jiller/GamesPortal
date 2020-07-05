﻿import { Routes, RouterModule } from '@angular/router';

import { GamesComponent } from './home/games.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './helpers/auth.guard';
import {AccountComponent} from "./account/account.component";

const routes: Routes = [
  { path: '', component: GamesComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'account', component: AccountComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
