import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CooperativesPageComponent } from './cooperatives-page.component';

describe('CooperativesPageComponent', () => {
  let component: CooperativesPageComponent;
  let fixture: ComponentFixture<CooperativesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CooperativesPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CooperativesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
