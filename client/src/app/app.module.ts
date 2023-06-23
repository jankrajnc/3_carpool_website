import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MaterialModule} from '../assets/material.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component'
import { LoginComponent } from '../pages/login/login.component';
import { CarpoolGroupComponent } from '../pages/carpool-group/carpool-group.component';

import { DeletionDialogComponent } from '../components/dialogs/deletion-dialog/deletion-dialog.component';
import { CarpoolEntryDialogComponent } from '../components/dialogs/carpool-entry-dialog/carpool-entry-dialog.component';

import { CarpoolEntryApi } from '../apis/lib/openapi_client/api';



@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    LoginComponent,
    CarpoolGroupComponent,
    DeletionDialogComponent,
    CarpoolEntryDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    CarpoolEntryApi
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
