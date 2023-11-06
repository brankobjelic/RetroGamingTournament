import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { TournamentsComponent } from './components/tournaments/tournaments.component';
import { PlayersComponent } from './components/players/players.component';
import { GamesComponent } from './components/games/games.component';
import { CreateTournamentComponent } from './components/create-tournament/create-tournament.component';
import { GroupsComponent } from './components/groups/groups.component';
import { CdkDropList, DragDropModule } from '@angular/cdk/drag-drop';
import { GroupTypeAScoresComponent } from './ResultForms/form8a/form8a.component';
import { GamingEventsComponent } from './components/gaming-events/gaming-events.component';


@NgModule({
  declarations: [
    AppComponent,
    TournamentsComponent,
    PlayersComponent,
    GamesComponent,
    GroupsComponent,
    GroupTypeAScoresComponent,
    GamingEventsComponent,  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    DragDropModule,
    CdkDropList,
    CreateTournamentComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
