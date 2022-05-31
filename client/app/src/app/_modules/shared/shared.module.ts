import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from 'app/app-routing.module';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { HttpClientModule } from '@angular/common/http';
import { MenuModule } from 'primeng/menu';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { PaginatorModule } from 'primeng/paginator';
import { CalendarModule } from 'primeng/calendar';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { TabMenuModule } from 'primeng/tabmenu';
import { TabViewModule } from 'primeng/tabview';
import { FileUploadModule } from 'primeng/fileupload';
import {ToastModule} from 'primeng/toast';
import {AvatarModule} from 'primeng/avatar';
import { DropdownModule } from 'primeng/dropdown';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgbModule,
    MatCardModule,
    MatButtonModule,
    AppRoutingModule,
    MenuModule,
    DialogModule,
    PaginatorModule,
    CalendarModule,
    TieredMenuModule,
    TabMenuModule,
    TabViewModule,
    FileUploadModule,
    ToastModule,
    AvatarModule,
    DropdownModule,

  ],
  exports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgbModule,
    MatCardModule,
    MatButtonModule,
    AppRoutingModule,
    MenuModule,
    DialogModule,
    CalendarModule,
    PaginatorModule,
    TieredMenuModule,
    InputTextModule,
    ButtonModule,
    PasswordModule,
    TabMenuModule,
    TabViewModule,
    FileUploadModule,
    ToastModule,
    AvatarModule,
    DropdownModule,

  ],
})
export class SharedModule {}
