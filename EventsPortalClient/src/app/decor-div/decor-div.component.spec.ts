import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DecorDivComponent } from './decor-div.component';

describe('DecorDivComponent', () => {
  let component: DecorDivComponent;
  let fixture: ComponentFixture<DecorDivComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DecorDivComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DecorDivComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
