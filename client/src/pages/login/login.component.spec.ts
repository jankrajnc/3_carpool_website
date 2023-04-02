import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router } from '@angular/router';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let formBuilder: FormBuilder;
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginComponent],
      imports: [ReactiveFormsModule, MatButtonModule, MatToolbarModule, MatCardModule ],
      providers: [
        { provide: FormBuilder, useValue: formBuilder },
        { provide: Router, useValue: router }
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    formBuilder = TestBed.inject(FormBuilder);
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should create a FormGroup with username and password controls', () => {
    expect(component.loginData.controls['username']).toBeTruthy();
    expect(component.loginData.controls['password']).toBeTruthy();
  });

  it('should set required validator on username and password controls', () => {
    expect(component.loginData.controls['username'].hasError('required')).toBeTruthy();
    expect(component.loginData.controls['password'].hasError('required')).toBeTruthy();
  });

  it('should return error message if username is missing', () => {
    component.loginData.controls['password'].setValue('password');
    expect(component.getErrorMessage()).toEqual('Missing username or password.');
  });

  it('should return unknown error message if there is no error', () => {
    expect(component.getErrorMessage()).toEqual('Unknown error.');
  });

  it('should navigate to carpool-group page if loginData is valid', () => {
    spyOn(router, 'navigate');
    component.loginData.controls['username'].setValue('username');
    component.loginData.controls['password'].setValue('password');
    component.login();
    expect(router.navigate).toHaveBeenCalledWith(['../carpool-group']);
  });

  it('should reset loginData when clear() is called', () => {
    spyOn(component.loginData, 'reset');
    component.clear();
    expect(component.loginData.reset).toHaveBeenCalled();
  });

});
