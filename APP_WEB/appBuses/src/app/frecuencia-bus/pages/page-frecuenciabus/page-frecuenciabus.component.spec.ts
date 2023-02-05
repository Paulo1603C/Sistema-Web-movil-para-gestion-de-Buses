import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageFrecuenciabusComponent } from './page-frecuenciabus.component';

describe('PageFrecuenciabusComponent', () => {
  let component: PageFrecuenciabusComponent;
  let fixture: ComponentFixture<PageFrecuenciabusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageFrecuenciabusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageFrecuenciabusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
