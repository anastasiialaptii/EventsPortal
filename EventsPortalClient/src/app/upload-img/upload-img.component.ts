import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';

import { UploadService } from '../shared/services/upload-service';

@Component({
  selector: 'app-upload-img',
  templateUrl: './upload-img.component.html',
  styles: [
  ]
})

export class UploadImgComponent implements OnInit {
  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(public uploadService: UploadService) { }

  ngOnInit(): void {
  }

  uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.uploadService.UploadImage(formData)
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
        }
      });
  }

  public files: NgxFileDropEntry[] = [];
 
  public dropped(files: NgxFileDropEntry[]) {
    this.files = files;
    for (const droppedFile of files) {
 
      // Is it a file?
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {
 
          // Here you can access the real file
          console.log(droppedFile.relativePath, file);
     const formData = new FormData();

         formData.append('file', file, file.name);
         this.uploadService.UploadImage(formData)
           .subscribe(event => {
             if (event.type === HttpEventType.UploadProgress)
               this.progress = Math.round(100 * event.loaded / event.total);
             else if (event.type === HttpEventType.Response) {
               this.message = 'Upload success.';
               this.onUploadFinished.emit(event.body);
             }
           });
        });
      } else {
        // It was a directory (empty directories are added, otherwise only files)
        const fileEntry = droppedFile.fileEntry as FileSystemDirectoryEntry;
        console.log(droppedFile.relativePath, fileEntry);
      }
    }
  }
 
  public fileOver(event){
    console.log(event);
  }
 
  public fileLeave(event){
    console.log(event);
  }
}
