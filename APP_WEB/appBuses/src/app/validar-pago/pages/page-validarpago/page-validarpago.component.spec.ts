import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageValidarpagoComponent } from './page-validarpago.component';

describe('PageValidarpagoComponent', () => {
  let component: PageValidarpagoComponent;
  let fixture: ComponentFixture<PageValidarpagoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageValidarpagoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageValidarpagoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
