import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './app/home/home.component';
import { EventsComponent } from './app/events/events.component';
import { RacesComponent } from './app/races/races.component';
import { InfoComponent } from './app/info/info.component';
import { RegisterComponent } from './app/register/register.component';

const routes: Routes=[
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'events', component: EventsComponent},
  {path: 'races', component: RacesComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'info', component: InfoComponent},
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
