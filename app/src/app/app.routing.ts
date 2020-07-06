﻿import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './helpers/auth.guard';
import { GamesComponent } from './components/game/games.component';
import { LoginComponent } from './components/login/login.component';
import { AccountComponent } from "./components/account/account.component";

const routes: Routes = [
  { path: '', component: GamesComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'account', component: AccountComponent, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
