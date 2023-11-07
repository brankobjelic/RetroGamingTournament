import { Component } from '@angular/core';
import { GamingEventService } from '../../services/gaming-event.service';
import { GamingEvent } from '../../models/gaming-event.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gaming-events',
  templateUrl: './gaming-events.component.html',
  styleUrls: ['./gaming-events.component.css']
})
export class GamingEventsComponent {

  activeEvents: GamingEvent[] = []
  inactiveEvents: GamingEvent[] = []

  constructor(private eventService: GamingEventService, private router: Router){}

  ngOnInit(){
    this.eventService.getEvents().subscribe({
      next: (data) =>    {
        data.forEach(element => {
          if(element.isActive)
           this.activeEvents.push(element)
          else
          this.inactiveEvents.push(element)
        });
      }     
    })
  }

  onClick(){
    this.router.navigate(['/create-gaming-event']);
  }
}
