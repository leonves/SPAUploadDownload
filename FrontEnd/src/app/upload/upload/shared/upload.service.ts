import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpRequest, HttpEvent } from '@angular/common/http';

import { URL } from '../../../app.constants';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  constructor(private http: HttpClient) { }

  getFiles(): Observable<any> {
    return this.http.get(URL.API + "file/GetAllUploads");
  }

  
  uploadFile(file: any): Observable<HttpEvent<any>> {
    const formData: FormData = new FormData();
    formData.append('File', file);

    const req = new HttpRequest('POST', URL.API + "file/UploadFile", formData, {
      reportProgress: true
    });
    return this.http.request(req);
  }

  downloadFile(filename): Observable<any> {
    return this.http.get(URL.API + "file/Generate/" + filename, { responseType: 'blob' });
  }
}
