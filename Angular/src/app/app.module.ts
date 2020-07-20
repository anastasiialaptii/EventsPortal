import { AuthGuard } from './auth/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { Cookie } from 'ng2-cookies/ng2-cookies';
import { JwtModule } from "@auth0/angular-jwt";

import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { UserService } from './shared/services/user.service';
import { AppRoutingModule } from './app-routing-module';


import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';


export function tokenGetter() {
  return Cookie.get('Token');
}

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:50618"],
        disallowedRoutes: []
      }
    })
    ],
  declarations: [
    HomeComponent,
    AppComponent,
    LoginComponent
  ],
  providers: [UserService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
