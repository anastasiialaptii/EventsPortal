import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './shared/config/auth-provider';

import { EventListComponent } from './event-list/event-list.component';
import { VisitorsListComponent } from './visitors-list/visitors-list.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { HomePageComponent } from './home-page/home-page.component';
import { NotFoundComponent } from './not-found.component';

const routes: Routes = [
  { path: 'event-list', component: EventListComponent, canActivate: [AuthGuard] },
  { path: 'visitors-list/:eventId', component: VisitorsListComponent, canActivate: [AuthGuard] },
  { path: 'create-event', component: CreateEventComponent, canActivate: [AuthGuard] },
  { path: '', component: HomePageComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  declarations:[NotFoundComponent],
  exports: [RouterModule]
})

export class AppRoutingModule { }
