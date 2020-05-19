import { Component, OnInit } from '@angular/core';
import { QuoteService } from '@app/home/quote.service';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-template-list',
  templateUrl: './template-list.component.html',
  styleUrls: ['./template-list.component.scss'],
})
export class TemplateListComponent implements OnInit {
  qoute: string | undefined;
  isLoading = false;

  constructor(private quoteService: QuoteService, protected activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.isLoading = true;
    this.loadQoute();
  }

  private loadQoute() {
    this.quoteService
      .getRandomQuote({ category: 'dev' })
      .pipe(
        finalize(() => {
          this.isLoading = false;
        })
      )
      .subscribe((qoute: string) => {
        this.qoute = qoute;
      });
  }
}
