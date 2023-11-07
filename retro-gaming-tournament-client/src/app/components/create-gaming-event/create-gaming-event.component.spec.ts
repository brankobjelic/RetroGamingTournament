import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGamingEventComponent } from './create-gaming-event.component';

describe('CreateGamingEventComponent', () => {
  let component: CreateGamingEventComponent;
  let fixture: ComponentFixture<CreateGamingEventComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateGamingEventComponent]
    });
    fixture = TestBed.createComponent(CreateGamingEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
