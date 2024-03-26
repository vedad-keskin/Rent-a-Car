import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {AutentifikacijaToken} from "../helpers/auth/AutentifikacijaToken";

@Injectable({providedIn: 'root'})
export class MyAuthService{
  constructor(private httpClient: HttpClient) {
  }
  jelLogiran():boolean{
    return this.getAuthorizationToken() != null;
  }

  nijelLogiran():boolean{
    return this.getAuthorizationToken() == null;
  }
  nijelLogiran2():boolean{
    let token = window.localStorage.getItem("my-auth-token");

    return token == "";
  }

  returnId() {
    return this.getAuthorizationToken()?.korisnickiNalog.id;
  }

  getAuthorizationToken():AutentifikacijaToken | null {
    let tokenString = window.localStorage.getItem("my-auth-token")??"";
    try {
      return JSON.parse(tokenString);
    }
    catch (e){
      return null;
    }
  }

  setLogiraniKorisnik(x: AutentifikacijaToken | null) {

    if (x == null){
      window.localStorage.setItem("my-auth-token", '');
    }
    else {
      window.localStorage.setItem("my-auth-token", JSON.stringify(x));
    }
  }



}
