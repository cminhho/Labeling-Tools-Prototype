export interface IDocumentType {
    id: string;
    name: string;
}
export interface IDocumentTemplate {
    id?: string;
    name?: string;
    type?: IDocumentType;
    modelId?: string;
    totalTrainingDocuments?: number;

    createdBy: string;
}

export enum LabelCategory {
    AbsoluteAndRelativePositions = 'Absolute and relative positions',
    TablePositions = 'table-positions',
}

export enum OcrLabelingCategory {
    originalWithOcr = 'ORIGINAL_WITH_OCR',
    ocr = 'OCR',
    original = 'ORIGINAL'
}