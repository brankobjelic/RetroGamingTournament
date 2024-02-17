import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupResultsFormComponent } from './group-results-form.component';

describe('GroupResultsFormComponent', () => {
  let component: GroupResultsFormComponent;
  let fixture: ComponentFixture<GroupResultsFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GroupResultsFormComponent]
    });
    fixture = TestBed.createComponent(GroupResultsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
