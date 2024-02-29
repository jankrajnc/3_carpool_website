import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DataConverterModule } from './data-converter.module';

describe('DataConverterModule', () => {
  let component: DataConverterModule;
  let fixture: ComponentFixture<DataConverterModule>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataConverterModule ],
    })
    .compileComponents();

    fixture = TestBed.createComponent(DataConverterModule);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

});
