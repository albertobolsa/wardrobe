import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { environment } from "../environments/environment";
import 'rxjs/add/operator/map';

@Injectable()
export class ImageService {

    constructor(private http: Http) { }

    uploadAndLinkFiles(clothingItemId: string, fileList: FileList) {

        if (fileList.length > 0) {

            let file: File = fileList[0];
            let formData: FormData = new FormData();
            formData.append('uploadFile', file, file.name);
            formData.append('clothingItemId', clothingItemId);

            let headers = new Headers();
            let options = new RequestOptions({ headers: headers });
            return this.http.post(environment.serviceUrl + 'Image/Link/' + clothingItemId, formData, options).map(res => res.json()).catch (error => Observable.throw(error))
                .subscribe(
                    data => console.log('success'),
                    error => console.log(error)
                );
        }
    };

    unlinkImage(imageId: string, clothingItemId: string) {

        let formData: FormData = new FormData();
        formData.append('clothingItemId', clothingItemId);
        formData.append('imageId', imageId);

        console.dir(formData);

        let headers = new Headers();
        let options = new RequestOptions({ headers: headers });
        return this.http.post(environment.serviceUrl + 'Image/Unlink', formData, options).map(res => res.json()).catch(error => Observable.throw(error))
            .subscribe(
                data => console.log('success'),
                error => console.log(error)
            );
    };
}