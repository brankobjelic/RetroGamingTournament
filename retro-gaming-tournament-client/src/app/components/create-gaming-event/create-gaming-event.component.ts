import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateGamingEvent } from 'src/app/models/create-gaming-event.model';
import { GamingEvent } from 'src/app/models/gaming-event.model';
import { GamingEventService } from 'src/app/services/gaming-event.service';

@Component({
  selector: 'app-create-gaming-event',
  templateUrl: './create-gaming-event.component.html',
  styleUrls: ['./create-gaming-event.component.css']
})
export class CreateGamingEventComponent {

  gamingEventService: GamingEventService

  constructor(gamingEventService: GamingEventService, private router: Router){
    this.gamingEventService = gamingEventService
  }
  name = new FormControl('')
  onSubmit(){
    const eventName: string = this.name.value !== null ? this.name.value : ''
    let gamingEvent: CreateGamingEvent = {name: eventName}

    this.gamingEventService.createEvent(gamingEvent).subscribe({
      next: (data: GamingEvent) => {
        alert('event created')
        console.log(data)
        this.router.navigate(['/active-gaming-event/', data.id]);
      },
      error: () => {
        alert('event not created')
      }
    })
  }
}
