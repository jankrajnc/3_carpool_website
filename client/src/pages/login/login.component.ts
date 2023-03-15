import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private formBuilder: FormBuilder) { }

  public loginData = this.formBuilder.group({
    username: ['', Validators.required],
    password: ['', Validators.required]
  });

  public getErrorMessage() : string {
    if (this.loginData.controls.username.hasError('required')) {
      return 'Missing username or password.';
    } else {
      return 'Unknown error.';
    }

    //return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  public login() {
    if (this.loginData.valid) {
      console.log(this.loginData.value);
    }
  }

  public clear() {
    this.loginData.reset();
  }

  /*private checkFormErrors(errorType : string) : boolean {
    Object.keys(this.loginData.controls).forEach(key => {
      if(this.loginData.controls[key].hasError(errorType)){
        return true;
      };
    });

    return false;
  }*/

  // debug?
  // testing?
  // uporabni vmesniki za VS code
  // kako posodabljati knjiznice

}
