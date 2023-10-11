import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Player } from '../models/player.model';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  players: Player[] = []
  
  constructor(private http: HttpClient) { }

  getPlayers() : Observable<Player[]> {
    this.players = []
    var url = 'http://localhost:5180/api/Players';

    return this.http.get<Player[]>(url, {responseType:'json'}).pipe(
      map(response => {
        response.forEach(element => {
            this.players.push(new Player(element.id, element.name, element.nameAudioFile))
          });
       return this.players
      }),
    );
  }

  
}
