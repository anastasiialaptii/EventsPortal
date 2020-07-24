import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { getAuthServiceConfigs } from './shared/config/auth-provider'


import { SocialLoginModule, AuthServiceConfig } from "angular-6-social-login";
import { AuthComponent } from './auth/auth.component';
import { PublicEventListComponent } from './public-event-list/public-event-list.component';


@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    PublicEventListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SocialLoginModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }