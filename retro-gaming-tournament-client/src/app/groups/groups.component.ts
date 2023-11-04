import { Component, ElementRef, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Game } from '../models/game.model';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent {
  receivedData: any;
  game!: Game;
  numberOfPlayers!: number

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


  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void{
    this.route.queryParams.subscribe(params => {
      this.receivedData = JSON.parse(params['data']);
      this.game = JSON.parse(params['game'])
      this.numberOfPlayers = params['numberOfPlayers']
    });

  }

  ngAfterViewInit(): void {
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

      let index = 0;
      const showNextElement = () => {
        if (index < this.playersInOrderOfAppearance.length) {
          const element = this.playersInOrderOfAppearance[index];
          const elementAudio = this.audioInOrderOfAppearance[index]
          if (element) {
            console.log(element.nativeElement.textContent);
            element.nativeElement.style.display = 'block';
            elementAudio.nativeElement.autoplay = 'true'
            elementAudio.nativeElement.play()
          }

          index++;
          setTimeout(showNextElement, 50);
        }
        else{
          this.announceFinished = true
        }
      };
      setTimeout(showNextElement, 50); 
  }
  getAudioUrl(nameAudioFile: string) {
    if(nameAudioFile){
      return `http://localhost:5180/api/Players/Audio/${nameAudioFile}`
    }
    return "http://localhost:5180/api/Players/Audio/nowo-mehso.mp3"
  }
}
