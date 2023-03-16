import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private formBuilder: FormBuilder, private router: Router) { }

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
      this.router.navigate(["../carpool-group"]);
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

  // css, kako se to dobro naucis oz privadis kot programer, ki se s tem veliko ne ukvarja? je to neka stvar s katero se sploh veliko programerjev ukvarja?
  // kako drzis to vso znanje, ko toliko nekih stvari dodajas, plus se enih stvari ne dotaknes nekaj mesecev/let?
  // logika/uporaba interfacov, rad bi razumel kdaj se jih splaca uporabiti, kdaj ne, ker jih uporabljam in razumem kaj so, samo ne vem pa kdaj bi jih samo ustvaril, da bi bili uporabni in ne odvec
  // kako lokalno uravnavati razlicne verzije "globalnih" knjiznic med projekti? recimo angular ali nodejs, ustvaris samo lokalne verzije, varjanta vsak projekt ima svojo verzijo globalne pa nimas?
  // struktura ../carpool-group/[add-group] || [edit-group] || [view-group]
  // najboljsi nacin nalaganja dinamicne vsebine glede na ID? preko argumentov v URL pathu? varjanta [URL]/user/1? ali [URL]/user=1?
  // debug? je vredno debug nastaviti kar v IDE-u ali naj se debuggira kar preko spleta?
  // testing?
  // uporabni vmesniki za VS code
  // kako posodabljati knjiznice

}
