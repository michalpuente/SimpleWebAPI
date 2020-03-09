import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  baseUrl = environment.apiUrl;
  products: any;
  constructor(private http: HttpClient, private router: Router, private location: Location) { }

  ngOnInit() {
    this.getProductList();
  }

  getProductList() {
    this.http.get(this.baseUrl + 'getlist').subscribe(response => {
      this.products = response;
    }, error => {
      console.log(error);
    });
  }

  deleteProduct(id: any) {
    this.http.delete(this.baseUrl + 'removeproduct/' + id).subscribe(response => {
      console.log(response);
      this.products = this.products.splice(a => a.id = id);
    }, error => {
      console.log(error);
    });
    window.location.reload();
  }
}
