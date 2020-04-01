import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductService } from '../services/product.service';
import { Product } from 'src/product';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  product$: Observable<Product>;
  id: number;

  constructor(private productService: ProductService, private avRoute: ActivatedRoute){
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]){
      this.id = this.avRoute.snapshot.params[idParam];
    }

  }

  ngOnInit(): void {
    this.loadProduct();
  }

loadProduct() {
    this.product$ = this.productService.getProduct(this.id);
  }
}
