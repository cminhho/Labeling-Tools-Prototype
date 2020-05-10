import { Component, OnInit, ViewChild, NgZone } from '@angular/core';
import { InteractionComponent } from '@app/@shared/common-map/interactions/interaction.component';
import { PdfService } from '@app/@shared/common-map/pdf.service';
import { LabelCategory, OcrLabelingCategory } from '../store/models/document-template.model';
import { IAsset, IAssetMetadata, ILabel } from '../store/models/ocr.model';

export interface IEditorPageState {
  /** Array of assets in project */
  assets: IAsset[];
  /** The editor mode to set for canvas tools */
  editorMode: any;
  /** The selected asset for the primary editing experience */
  selectedAsset?: IAssetMetadata;
  /** Currently selected region on current asset */
  selectedRegions?: any[];
  /** Most recently selected tag */
  selectedTag: string;
  /** Tags locked for region labeling */
  lockedTags: string[];
  /** Size of the asset thumbnails to display in the side bar */
  thumbnailSize: any;
  /**
   * Whether or not the editor is in a valid state
   * State is invalid when a region has not been tagged
   */
  isValid: boolean;
  /** Whether the show invalid region warning alert should display */
  showInvalidRegionWarning: boolean;
  /** Show tags when loaded */
  tagsLoaded: boolean;
  /** The currently hovered TagInputItemLabel */
  hoveredLabel: ILabel;
  /** Whether the task for loading all OCRs is running */
  isRunningOCRs?: boolean;
  /** Whether OCR is running in the main canvas */
  isCanvasRunningOCR?: boolean;
  isError?: boolean;
  errorTitle?: string;
  errorMessage?: string;
}


@Component({
  selector: 'app-editor-page',
  templateUrl: './editor-page.component.html',
  styleUrls: ['./editor-page.component.scss'],
})
export class EditorPageComponent implements OnInit {

  state: IEditorPageState = {
    selectedTag: null,
    lockedTags: [],
    assets: [],
    editorMode: 2,
    thumbnailSize: { width: 175, height: 155 },
    isValid: true,
    showInvalidRegionWarning: false,
    tagsLoaded: false,
    hoveredLabel: null,
  };

  imageUri: string;
  /**
   * Instance of interactionMap
   */
  @ViewChild('interactionMap') interactionMap: InteractionComponent;

  selectedOcrLabelingType: OcrLabelingCategory = OcrLabelingCategory.originalWithOcr;
  selectedTypeOfLabel: LabelCategory = LabelCategory.AbsoluteAndRelativePositions;

  labelCategory: any;
  ocrLabelingCategory: any;

  constructor(
    private pdfService: PdfService,
    private ngZone: NgZone, ) { }

  ngOnInit(): void {
    this.ocrLabelingCategory = OcrLabelingCategory;
    this.labelCategory = LabelCategory;

    this.ngZone.run(async () => {
      const path = 'https://cminhho.blob.core.windows.net/pdf/pdf-invoice-sample_1.pdf';
      const state = await this.pdfService.loadImage(path);
      this.imageUri = state.imageUri;
    });

  }

  draw(drawType: string) {
    this.interactionMap.addInteractions(drawType);
  }

  loadOCR() {

  }

  changeOcrLabelingType(selectedOcrLabelingType: OcrLabelingCategory) {
    this.selectedOcrLabelingType = selectedOcrLabelingType;
    this.selectedTypeOfLabel = LabelCategory.AbsoluteAndRelativePositions;
    // this.store.dispatch(new SetOCRLablingType(selectedOcrLabelingType)).subscribe(() => {});
  }

  clear() {
    this.interactionMap.removeInteractions();
  }
}
