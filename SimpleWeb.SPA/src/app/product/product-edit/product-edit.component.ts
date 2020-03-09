import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Location } from '@angular/common';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  @ViewChild('editForm', { static: true }) editForm: NgForm;
  product: any;
  baseUrl = environment.apiUrl;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }
  constructor(private http: HttpClient, private route: ActivatedRoute,
              private location: Location, private router: Router) {
    this.product = {
      name: '',
      price: null
    };
  }

  ngOnInit() {
    this.http.get(this.baseUrl + 'getproductbyid/' + this.route.snapshot.params.id).subscribe(response => {
      this.product = response;
    }, error => {
      console.log(error);
    });
  }

  updateProduct() {
    this.http.put(this.baseUrl + 'updateproduct', this.product).subscribe(next => {
      this.editForm.reset();
    }, error => {
      console.log(error);
    });
    this.router.navigateByUrl('/getlist');
  }

}
