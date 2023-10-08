import { Component, ElementRef, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent {
  receivedData: any;

  @ViewChildren('P') groupPElementRefs!:QueryList<ElementRef>;
  @ViewChildren('C') groupCElementRefs!:QueryList<ElementRef>;
  @ViewChildren('Z') groupZElementRefs!:QueryList<ElementRef>;
  @ViewChildren('S') groupSElementRefs!:QueryList<ElementRef>;

  numberOfPlayersInGroup: number[] = []
  playersInOrderOfAppearance: ElementRef[] = []


  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void{
    this.route.queryParams.subscribe(params => {
      this.receivedData = JSON.parse(params['data']);
      console.log(this.receivedData);
      console.log(this.receivedData.length)
    });

  }

  ngAfterViewInit(): void {
      console.log(this.groupPElementRefs.toArray());
      console.log(this.groupPElementRefs.toArray()[0])
      for (let i = 0; i < this.groupPElementRefs.toArray().length; i++){
        this.playersInOrderOfAppearance.push(this.groupPElementRefs.toArray()[i])
        if (this.groupCElementRefs.toArray()[i]){
          this.playersInOrderOfAppearance.push(this.groupCElementRefs.toArray()[i])      
        }        
        if (this.groupZElementRefs.toArray()[i]){
          this.playersInOrderOfAppearance.push(this.groupZElementRefs.toArray()[i])      
        }        
        if (this.groupSElementRefs.toArray()[i]){
          this.playersInOrderOfAppearance.push(this.groupSElementRefs.toArray()[i])      
        }
      }

      let index = 0;
      const showNextElement = () => {
        if (index < this.playersInOrderOfAppearance.length) {
          const element = this.playersInOrderOfAppearance[index];
          if (element) {
            console.log(element.nativeElement.textContent);
            element.nativeElement.style.display = 'block';
          }

          index++;
          setTimeout(showNextElement, 2000);
        }
      };

      setTimeout(showNextElement, 2000);
  
  }
}
