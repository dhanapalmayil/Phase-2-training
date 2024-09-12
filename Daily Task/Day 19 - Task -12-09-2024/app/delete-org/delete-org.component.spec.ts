import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteOrgComponent } from './delete-org.component';

describe('DeleteOrgComponent', () => {
  let component: DeleteOrgComponent;
  let fixture: ComponentFixture<DeleteOrgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteOrgComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteOrgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
