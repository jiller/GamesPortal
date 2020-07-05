import { Component, OnInit } from '@angular/core';
import { UserService } from "../services/user.service";
import { GamesService } from "../services/games.service";

import { Game } from "../model/game";
import {AuthService} from "../services/auth.service";

@Component({
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.less']
})
export class GamesComponent implements OnInit {
  loading = false;
  games: Game[];
  userAuthorized: boolean;

  constructor(private userService: UserService,
              private authService: AuthService,
              private gamesService: GamesService) {
    this.authService.authData
      .subscribe(auth => this.userAuthorized = !!auth);
  }

  ngOnInit(): void {
    this.loading = true;
    this.gamesService.getAll().subscribe(games => {
      this.loading = false;
      this.games = games;
    });
  }
}
