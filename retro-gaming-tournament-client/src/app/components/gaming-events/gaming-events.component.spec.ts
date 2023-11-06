import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamingEventsComponent } from './gaming-events.component';

describe('GamingEventsComponent', () => {
  let component: GamingEventsComponent;
  let fixture: ComponentFixture<GamingEventsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GamingEventsComponent]
    });
    fixture = TestBed.createComponent(GamingEventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
