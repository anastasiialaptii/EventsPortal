import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxFileDropModule } from 'ngx-file-drop';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { getAuthServiceConfigs, AuthGuard } from './shared/config/auth-provider';
import { JwPaginationModule } from 'jw-angular-pagination';
import { SocialLoginModule, AuthServiceConfig } from "angular-6-social-login";
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { ConfirmationDialogService } from './confirmation-dialog/confirmation-dialog.service';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { AuthComponent } from './auth/auth.component';
import { EventListComponent } from './event-list/event-list.component';
import { VisitorsListComponent } from './visitors-list/visitors-list.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { Configuration } from './shared/config/configuration';
import { BaseRoute } from './shared/config/BaseRoute';
import {ImgUtil} from './utils/img-util';
import { HomePageComponent } from './home-page/home-page.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HttpRequestInterceptor } from '../app/shared/config/HttpRequestInterceptor';
import { EventValidator } from './utils/event-validator';
import { EventHelper } from './utils/event-helper';
import {NgsRevealModule} from 'ngx-scrollreveal';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    EventListComponent,
    VisitorsListComponent,
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
    ToastrModule.forRoot(),
    NgxFileDropModule,
    [NgsRevealModule]
  ],
  providers: [
    MatDatepickerModule,
    AuthGuard,
    Configuration,
    BaseRoute,
    ImgUtil,
    EventHelper,
    EventValidator,
    ConfirmationDialogService,
    {
      provide: AuthServiceConfig,
      useFactory: getAuthServiceConfigs
    },
    [
      { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true }
    ]
  ],
  bootstrap: [AppComponent],
  entryComponents: [ConfirmationDialogComponent]
})

export class AppModule { }
