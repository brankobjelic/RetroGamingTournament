import { Component, Input } from '@angular/core';
import { Player } from 'src/app/models/player.model';

@Component({
  selector: 'app-group-results-form',
  templateUrl: './group-results-form.component.html',
  styleUrls: ['./group-results-form.component.css']
})
export class GroupResultsFormComponent {
  @Input() group: any

  p1Id!: number
  p2Id!: number
  serial: number = 0
  name!: string

  getSerial(playerId: number, groupPlayers: Player[]) : string{
    groupPlayers.forEach((element, index: number) => {
      if(element.id == playerId){
        this.serial = index + 1
      }
    });
    return this.serial.toString()
  }

  getName(playerId: number, groupPlayers: Player[]) : string{
    groupPlayers.forEach((element) => {
      if(element.id == playerId){
        this.name =  element.name
      }
    });
    return this.name
  }
}
