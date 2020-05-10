import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-embeded-ocr-form-tools',
  templateUrl: './embeded-ocr-form-tools.component.html',
  styleUrls: ['./embeded-ocr-form-tools.component.scss']
})
export class EmbededOcrFormToolsComponent implements AfterViewInit {

  ocrFormToolLink: string;
  
  @ViewChild('iframe') iframe: ElementRef
  
  constructor(public sanitizer: DomSanitizer) { }

  ngAfterViewInit() {
    this.ocrFormToolLink = 'https://fott.azurewebsites.net/';
    this.iframe.nativeElement.setAttribute('src', this.ocrFormToolLink);
   }
}
