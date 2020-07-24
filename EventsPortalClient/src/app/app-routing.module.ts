import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublicEventListComponent } from './public-event-list/public-event-list.component';
import { AuthGuard } from './shared/config/auth-provider';
import { PrivateEventListComponent } from './private-event-list/private-event-list.component';


const routes: Routes = [
  { path: 'public-event-list', component: PublicEventListComponent, canActivate: [AuthGuard] },
  { path: 'private-event-list', component: PrivateEventListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
