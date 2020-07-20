import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';


const routes: Routes = [
    { path: '', redirectTo: '/components/home', pathMatch: 'full' },
    {
      path: 'first', component: HomeComponent,
      children: [
        { path: 'login', component: LoginComponent } ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }