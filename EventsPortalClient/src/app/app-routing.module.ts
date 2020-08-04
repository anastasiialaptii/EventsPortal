import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllowedEventListComponent } from './allowed-event-list/allowed-event-list.component';
import { AuthGuard } from './shared/config/auth-provider';
import { VisitorsListComponent } from './visitors-list/visitors-list.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { HomePageComponent } from './home-page/home-page.component';

const routes: Routes = [
  { path: 'allowed-event-list', component: AllowedEventListComponent, canActivate: [AuthGuard] },
  { path: 'visitors-list/:eventId', component: VisitorsListComponent, canActivate: [AuthGuard] },
  { path: 'create-event', component: CreateEventComponent, canActivate: [AuthGuard] },
  { path: '', component: HomePageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
