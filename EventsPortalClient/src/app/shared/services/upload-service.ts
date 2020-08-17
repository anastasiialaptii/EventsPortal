import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRoute } from '../config/BaseRoute';

@Injectable({
    providedIn: 'root'
})

export class UploadService {
    
    constructor(private http: HttpClient) { }
    
    UploadImage(formData: FormData){
        return this.http.post(BaseRoute.Upload + '/Upload', formData, {reportProgress: true, observe: 'events'});
    }
}
