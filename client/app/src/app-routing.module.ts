import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './app/home/home.component';
import { EventListComponent } from './app/events/event-list/event-list.component';
import { RegisterComponent } from './app/register/register.component';
import { DriversComponent } from './app/drivers/drivers.component';
import { EventDetailsComponent } from './app/events/event-details/event-details.component';
import { RaceDetailsComponent } from './app/races/race-details/race-details.component';

const routes: Routes=[
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'event', component: EventListComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'event/:eventId', component: EventDetailsComponent},
  {path: 'event/:eventId/round/:roundId/race/:raceId/:view', component: RaceDetailsComponent},
  {path: '1/drivers', component: DriversComponent},
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
