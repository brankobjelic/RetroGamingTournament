import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupTypeAScoresComponent } from './form8a.component';

describe('Form8aComponent', () => {
  let component: GroupTypeAScoresComponent;
  let fixture: ComponentFixture<GroupTypeAScoresComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GroupTypeAScoresComponent]
    });
    fixture = TestBed.createComponent(GroupTypeAScoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
