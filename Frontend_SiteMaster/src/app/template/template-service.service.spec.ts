import { TestBed } from '@angular/core/testing';

import { TemplateServiceService } from './template-service.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Type } from '@angular/core';

describe('TemplateServiceService', () => {
  let service: TemplateServiceService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TemplateServiceService],
    });
    service = TestBed.inject(TemplateServiceService);
    httpMock = TestBed.inject(HttpTestingController as Type<HttpTestingController>);
  });

  it('should return a list of Templates', () => {
    // GIVEN
    const returnedFromService = [
      {
        name: 'template 1',
      },
    ];

    // WHEN
    const queryTemplatesSubscription = service.query();

    // THEN
    queryTemplatesSubscription.subscribe((resp: any) => {
      expect(resp.body).toEqual(returnedFromService);
    });
    httpMock.expectOne({ method: 'GET' }).flush(returnedFromService);
    httpMock.verify();
  });
});
