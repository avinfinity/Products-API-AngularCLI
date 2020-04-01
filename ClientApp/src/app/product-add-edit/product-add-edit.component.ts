import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import {Product} from 'src/product';
import {ProductService} from '../Services/product.service';

@Component({
  selector: 'app-product-add-edit',
  templateUrl: './product-add-edit.component.html',
  styleUrls: ['./product-add-edit.component.scss']
})
export class ProductAddEditComponent implements OnInit {

  id: number;
  operationType: string;
  errorMessage: any;
  existingProduct: Product;
  categories: string[];
  isSubmitted: boolean;

  constructor(private productService: ProductService, private avRoute: ActivatedRoute, private router: Router) {
    const idParam = 'id';

    if (this.avRoute.snapshot.params[idParam]) {
      this.id = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.productService.getCategories().subscribe(x => this.categories = x);
    if (this.id > 0) {
      this.operationType = 'Edit';
      this.productService.getProduct(this.id)
        .subscribe(data => {
          this.existingProduct = data;
        }, error => {
          this.isSubmitted = true;
          alert('Not a valid product to edit : ' + error);
          this.router.navigate(['/']);
        });
    }
    else
    {
      this.operationType = 'Add';
      this.existingProduct = new Product();
    }
  }

  save() {
    this.isSubmitted = true;
    if (this.operationType === 'Edit') {
      this.productService.updateProduct(this.existingProduct)
        .subscribe(status => {
          if (status)
          {
            alert('Modifications are saved succesfully');
            this.router.navigate(['/']);
          }
        });
    }
    else {
      this.productService.addProduct(this.existingProduct).subscribe(status => {
        if (status) {
          alert('Product added successfully');
          this.router.navigate(['/']);
        }
      });
    }

  }

    cancel() {
    this.isSubmitted = true;
    this.router.navigate(['/']);
  }
}
