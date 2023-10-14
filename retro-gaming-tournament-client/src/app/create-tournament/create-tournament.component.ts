import { Component } from '@angular/core';
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
  CdkDrag,
  CdkDropList,
  DragDropModule,
} from '@angular/cdk/drag-drop';
import { NgFor } from '@angular/common';
import { Player } from '../models/player.model';
import { PlayerService } from '../services/player.service';
import { Game } from '../models/game.model';
import { GameService } from '../services/game.service';
import { TournamentService } from '../services/tournament.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from '@angular/forms';
import { forkJoin, map, mergeAll, mergeMap, toArray } from 'rxjs';

@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament.component.html',
  styleUrls: ['./create-tournament.component.css'],
  standalone: true,
  imports: [CdkDropList, NgFor, CdkDrag, ReactiveFormsModule, DragDropModule]
})
export class CreateTournamentComponent {

  //createTournamentForm!: FormGroup

  constructor(private playerService: PlayerService, private tournamentService: TournamentService, private router: Router, private http: HttpClient, private gameService: GameService){}

  players : Player[] = []
  tournamentPlayers: Player[] = []
  arr : number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
  games : Game[] = []

  createTournamentForm = new FormGroup({
    game: new FormControl(),
  })
 

  ngOnInit(){
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
    console.log(this.tournamentPlayers)
    this.tournamentService.getGroups(this.tournamentPlayers)
    .subscribe(
      response => {
        console.log(response)
        this.router.navigate(['/groups'], { queryParams: { data: JSON.stringify(response) } });
      }, error => {
        console.error(error);
        // Handle any errors here
      }
    )

  }
}

