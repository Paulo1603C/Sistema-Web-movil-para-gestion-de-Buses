import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageAsientoComponent } from './page-asiento.component';

describe('PageAsientoComponent', () => {
  let component: PageAsientoComponent;
  let fixture: ComponentFixture<PageAsientoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageAsientoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageAsientoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
