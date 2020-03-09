import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Location } from '@angular/common';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  @ViewChild('createForm', { static: true }) createForm: NgForm;
  product: any;
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient, private router: Router, private location: Location) {
    this.product = {
      name: '',
      price: null
    };
   }

  ngOnInit() {

  }

  createProduct() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(this.baseUrl + 'createproduct', this.product, httpOptions).subscribe(next => {
        console.log('Added product: ' + next);
        this.router.navigateByUrl('/updateproduct/' + next);
      }, error => {
        console.log(error);
      });
  }

}

