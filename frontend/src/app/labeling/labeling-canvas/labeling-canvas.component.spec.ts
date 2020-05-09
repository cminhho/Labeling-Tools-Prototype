import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LabelingCanvasComponent } from './labeling-canvas.component';

describe('LabelingCanvasComponent', () => {
  let component: LabelingCanvasComponent;
  let fixture: ComponentFixture<LabelingCanvasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [LabelingCanvasComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LabelingCanvasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
