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
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AuthGuard } from './guards/auth.guard';
import { AdminGuard } from './guards/admin.guard';

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
  { path: 'event/signup/:eventId', component: EventSignupComponent },
  { path: '1/drivers', component: DriversComponent }, //TODO:
  { path: 'profile/:steamId', component: UserProfileComponent},
  { path: 'admin/panel', component: AdminPanelComponent , canActivate:[AdminGuard]},
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}
