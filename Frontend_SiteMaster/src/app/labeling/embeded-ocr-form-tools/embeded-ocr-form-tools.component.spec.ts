import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmbededOcrFormToolsComponent } from './embeded-ocr-form-tools.component';

describe('EmbededOcrFormToolsComponent', () => {
  let component: EmbededOcrFormToolsComponent;
  let fixture: ComponentFixture<EmbededOcrFormToolsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmbededOcrFormToolsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmbededOcrFormToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
