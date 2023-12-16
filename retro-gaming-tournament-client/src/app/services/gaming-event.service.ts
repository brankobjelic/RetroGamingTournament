import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { GamingEvent } from '../models/gaming-event.model';
import { CreateGamingEvent } from '../models/create-gaming-event.model';

@Injectable({
  providedIn: 'root'
})
export class GamingEventService {

  events: GamingEvent[] = []
  createdEvent!: any
  activeEvent: any

  constructor(private http: HttpClient) { }

  getEvents() : Observable<GamingEvent[]> {
    this.events = []
    var url = 'http://localhost:5180/api/Events';

    return this.http.get<GamingEvent[]>(url, {responseType:'json'}).pipe(
      map(response => {
        response.forEach(element => {
            this.events.push(new GamingEvent(element.id, element.name, element.eventDate,  element.isActive))
          });
       return this.events
      }),
    );
  }

  createEvent(gamingEvent: CreateGamingEvent) : Observable<any> {
    var url = 'http://localhost:5180/api/Events';

    this.createdEvent = this.http.post(url, gamingEvent)
    return this.createdEvent
  }

  getActiveEvent() : Observable<GamingEvent>{
    var url = 'http://localhost:5180/api/Events/ActiveEvent';

    this.activeEvent = this.http.get<GamingEvent>(url, {responseType:'json'})
    return this.activeEvent
  }

}
