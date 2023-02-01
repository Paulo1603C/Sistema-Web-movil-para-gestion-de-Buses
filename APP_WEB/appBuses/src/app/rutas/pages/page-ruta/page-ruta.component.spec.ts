import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageRutaComponent } from './page-ruta.component';

describe('PageRutaComponent', () => {
  let component: PageRutaComponent;
  let fixture: ComponentFixture<PageRutaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageRutaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageRutaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
