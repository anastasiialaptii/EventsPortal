import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { getAuthServiceConfigs, AuthGuard } from './shared/config/auth-provider'


import { SocialLoginModule, AuthServiceConfig } from "angular-6-social-login";
import { AuthComponent } from './auth/auth.component';
import { AllowedEventListComponent } from './allowed-event-list/allowed-event-list.component';
import { PrivateEventListComponent } from './private-event-list/private-event-list.component';
import { JwPaginationModule } from 'jw-angular-pagination';


@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    AllowedEventListComponent,
    PrivateEventListComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SocialLoginModule,
    HttpClientModule,
    FormsModule, JwPaginationModule
  ],
  providers: [
    AuthGuard,
    {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }