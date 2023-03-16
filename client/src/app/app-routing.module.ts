import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component'
import { LoginComponent } from '../pages/login/login.component';
import { CarpoolGroupComponent } from '../pages/carpool-group/carpool-group.component';

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: '', redirectTo: 'carpool-group', pathMatch: 'full' },
      { path: 'carpool-group', component: CarpoolGroupComponent },
      { path: 'login', component: LoginComponent }
    ]
  },

  { path: '**', redirectTo: 'carpool-group' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
