import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Player } from '../models/player.model';
import { forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TournamentService {

  playersByGroups: any

  constructor(private http: HttpClient) { }

  getGroups(data: Player[]) : Observable<any>{
    var url = 'http://localhost:5180/api/Tournaments/Draw'
    this.playersByGroups = this.http.post(url, data)
    console.log(this.playersByGroups)
    return this.playersByGroups
  }
}
