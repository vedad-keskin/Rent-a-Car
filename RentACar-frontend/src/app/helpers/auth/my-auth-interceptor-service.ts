
import {Injectable} from "@angular/core";
import {HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {MyAuthService} from "../../services/MyAuthService";


@Injectable()
export class MyAuthInterceptor implements HttpInterceptor {

  constructor(private auth: MyAuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {

    const authToken = this.auth.getAuthorizationToken()?.vrijednost??"";

    const authReq = req.clone({
      headers: req.headers.set('my-auth-token', authToken)
    });

    return next.handle(authReq);
  }
}
