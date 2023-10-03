import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { PlayersComponent } from './players/players.component';
import { GamesComponent } from './games/games.component';
import { CreateTournamentComponent } from './create-tournament/create-tournament.component';

@NgModule({
  declarations: [
    AppComponent,
    TournamentsComponent,
    PlayersComponent,
    GamesComponent,
    CreateTournamentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
