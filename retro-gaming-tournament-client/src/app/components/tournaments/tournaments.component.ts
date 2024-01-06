import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tournaments',
  templateUrl: './tournaments.component.html',
  styleUrls: ['./tournaments.component.css']
})
export class TournamentsComponent {
  receivedData: any;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void{
    this.route.queryParams.subscribe(params => {
      this.receivedData = JSON.parse(params['data']);
    });

  }
}
