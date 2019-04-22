import { Component, OnInit, ViewChild } from '@angular/core';
import { File } from '../upload/shared/file.model';
import { MatPaginator, MatTableDataSource, MatSort, MatTable } from '@angular/material';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UploadService } from './shared/upload.service';
import { HttpEventType } from '@angular/common/http';
import { Router } from "@angular/router";
import { AvisoService } from 'src/app/services/aviso.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {
  message: string;
  constructor(private uploadService: UploadService,
    private router: Router,
    private avisoService: AvisoService) { 
  }

    files: any[];

    displayedColumns: string[] = ['Nome do Arquivo', 'Tamanho do Arquivo', 'Dono do Arquivo', 'Data do upload', 'Opções'];
    isLoading = true;
    dataSource = null;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatTable) matTable: MatTable<any>;

    file: any;
    fileUpload: any;
    fileName: string;
    profileId: number;

    selectFile(file) {
      console.log(file);
    }

    showFile(fileInput) {
      let file = fileInput.target.files[0];
      let fileName = file.name;
      this.fileName = fileName;
      this.fileUpload = file;
    }

  ngAfterViewInit() {
    this.uploadService.getFiles().subscribe(data => {
      this.files = data.data;
      this.isLoading = false;
      this.dataSource = new MatTableDataSource(this.files);
      this.dataSource.paginator = this.paginator;
    }, error => {
      this.avisoService.avisar("Erro ao carregar os arquivos: " + error.message);
    })
  }

  signoff() {
    this.router.navigate(['/login']);
    localStorage.clear();
  }

  ngOnInit() {
    this.files = [];
    if (localStorage.getItem('user')) {
      const user = JSON.parse(localStorage.getItem('user'));
      if (user.email === 'admin@admin.com' && user.password === '123') {
        this.profileId = 1;
      }
    }
  }

  upload() {
    this.isLoading = true;    
    this.uploadService.uploadFile(this.fileUpload).subscribe(
      event => {
        if (event.type === HttpEventType.Response) {
          this.message = event.body.message;
          this.fileName = null;
          this.file = null;
          this.ngAfterViewInit();
          this.avisoService.avisar("Upload realizado");
        }
      },
      error => {
        debugger;
        this.avisoService.avisar(error.message);
      }
    );
  }

  downloadFile(fileName) {
    this.uploadService.downloadFile(fileName).subscribe(
      (response) => {
        const element = document.createElement('a');
        element.href = URL.createObjectURL(response);
        element.download = fileName;
        document.body.appendChild(element);
        element.click();
      },
      (error) => this.avisoService.avisar(error.message)
    );
  }
}
