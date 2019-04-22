import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { UploadRoutingModule } from './upload-routing.module';
import { UploadComponent } from './upload/upload.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import {
  MatButtonModule,
  MatSlideToggleModule,
  MatCardModule,
  MatDatepickerModule,
  MatDialogModule,
  MatNativeDateModule,
  MatInputModule,
  MatMenuModule,
  MatSelectModule,
  MatSidenavModule,
  MatSnackBarModule,
  MatFormFieldModule,
  MatGridListModule,
  MatTableModule,
  MatButtonToggleModule,
  MatIconModule,
  MatPaginatorModule
} from '@angular/material';

@NgModule({
  declarations: [UploadComponent],
  imports: [
    CommonModule,
    UploadRoutingModule,
    MatButtonModule,
    MatSlideToggleModule,
    MatCardModule,
    MatDatepickerModule,
    MatDialogModule,
    MatNativeDateModule,
    MatInputModule,
    MatMenuModule,
    MatSelectModule,
    MatSidenavModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatGridListModule,
    MatTableModule,
    MatButtonToggleModule,
    MatIconModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatDividerModule,
    FormsModule,
    MatProgressSpinnerModule
  ]
})
export class UploadModule { }
