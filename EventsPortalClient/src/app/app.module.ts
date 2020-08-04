import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { getAuthServiceConfigs, AuthGuard } from './shared/config/auth-provider';

import { SocialLoginModule, AuthServiceConfig } from "angular-6-social-login";
import { AuthComponent } from './auth/auth.component';
import { AllowedEventListComponent } from './allowed-event-list/allowed-event-list.component';
import { JwPaginationModule } from 'jw-angular-pagination';
import { VisitorsListComponent } from './visitors-list/visitors-list.component';
import { UploadImgComponent } from './upload-img/upload-img.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { Configuration } from './shared/config/configuration';
import { HomePageComponent } from './home-page/home-page.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    AllowedEventListComponent,
    VisitorsListComponent,
    UploadImgComponent,
    CreateEventComponent,
    HomePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SocialLoginModule,
    HttpClientModule,
    FormsModule, JwPaginationModule
  ],
  providers: [
    AuthGuard, Configuration,
    {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    }
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
