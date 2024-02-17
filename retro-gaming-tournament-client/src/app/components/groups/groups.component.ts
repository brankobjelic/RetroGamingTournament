import { Component, ElementRef, QueryList, ViewChild, ViewChildren, Input, Renderer2 } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Game } from '../../models/game.model';
import { Tournament } from 'src/app/models/tournament.model';
import { Observable } from 'rxjs';
import { TournamentService } from 'src/app/services/tournament.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent {

  //receivedData: any;
  game!: Game;
  numberOfPlayers!: number

  //@Input() receivedData: any
  @Input() tournamentId!: any
  // @Input() tournament!: any
  tournament!: any
  //@Input() justCreated!: boolean
  @ViewChildren('P') groupPElementRefs!:QueryList<ElementRef>;
  @ViewChildren('PAudio') groupPAudioElementRefs!:QueryList<ElementRef>;
  @ViewChildren('C') groupCElementRefs!:QueryList<ElementRef>;
  @ViewChildren('CAudio') groupCAudioElementRefs!:QueryList<ElementRef>;
  @ViewChildren('Z') groupZElementRefs!:QueryList<ElementRef>;
  @ViewChildren('ZAudio') groupZAudioElementRefs!:QueryList<ElementRef>;
  @ViewChildren('S') groupSElementRefs!:QueryList<ElementRef>;
  @ViewChildren('SAudio') groupSAudioElementRefs!:QueryList<ElementRef>;

  numberOfPlayersInGroup: number[] = []
  playersInOrderOfAppearance: ElementRef[] = []
  audioInOrderOfAppearance: ElementRef[] = []
  announceFinished: boolean = false
  showPlayerName: boolean[] = [false]


  constructor(private route: ActivatedRoute, private tournamentService: TournamentService, private renderer: Renderer2) {}

  ngOnInit(): void{
    this.tournamentService.tournament$.subscribe(data => {
      this.tournament = data
     console.log(this.tournament)
     this.orderPlayersForAnnouncement()
    })
    this.tournamentService.getTournament(this.tournamentId)

  }

  // ngOnChanges() {
  // }

  ngAfterContentInit(){
    let index = 0;
    let showNextElement = () => {
      //this.showPlayerName = false
      if (index < this.playersInOrderOfAppearance.length) {
        const element = this.playersInOrderOfAppearance[index]
        const elementAudio = this.audioInOrderOfAppearance[index]
        if (element) {
          console.log(element.nativeElement.textContent);
          //element.nativeElement.style.display = "block"
          //element.nativeElement.style.color = "black"
          this.showPlayerName[index] = true
          //this.renderer.setStyle(element.nativeElement, 'display', 'block');
          //if(this.justCreated){
            elementAudio.nativeElement.autoplay = 'true'
            elementAudio.nativeElement.play()
          //}
        }
  
        index++;
        setTimeout(showNextElement, 1500);
      }
      else{
        this.announceFinished = true
      }
    };
    setTimeout(showNextElement, 1500); 
  }

  orderPlayersForAnnouncement() : void {
      console.log(this.groupPElementRefs.toArray());
      for (let i = 0; i < this.groupPElementRefs.toArray().length; i++){
        this.playersInOrderOfAppearance.push(this.groupPElementRefs.toArray()[i])
        this.audioInOrderOfAppearance.push(this.groupPAudioElementRefs.toArray()[i])
        if (this.groupCElementRefs.toArray()[i]){
          this.playersInOrderOfAppearance.push(this.groupCElementRefs.toArray()[i])
          this.audioInOrderOfAppearance.push(this.groupCAudioElementRefs.toArray()[i])

        }        
        if (this.groupZElementRefs.toArray()[i]){
          this.playersInOrderOfAppearance.push(this.groupZElementRefs.toArray()[i])      
          this.audioInOrderOfAppearance.push(this.groupZAudioElementRefs.toArray()[i])
        }        
        if (this.groupSElementRefs.toArray()[i]){
          this.playersInOrderOfAppearance.push(this.groupSElementRefs.toArray()[i])      
          this.audioInOrderOfAppearance.push(this.groupSAudioElementRefs.toArray()[i])
        }
      }
      console.log(this.playersInOrderOfAppearance)
      console.log(this.audioInOrderOfAppearance)
  }



  getAudioUrl(nameAudioFile: string) {
    if(nameAudioFile){
      return `http://localhost:5180/api/Players/Audio/${nameAudioFile}`
    }
    return "http://localhost:5180/api/Players/Audio/nowo-mehso.mp3"
  }
}
