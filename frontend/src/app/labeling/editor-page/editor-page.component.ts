import { Component, OnInit, ViewChild, NgZone } from '@angular/core';
import { InteractionComponent } from '@app/@shared/map/interaction/interaction.component';
import { PdfService } from '@app/@shared/map/pdf.service';

@Component({
  selector: 'app-editor-page',
  templateUrl: './editor-page.component.html',
  styleUrls: ['./editor-page.component.scss'],
})
export class EditorPageComponent implements OnInit {
  imageUri: string;
  /**
   * Instance of interactionMap
   */
  @ViewChild('interactionMap') interactionMap: InteractionComponent;

  constructor(
    private pdfService: PdfService,
    private ngZone: NgZone, ) { }

  ngOnInit(): void {
    this.ngZone.run(async () => {
      const path = 'https://cminhho.blob.core.windows.net/pdf/pdf-invoice-sample_1.pdf';
      const state = await this.pdfService.loadImage(path);
      this.imageUri = state.imageUri;
    });

  }

  draw(drawType: string) {
    this.interactionMap.addInteractions(drawType);
  }
  clear() {
    this.interactionMap.removeInteractions();
  }
}
