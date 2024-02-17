import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GamingEvent } from 'src/app/models/gaming-event.model';
import { Tournament } from 'src/app/models/tournament.model';
import { GamingEventService } from 'src/app/services/gaming-event.service';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-active-gaming-event',
  templateUrl: './active-gaming-event.component.html',
  styleUrls: ['./active-gaming-event.component.css']
})
export class ActiveGamingEventComponent {

  gamingEventId: any
  gamingEvent: GamingEvent | undefined
  activeTournaments: Tournament[] = []
  inactiveTournaments: Tournament[] = []
  justCreated: boolean = false

  constructor(private tournamentService: TournamentService, private router: Router, private activatedRoute : ActivatedRoute, private gamingEventService: GamingEventService) { }

  ngOnInit(){
    this.gamingEventId = this.activatedRoute.snapshot.paramMap.get("id");
    this.gamingEventService.getActiveEvent().subscribe({
      next: (data) => {
        this.gamingEvent = data;
      }
    })
    this.tournamentService.getTournamentsByEventId(this.gamingEventId).subscribe({
      next: (data) =>    {
        this.activeTournaments = []
        this.inactiveTournaments = []
        console.log(data)
        data.forEach((element: any) => {
          if(element.isActive)
           this.activeTournaments.push(element)
          else
          this.inactiveTournaments.push(element)
        });
      }     
    })
  }

  onClick(){
    this.router.navigate(['/create-tournament']);
  }
}
