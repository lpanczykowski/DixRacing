import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './app/home/home.component';
import { EventListComponent } from './app/events/event-list/event-list.component';
import { InfoComponent } from './app/info/info.component';
import { RegisterComponent } from './app/register/register.component';
import { RulesComponent } from './app/rules/rules.component';
import { DriversComponent } from './app/drivers/drivers.component';
import { TeamsComponent } from './app/teams/teams.component';
import { StandingsComponent } from './app/standings/standings.component';
import { PenaltiesComponent } from './app/penalties/penalties.component';
import { RaceComponent } from './app/race/race.component';

const routes: Routes=[
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'event', component: EventListComponent},
 // {path: 'event/info', component: EventComponent},
  {path: 'race', component: RaceComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'eventId/info', component: InfoComponent},
  {path: 'eventId/rules', component: RulesComponent},
  {path: '1/drivers', component: DriversComponent},
  {path: 'eventId/teams', component: TeamsComponent},
  {path: 'eventId/standings', component: StandingsComponent},
  {path: 'eventId/penalties', component: PenaltiesComponent},
  //{path: 'eventId/signup', component: EventComponent},
  //{path: 'raceId/signup', component: EventComponent},
  {path: '**', component: HomeComponent, pathMatch:'full'},
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { }
