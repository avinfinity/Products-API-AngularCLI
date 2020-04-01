import { Component, OnInit } from '@angular/core';
import { Observable, from } from 'rxjs';

import { Product } from 'src/product';
import { ProductService } from '../Services/product.service';
import { async } from '@angular/core/testing';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  allProducts: Product[] = [];
  categories: string[] = [];

  constructor(private productService: ProductService) {
  }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProducts()
      .subscribe(x => this.allProducts = x);
    this.productService.getCategories()
      .subscribe(x => this.categories = x);
  }

  deleteProduct(product: Product) {
    this.productService.deleteProduct(product.id).subscribe(deleted => {
      if (deleted) {
        this.allProducts.forEach((item, index) => {
          if (item === product) {
            this.allProducts = this.allProducts.filter(x => x !== product);
          }
        });
      }
    });
  }

  filterForSelectedCategory(category: string) {
    if (category !== "0") {
      this.productService.getProductsForCategory(category)
        .subscribe(x => this.allProducts = x);
    }
    else {
      this.productService.getProducts()
        .subscribe(x => this.allProducts = x);
    }
  }

  updateProduct(product: Product) {
    const seq = this.productService.updateProduct(product);
    seq.subscribe(x => console.log(x));
  }
}
