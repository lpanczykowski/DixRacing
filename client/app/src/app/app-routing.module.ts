import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EventListComponent } from './events/event-list/event-list.component';
import { RegisterComponent } from './register/register.component';
import { DriversComponent } from './drivers/drivers.component';
import { EventDetailsComponent } from './events/event-details/event-details.component';
import { RaceDetailsComponent } from './races/race-details/race-details.component';
import { EventSignupComponent } from './events/event-signup/event-signup.component';
import { UserProfileComponent } from './user/user-profile/user-profile.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'event', component: EventListComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'event/:eventId', component: EventDetailsComponent },
  {
    path: 'event/:eventId/round/:roundId/race/:raceId/:view',
    component: RaceDetailsComponent,
  },
  { path: 'profile/:steamId', component: UserProfileComponent},
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}
