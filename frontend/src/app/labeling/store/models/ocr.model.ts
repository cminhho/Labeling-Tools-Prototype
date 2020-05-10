/**
 * @name - Bounding Box
 * @description - Defines the tag usage within a bounding box region
 * @member left - Defines the left x boundary for the start of the bounding box
 * @member top - Defines the top y boundary for the start of the boudning box
 * @member width - Defines the width of the bounding box
 * @member height - Defines the height of the bounding box
 */
export interface IBoundingBox {
    left: number;
    top: number;
    width: number;
    height: number;
  }
  
  /**
   * @name - Point
   * @description - Defines a point / coordinate within a region
   * @member x - The x value relative to the asset
   * @member y - The y value relative to the asset
   */
  export interface IPoint {
    x: number;
    y: number;
  }
  
  /**
   * @name - Asset Type
   * @description - Defines the type of asset within a project
   * @member Image - Specifies an asset as an image
   * @member PDF - Specifies an asset as a PDF
   * @member TIFF - Specifies an asset as a TIFF image
   */
  export enum AssetType {
    Unknown = 0,
    Image = 1,
    PDF = 5,
    TIFF = 6,
  }
  
  /**
   * @name - ILabelData
   * @description - Defines a label data correspond to an asset
   */
  export interface ILabelData {
    document: string;
    labels: ILabel[];
  }
  
  /**
   * @name - ILabel
   * @description - Defines a label
   */
  export interface ILabel {
    label: string;
    key?: IFormRegion[];
    value: IFormRegion[];
  }
  
  /**
   * @name - IFormRegion
   * @description - Defines a region which consumed by FormRecognizer
   */
  export interface IFormRegion {
    page: number;
    text: string;
    boundingBoxes: [number[]];
  }
  
  /**
   * @name - Asset Metadata
   * @description - Format to store asset metadata for each asset within a project
   * @member asset - References an asset within the project
   * @member regions - The list of regions drawn on the asset
   */
  export interface IAssetMetadata {
    asset: IAsset;
    regions: any[];
    version: string;
    labelData: ILabelData;
  }
  
  export enum FeatureCategory {
    Text = 'text',
    Checkbox = 'checkbox',
    Label = 'label',
  }
  
  export interface IAsset {
    id: string;
    type: AssetType;
    state: any;
    name: string;
    path: string;
    size: any;
    format?: string;
    timestamp?: number;
    predicted?: boolean;
    ocr?: any;
    isRunningOCR?: boolean;
    cachedImage?: string;
  }
  
  /**
   * @name - Tag
   * @description - Defines the structure of a tag
   * @member name - User defined name
   * @member color - User editable color associated to tag
   */
  export interface ITag {
    name: string;
    color: string;
    type: FieldType;
    format: FieldFormat;
  }
  
  export enum FieldType {
    String = 'string',
    Number = 'number',
    Date = 'date',
    Time = 'time',
    Integer = 'integer',
    Checkbox = 'checkbox',
  }
  export enum FieldFormat {
    NotSpecified = 'not-specified',
    Currency = 'currency',
    Decimal = 'decimal',
    DecimalCommaSeparated = 'decimal-comma-seperated',
    NoWhiteSpaces = 'no-whitespaces',
    Alphanumeric = 'alphanumeric',
    DMY = 'dmy',
    MDY = 'mdy',
    YMD = 'ymd',
  }
  