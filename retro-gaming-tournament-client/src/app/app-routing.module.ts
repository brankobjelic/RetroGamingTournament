import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateTournamentComponent } from './components/create-tournament/create-tournament.component';
import { GamesComponent } from './components/games/games.component';
import { PlayersComponent } from './components/players/players.component';
import { GroupsComponent } from './components/groups/groups.component';
import { GamingEventsComponent } from './components/gaming-events/gaming-events.component';
import { CreateGamingEventComponent } from './components/create-gaming-event/create-gaming-event.component';
import { Tournament } from './models/tournament.model';
import { TournamentsComponent } from './components/tournaments/tournaments.component';

const routes: Routes = [  
  { path: '', redirectTo: 'players', pathMatch: 'full'},
  { path: 'gaming-events', component: GamingEventsComponent, pathMatch: 'full'},
  { path: 'players', component: PlayersComponent, pathMatch: 'full'},
  { path: 'games', component: GamesComponent, pathMatch: 'full'},
  { path: 'create-tournament', component: CreateTournamentComponent, pathMatch: 'full'},
  { path: 'groups', component: GroupsComponent, pathMatch: 'full'},
  { path: 'create-gaming-event', component: CreateGamingEventComponent, pathMatch: 'full'},
  { path: 'tournaments', component: TournamentsComponent, pathMatch: 'full'}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
