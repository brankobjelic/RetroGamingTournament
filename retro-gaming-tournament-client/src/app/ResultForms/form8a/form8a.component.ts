import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-form8a',
  templateUrl: './form8a.component.html',
  styleUrls: ['./form8a.component.css']
})
export class GroupTypeAScoresComponent {
  @Input() rd: any

  colorGroupLetter: string[] = ["P", "C", "Z", "S"]
  colorGroupName: string[] = ["Plava", "Crvena", "Zelena", "Siva"]
  roundRobinOf4: number[][][] = []
  roundRobinOf3: number[][][] = []

  constructor() {}

  ngOnInit(): void{
    this.roundRobinOf4[0] = []
    this.roundRobinOf4[0].push([0,3])
    this.roundRobinOf4[0].push([1,2])
    this.roundRobinOf4[1] = []
    this.roundRobinOf4[1].push([2,0])
    this.roundRobinOf4[1].push([3,1])
    this.roundRobinOf4[2] = []
    this.roundRobinOf4[2].push([0,1])
    this.roundRobinOf4[2].push([2,3])
    this.roundRobinOf3[0] = []
    this.roundRobinOf3[0].push([0,1])
    this.roundRobinOf3[1] = []
    this.roundRobinOf3[1].push([1,2])
    this.roundRobinOf3[2] = []
    this.roundRobinOf3[2].push([2,0])
    console.log(this.rd)
  }

}
