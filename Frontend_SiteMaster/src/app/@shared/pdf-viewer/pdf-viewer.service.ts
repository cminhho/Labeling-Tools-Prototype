import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class PdfViewerService {
  constructor() { }

  /* VALIDATION */
  validateNumbers(e: any) {
    const pattern = /[0-9]/;

    const inputChar = String.fromCharCode(e.charCode);

    if (!pattern.test(inputChar)) {
      e.preventDefault();
    }
  }
}
