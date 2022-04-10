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
    EventFormComponent
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
  ],

  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
