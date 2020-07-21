import { AuthGuard } from './guards/auth-guard.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AppComponent } from './app.component';
import { Cookie } from 'ng2-cookies/ng2-cookies';
import { JoinPortalComponent } from './join-portal/join-portal.component';
import { EventListComponent } from './event-list/event-list.component';
import { EventComponent } from './event/event.component';

export function tokenGetter() {
  return Cookie.get('Token');
}

@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    AppComponent,
    JoinPortalComponent,
    EventListComponent,
    EventComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: '', component: HomeComponent },  
      { path: 'joinPortal', component: JoinPortalComponent }
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:50618"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
