import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateTournamentComponent } from './create-tournament/create-tournament.component';
import { GamesComponent } from './games/games.component';
import { PlayersComponent } from './players/players.component';
import { GroupsComponent } from './groups/groups.component';
import { GamingEventsComponent } from './gaming-events/gaming-events.component';

const routes: Routes = [  { path: '', redirectTo: 'players', pathMatch: 'full'},
{ path: 'gaming-events', component: GamingEventsComponent, pathMatch: 'full'},
{ path: 'players', component: PlayersComponent, pathMatch: 'full'},
{ path: 'games', component: GamesComponent, pathMatch: 'full'},
{ path: 'create-tournament', component: CreateTournamentComponent, pathMatch: 'full'},
{ path: 'groups', component: GroupsComponent, pathMatch: 'full'}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
