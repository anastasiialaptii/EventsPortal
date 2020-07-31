import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Configuration } from '../config/configuration';

@Injectable({
    providedIn: 'root'
})

export class UploadService {
    
    constructor(private http: HttpClient) { }
    
    UploadImage(formData: FormData){
        return this.http.post(Configuration.URI + '/Upload/Upload', formData, {reportProgress: true, observe: 'events'});
    }
}