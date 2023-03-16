import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component'
import { LoginComponent } from '../pages/login/login.component';
import { CarpoolGroupComponent } from '../pages/carpool-group/carpool-group.component';

import {MaterialModule} from '../assets/material.module';



@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    LoginComponent,
    CarpoolGroupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
