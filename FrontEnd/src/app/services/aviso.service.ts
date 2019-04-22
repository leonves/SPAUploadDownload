import { OnInit, Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';


@Injectable()
export class AvisoService {

  constructor(public toaster: MatSnackBar){}

  avisar(mensagem):void
  {
    this.toaster.open(mensagem, "Fechar", {
      duration: 3000
    });
  }

}
