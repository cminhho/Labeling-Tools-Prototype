import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageLayerComponent } from './image-layer.component';

describe('ImageLayerComponent', () => {
  let component: ImageLayerComponent;
  let fixture: ComponentFixture<ImageLayerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ImageLayerComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImageLayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
