import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { PlayersComponent } from './players/players.component';
import { GamesComponent } from './games/games.component';
import { CreateTournamentComponent } from './create-tournament/create-tournament.component';
import { GroupsComponent } from './groups/groups.component';


@NgModule({
  declarations: [
    AppComponent,
    TournamentsComponent,
    PlayersComponent,
    GamesComponent,
    GroupsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CreateTournamentComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
