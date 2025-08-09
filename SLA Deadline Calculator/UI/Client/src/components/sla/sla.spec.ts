import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SlaComponent } from './sla';

describe('Sla', () => {
  let component: SlaComponent;
  let fixture: ComponentFixture<SlaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SlaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SlaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
