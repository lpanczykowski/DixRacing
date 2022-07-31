import { EventRoundsComponent } from './events/event-rounds/event-rounds.component';
import { GapPipe } from './pipes/gap.pipe';
import { EventFormComponent } from './forms/event-form/event-form.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './_modules/shared/shared.module';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { EventListComponent } from './events/event-list/event-list.component';
import { DriversComponent } from './drivers/drivers.component';
import { EventBoxComponent } from './events/event-box/event-box.component';
import { EventDetailsComponent } from './events/event-details/event-details.component';
import { RaceBoxComponent } from './races/race-box/race-box.component';
import { RaceDetailsComponent } from './races/race-details/race-details.component';
import { DriverListComponent } from './drivers/driver-list/driver-list.component';
import { DriverCardComponent } from './drivers/driver-card/driver-card.component';
import { EventRulesComponent } from './events/event-rules/event-rules.component';
import { EventTeamsComponent } from './events/event-teams/event-teams.component';
import { EventPenaltyComponent } from './events/event-penalty/event-penalty.component';
import { EventPointsComponent } from './events/event-points/event-points.component';
import { EventInfoComponent } from './events/event-info/event-info.component';
import { RaceResultsComponent } from './races/race-results/race-results.component';
import { RaceIncidentsComponent } from './races/race-incidents/race-incidents.component';
import { RaceIncidentsReportComponent } from './races/race-incidents-report/race-incidents-report.component';
import { EventSignupComponent } from './events/event-signup/event-signup.component';
import { EventResultsComponent } from './events/event-results/event-results.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { CardComponent } from './_modules/card/card.component';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { AccordionModule } from 'primeng/accordion';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputNumberModule } from 'primeng/inputnumber';
import { PasswordModule } from 'primeng/password';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CalendarComponent } from './calendar/calendar.component';
import { MonthPipe } from './pipes/month.pipe';
import { EventCreatorComponent } from './events/event-creator/event-creator.component';
import { EventRoundCreatorComponent } from './events/event-round-creator/event-round-creator.component';
import { RaceCreatorComponent } from './races/race-creator/race-creator.component';
import { TimePipe } from './pipes/time.pipe';
import { RaceIncidentsOpenComponent } from './races/race-incidents-open/race-incidents-open.component';
import { UserProfileComponent } from './user/user-profile/user-profile.component';
import { RoundCardComponent } from './round-card/round-card.component';
import { UserInfoComponent } from './user/user-info/user-info.component';
import { UserStatsComponent } from './user/user-stats/user-stats.component';
import { UserLeaguesComponent } from './user/user-leagues/user-leagues.component';
import { EventCardComponent } from './events/event-card/event-card.component';
import { DropdownComponent } from './_modules/shared/dropdown/dropdown.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { AdminEventDetailsComponent } from './admin/events/admin-event-list/admin-event-details/admin-event-details.component';
import { AdminEventListComponent } from './admin/events/admin-event-list/admin-event-list/admin-event-list.component';
import { PenaltySolveFormComponent } from './forms/penalty-solve-form/penalty-solve-form.component';
import { BreadcrumbModule} from 'primeng/breadcrumb';
import { AdminEventCreatorComponent } from './admin/events/admin-event-creator/admin-event-creator.component';
import { ImageUploadComponent } from './_modules/shared/img-upload/img-upload.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    EventListComponent,
    DriversComponent,
    EventBoxComponent,
    EventDetailsComponent,
    RaceBoxComponent,
    RaceDetailsComponent,
    DriverListComponent,
    DriverCardComponent,
    EventRulesComponent,
    EventTeamsComponent,
    EventPenaltyComponent,
    EventPointsComponent,
    EventInfoComponent,
    RaceResultsComponent,
    RaceIncidentsComponent,
    RaceIncidentsReportComponent,
    EventSignupComponent,
    EventResultsComponent,
    CardComponent,
    CalendarComponent,
    MonthPipe,
    EventFormComponent,
    EventCreatorComponent,
    EventRoundCreatorComponent,
    RaceCreatorComponent,
    TimePipe,
    GapPipe,
    RaceIncidentsOpenComponent,
    UserProfileComponent,
    RoundCardComponent,
    UserInfoComponent,
    UserStatsComponent,
    UserLeaguesComponent,
    EventCardComponent,
    EventRoundsComponent,
    DropdownComponent,
    AdminPanelComponent,
    AdminEventDetailsComponent,
    AdminEventListComponent,
    PenaltySolveFormComponent,
    AdminEventCreatorComponent,
    ImageUploadComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    SharedModule,
    ButtonModule,
    CardModule,
    AccordionModule,
    TableModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    PasswordModule,
    ToggleButtonModule,
    AngularEditorModule,
    ConfirmDialogModule,
    BreadcrumbModule,
  ],

  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    [ConfirmationService]
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
