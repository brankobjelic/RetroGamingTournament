import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-tournaments',
  templateUrl: './tournaments.component.html',
  styleUrls: ['./tournaments.component.css']
})
export class TournamentsComponent {
  justCreated: boolean = false
  tournamentId: any =this.route.snapshot.paramMap.get("id");
  tournament!: any
  itemsLoaded: boolean = false
  showResultsForm: boolean = false
  constructor(private route: ActivatedRoute, private tournamentService: TournamentService) {}

  ngOnInit(): void{
    this.tournamentService.tournament$.subscribe(data => {
        this.tournament = data
      })
    this.tournamentService.getTournament(this.tournamentId)
  }

  onAnnounceFinished(value: boolean){
    this.showResultsForm = value
  }
}
