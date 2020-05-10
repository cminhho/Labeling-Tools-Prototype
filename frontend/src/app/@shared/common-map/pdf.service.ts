import { Injectable } from '@angular/core';
import { constants } from './constant';
import * as pdfjsLib from 'pdfjs-dist';

export interface ICanvasState {
  imageUri: string;
  imageWidth: number;
  imageHeight: number;
  numPages: number;
  currentPage: number;
  ocr: any;
  ocrForCurrentPage: any;
  pdfFile: any;
  tiffImages: any[];
  isError: boolean;
  errorTitle?: string;
  errorMessage: string;
  layers: any;
  tableIconTooltip: any;
  hoveringFeature: string;
}


@Injectable({ providedIn: 'root' })
export class PdfService {

  state: ICanvasState;

  constructor() {
    let pdfWorkerSrc: string;
    if (window.hasOwnProperty('pdfWorkerSrc') && typeof (window as any).pdfWorkerSrc === 'string' && (window as any).pdfWorkerSrc) {
      pdfWorkerSrc = (window as any).pdfWorkerSrc;
    } else {
      pdfWorkerSrc = `https://cdnjs.cloudflare.com/ajax/libs/pdf.js/${(pdfjsLib as any).version}/pdf.worker.min.js`;
    }
    (pdfjsLib as any).GlobalWorkerOptions.workerSrc = pdfWorkerSrc;

    this.state = {
      imageUri: null,
      imageWidth: 1024,
      imageHeight: 768,
      numPages: 1,
      currentPage: 1,
      ocr: null,
      ocrForCurrentPage: {},
      pdfFile: null,
      tiffImages: [],
      isError: false,
      errorMessage: 'undefined',
      layers: { text: true, tables: true, checkboxes: true, label: true },
      tableIconTooltip: {
        display: 'none',
        width: 0,
        height: 0,
        top: 0,
        left: 0,
      },
      hoveringFeature: null,
    };

  }

  loadImage = async (path: string) => {
    await this.loadPdfFile(path);
    return this.state;
  }

  private loadPdfFile = async (url: any) => {
    try {
      const pdf = await pdfjsLib.getDocument(url).promise;
      // Fetch current page
      return await this.loadPdfPage(pdf, 1);
    } catch (reason) {
      // PDF loading error
      console.error(reason);
    }
  };

  private loadPdfPage = async (pdf: any, pageNumber: any) => {
    const page = await pdf.getPage(pageNumber);
    const defaultScale = 2;
    const viewport = page.getViewport({ scale: defaultScale });

    // Prepare canvas using PDF page dimensions
    const canvas = document.createElement('canvas');
    const context = canvas.getContext('2d');
    canvas.height = viewport.height;
    canvas.width = viewport.width;

    // Render PDF page into canvas context
    const renderContext = {
      canvasContext: context,
      viewport,
    };

    await page.render(renderContext).promise;

    this.state.imageUri = canvas.toDataURL(
      constants.convertedImageFormat,
      constants.convertedImageQuality,
    );
    this.state.imageWidth = canvas.width;
    this.state.imageHeight = canvas.height;
    this.state.numPages = pdf.numPages;
    this.state.currentPage = pageNumber;
    this.state.pdfFile = pdf;
    return this.state;
  };

}
