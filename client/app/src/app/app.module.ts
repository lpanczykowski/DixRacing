import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from 'src/app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { EventListComponent } from './events/event-list/event-list.component';
import { DriversComponent } from './drivers/drivers.component';
import { EventBoxComponent } from './events/event-box/event-box.component';
import { JwtInterceptor } from '_interceptors/jwt.interceptor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EventDetailsComponent } from './events/event-details/event-details.component';
import { RaceBoxComponent } from './races/race-box/race-box.component';
import { RaceDetailsComponent } from './races/race-details/race-details.component';
import { DriverListComponent } from './drivers/driver-list/driver-list.component';
import { DriverCardComponent } from './drivers/driver-card/driver-card.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { EventRulesComponent } from './events/event-rules/event-rules.component';
import { EventTeamsComponent } from './events/event-teams/event-teams.component';
import { EventPenaltyComponent } from './events/event-penalty/event-penalty.component';
import { EventPointsComponent } from './events/event-points/event-points.component';
import { EventInfoComponent } from './events/event-info/event-info.component';
import { PaginationModule, PaginationConfig } from 'ngx-bootstrap/pagination';

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

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    NgbModule,
    MatCardModule,
    MatButtonModule,
    PaginationModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    PaginationConfig
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
