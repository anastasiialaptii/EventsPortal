import { Injectable } from '@angular/core';

declare let ga: Function;

@Injectable({
    providedIn: 'root'
})

export class GoogleAnalytics{

    createVisit(){
        ga('send', 'event', 'CreateVisit', 'POST');
    }

    homeClick(){
        ga('send', 'event', 'homeClick', 'homeClick');
    }

    homePage(){
        ga('send', 'event', 'homePage', 'homePage', 'homePage', {
            nonInteraction: true
          });
        }
}