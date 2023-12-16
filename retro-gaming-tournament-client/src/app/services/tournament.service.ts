import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Player } from '../models/player.model';
import { Tournament } from '../models/tournament.model';
import { CreateTournament } from '../models/create-tournament.model';

@Injectable({
  providedIn: 'root'
})
export class TournamentService {

  playersByGroups: any
  tournaments: Tournament[] = []
  playerIds: number[] = []
  player!: Player

  constructor(private http: HttpClient) { }

  createTournament(data: CreateTournament) : Observable<any>{
    let url = 'http://localhost:5180/api/Tournaments/'
    return this.http.post(url, data)
  }

  getGroups(data: Player[]) : Observable<any>{
    data.forEach(player => {this.playerIds.push(player.id)})
    let url = 'http://localhost:5180/api/Tournaments/Draw'
    this.playersByGroups = this.http.post(url, data)
    console.log(this.playersByGroups)
    return this.playersByGroups
  }

  getTournamentsByEventId(id: number) : Observable<any>{
    this.tournaments = []
    let url = 'http://localhost:5180/api/Tournaments/' + id
    return this.http.get<Tournament[]>(url, {responseType:'json'}).pipe(
      map(response => {
        response.forEach(element => {
          this.tournaments.push(new Tournament(element.id, element.isActive, element.event, element.game))
        })
        return this.tournaments
      })
    )
  }
}
