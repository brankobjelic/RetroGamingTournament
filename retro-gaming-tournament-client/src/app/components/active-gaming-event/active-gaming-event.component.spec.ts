import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveGamingEventComponent } from './active-gaming-event.component';

describe('ActiveGamingEventComponent', () => {
  let component: ActiveGamingEventComponent;
  let fixture: ComponentFixture<ActiveGamingEventComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ActiveGamingEventComponent]
    });
    fixture = TestBed.createComponent(ActiveGamingEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
