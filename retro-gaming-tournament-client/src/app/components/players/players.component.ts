import { Component } from '@angular/core';
import { PlayerService } from '../../services/player.service';
import { Player } from '../../models/player.model';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent {

  players: Player[] = []

  constructor(private playerService: PlayerService){}

  ngOnInit(){
    this.playerService.getPlayers().subscribe({
      next: (data) =>    {
        this.players = data;
      }     
    })
  }
}
