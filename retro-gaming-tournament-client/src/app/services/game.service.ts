import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Game } from '../models/game.model';
import { Observable, map } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class GameService {

  games: Game[] = []

  constructor(private http: HttpClient) { }

  getGames() : Observable<Game[]> {
    this.games = []
    var url = 'http://localhost:5180/api/Games';

    return this.http.get<Game[]>(url, {responseType:'json'}).pipe(
      map(response => {
        response.forEach(element => {
            this.games.push(new Game(element.id, element.name, element.bannerFile, element.gameType))
          });
       return this.games
      }),
    );
  }
}
