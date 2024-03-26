import {Observable} from "rxjs";

export interface MyBaseEndpoint<TRequest, TResponse>{
  Handle(request: TRequest): Observable<TResponse>;
}
