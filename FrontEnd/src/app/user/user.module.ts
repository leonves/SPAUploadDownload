import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { LoginComponent } from './login/login.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FormsModule } from '@angular/forms';

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
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    MatToolbarModule,
    MatDividerModule,
    MatProgressSpinnerModule,
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
    FormsModule
  ]
})
export class UserModule { }
