import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Player } from '../models/player.model';

@Injectable({
  providedIn: 'root'
})
export class TournamentService {

  constructor(private http: HttpClient) { }

  getGroups(data: Player[]) : Observable<any>{
    var url = 'http://localhost:5180/api/Tournaments/Draw'
    return this.http.post(url, data);

  }
}
