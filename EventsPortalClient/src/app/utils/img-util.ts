import { ToastrService } from 'ngx-toastr';
import { Configuration } from '../shared/config/configuration';
import { HttpEventType } from '@angular/common/http';
import { EventService } from '../shared/services/event-service';

export class ImgUtil {
    response;

    constructor(
        public toastr: ToastrService,
        public eventService: EventService) { }

    getImage = (serverPath: string) => {
        return `${Configuration.localhost}/${serverPath}`;
    }

    downloadImg(files) {
        if (files.length === 0) {
            this.toastr.error('Image spot is empty!', 'Error');
            return;
        }
        let fileToUpload = <File>files[0];
        if (fileToUpload.type.match(/image\/*/) == null) {
            this.toastr.error('Only images are supported', 'Error');
            return;
        }
        const formData = new FormData();
        formData.append('file', fileToUpload, fileToUpload.name);
        return formData;
    }

    createImgPath(event) {
        if (event.type === HttpEventType.Response) {
            this.response = event.body;
            this.eventService.FormData.ImageURI = this.response.dbPath;
            return true;
        }
    }
}
