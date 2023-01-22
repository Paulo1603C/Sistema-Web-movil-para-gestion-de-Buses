import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FrequenciesPageComponent } from './frequencies-page.component';

describe('FrequenciesPageComponent', () => {
  let component: FrequenciesPageComponent;
  let fixture: ComponentFixture<FrequenciesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FrequenciesPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FrequenciesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
