import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllowedEventListComponent } from './allowed-event-list/allowed-event-list.component';
import { AuthGuard } from './shared/config/auth-provider';
import { AuthComponent } from './auth/auth.component';


const routes: Routes = [
  { path: 'allowed-event-list', component: AllowedEventListComponent, canActivate: [AuthGuard] },
  { path: '', component: AuthComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
