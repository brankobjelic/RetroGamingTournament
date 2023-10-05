import { Component } from '@angular/core';
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
  CdkDrag,
  CdkDropList,
} from '@angular/cdk/drag-drop';
import { NgFor } from '@angular/common';
import { Player } from '../models/player.model';
import { PlayerService } from '../services/player.service';
import { TournamentService } from '../services/tournament.service';

@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament.component.html',
  styleUrls: ['./create-tournament.component.css'],
  standalone: true,
  imports: [CdkDropList, NgFor, CdkDrag]
})
export class CreateTournamentComponent {

  constructor(private playerService: PlayerService, private tournamentService: TournamentService){}

  players : Player[] = []
  tournamentPlayers: Player[] = []
  arr : number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
 

  ngOnInit(){
    this.playerService.getPlayers().subscribe({
      next: (data) =>    {
        this.players = data;
        this.tournamentPlayers  = []
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
  onSubmitPlayers(){
    console.log(this.tournamentPlayers)
    this.tournamentService.getGroups(this.tournamentPlayers).subscribe({
      next: (response) => {
        console.log(response)
      }
    })

  }

}
