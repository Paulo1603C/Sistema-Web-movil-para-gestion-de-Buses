import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FrequenciesComponent } from './frequencies.component';

describe('FrequenciesComponent', () => {
  let component: FrequenciesComponent;
  let fixture: ComponentFixture<FrequenciesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FrequenciesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FrequenciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
