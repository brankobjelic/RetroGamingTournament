import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { PlayersComponent } from './players/players.component';
import { GamesComponent } from './games/games.component';
import { CreateTournamentComponent } from './create-tournament/create-tournament.component';
import { GroupsComponent } from './groups/groups.component';
import { CdkDropList, DragDropModule } from '@angular/cdk/drag-drop';


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
