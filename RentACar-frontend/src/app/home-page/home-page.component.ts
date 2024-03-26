import {Component, OnInit} from '@angular/core';

import {HttpClient} from "@angular/common/http";
import {Config} from "../Config";



@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit{

  constructor(private httpClient: HttpClient) {

  }

  useri:any;
  drzave:any;

  ngOnInit():void {

    this.GetAllUsers();
    this.GetAllCountries();


  }




  private GetAllUsers() {
    this.httpClient.get(Config.adresa+ "User/GetAllUsers").subscribe(x=>{
      this.useri = x;
    });
  }

  private GetAllCountries() {
    this.httpClient.get(Config.adresa+ "Country/GetAllCountries").subscribe(x=>{
      this.drzave = x;
    });
  }



}
