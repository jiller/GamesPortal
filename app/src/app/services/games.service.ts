import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {Game} from "../model/game";

@Injectable({
  providedIn: 'root'
})
export class GamesService {
  private url: string;

  constructor(private http: HttpClient) {
    this.url = (environment.api_url.endsWith("/")
      ? environment.api_url
      : environment.api_url + "/") + "api/games";
  }

  getAll(): Observable<Game[]> {
    return this.http.get<Game[]>(this.url);
  }
}
