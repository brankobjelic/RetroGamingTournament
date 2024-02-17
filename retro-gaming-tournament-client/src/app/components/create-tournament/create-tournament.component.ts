import { Component, OnInit } from '@angular/core';
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
  CdkDrag,
  CdkDropList,
  DragDropModule,
} from '@angular/cdk/drag-drop';
import { NgFor, NgIf } from '@angular/common';
import { Player } from '../../models/player.model';
import { PlayerService } from '../../services/player.service';
import { Game } from '../../models/game.model';
import { GameService } from '../../services/game.service';
import { TournamentService } from '../../services/tournament.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from '@angular/forms';
import { forkJoin, map, mergeAll, mergeMap, toArray } from 'rxjs';
import { GamingEvent } from 'src/app/models/gaming-event.model';
import { GamingEventService } from 'src/app/services/gaming-event.service';
import { CreateTournament } from 'src/app/models/create-tournament.model';

@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament.component.html',
  styleUrls: ['./create-tournament.component.css'],
  standalone: true,
  imports: [CdkDropList, NgFor, NgIf, CdkDrag, ReactiveFormsModule, DragDropModule]
})
export class CreateTournamentComponent {

  //createTournamentForm!: FormGroup
  players : Player[] = []
  tournamentPlayers: Player[] = []
  tournamentPlayersIds: number[] = []
  arr : number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
  games : Game[] = []
  numberOfPlayers!: number
  gamingEvent?: GamingEvent
  tournamentToCreate?: CreateTournament
  createTournamentForm: FormGroup = new FormGroup({
    game: new FormControl(),
  })
  tournament!: any



  constructor(private playerService: PlayerService, private tournamentService: TournamentService, private router: Router, private http: HttpClient, private gameService: GameService, private gamingEventService: GamingEventService){}

 

  ngOnInit(){
    this.gamingEventService.getActiveEvent().subscribe({
      next: (data) => {
        this.gamingEvent = data;
      }
    })
    this.playerService.getPlayers().subscribe({
      next: (data) =>    {
        this.players = data;
        this.tournamentPlayers  = []
      }     
    })
    this.gameService.getGames().subscribe({
      next: (data) =>    {
        this.games = data;
      }     
    })
  }

  onItemDropped(event: CdkDragDrop<Player[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex,
      );
    }

  }
  onSubmit(event: Event){
    event.preventDefault();
    this.tournamentPlayers.forEach(item => {
      this.tournamentPlayersIds.push(item.id)
    })
    console.log(this.createTournamentForm!.value)
    this.tournamentToCreate = new CreateTournament(this.gamingEvent!.id, this.createTournamentForm.get('game')!.value, this.tournamentPlayersIds)
    console.log(this.tournamentToCreate)
    this.tournamentService.createTournament(this.tournamentToCreate).subscribe(resp => {
      this.tournamentPlayersIds = []
      console.log(resp)
      this.tournament = resp
      this.router.navigate(['/tournaments/', this.tournament.id]);
    })
    //this.tournamentPlayersIds = []
    // console.log(this.tournamentPlayers)
    // this.tournamentService.getGroups(this.tournamentPlayers)
    // .subscribe(
    //   response => {
    //     console.log(response)
    //     this.router.navigate(['/groups'], { queryParams: { data: JSON.stringify(response), game: JSON.stringify(this.createTournamentForm.value.game), numberOfPlayers: this.tournamentPlayers.length }});
    //   }, error => {
    //     console.error(error);
    //     // Handle any errors here
    //   }
    // )

  }
}

