import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateListComponent } from './template-list.component';
import { SharedModule } from '@app/@shared';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { QuoteService } from '@app/home/quote.service';
import { of } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

const fakeQoute = {
  value: "Chuck Norris doesn't pair program.",
};

fdescribe('TemplateListComponent', () => {
  let component: TemplateListComponent;
  let fixture: ComponentFixture<TemplateListComponent>;
  let service: QuoteService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [SharedModule, HttpClientTestingModule],
      declarations: [TemplateListComponent],
      providers: [
        QuoteService,
        {
          provide: ActivatedRoute,
          useValue: {},
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    service = fixture.debugElement.injector.get(QuoteService);
  });

  it('should create', async () => {
    expect(component).toBeTruthy();
  });

  it('should call load quote on init', () => {
    // GIVEN
    spyOn(service, 'getRandomQuote').and.returnValue(of(fakeQoute.value));

    // WHEN
    component.ngOnInit();

    // THEN
    expect(component.qoute).toEqual(fakeQoute.value);
  });
});
