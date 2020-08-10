import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { getAuthServiceConfigs, AuthGuard } from './shared/config/auth-provider';
import { JwPaginationModule } from 'jw-angular-pagination';
import { SocialLoginModule, AuthServiceConfig } from "angular-6-social-login";
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { ConfirmationDialogService } from './confirmation-dialog/confirmation-dialog.service';
import {MatDatepickerModule} from '@angular/material/datepicker';


import { AuthComponent } from './auth/auth.component';
import { AllowedEventListComponent } from './allowed-event-list/allowed-event-list.component';
import { VisitorsListComponent } from './visitors-list/visitors-list.component';
import { UploadImgComponent } from './upload-img/upload-img.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { Configuration } from './shared/config/configuration';
import { HomePageComponent } from './home-page/home-page.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';


@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    AllowedEventListComponent,
    VisitorsListComponent,
    UploadImgComponent,
    CreateEventComponent,
    HomePageComponent,
    ConfirmationDialogComponent
  ],
  imports: [
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule, 
    BrowserModule,
    AppRoutingModule,
    SocialLoginModule,
    HttpClientModule,
    FormsModule, 
    JwPaginationModule, 
    NgbModule,
    BrowserAnimationsModule, 
    ToastrModule.forRoot()
  ],
  providers: [
    MatDatepickerModule,
    AuthGuard, 
    Configuration, 
    ConfirmationDialogService,
    {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    }
  ],
  bootstrap: [AppComponent],
  entryComponents: [ ConfirmationDialogComponent ]
})

export class AppModule { }
