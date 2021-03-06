import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Product } from 'src/product';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  myAppUrl: string;
  myApiUrl: string;
  myApiCommandUrl: string;

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/products/';
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getProduct(id): Observable<Product> {
    return this.http.get<Product>(this.myAppUrl + this.myApiUrl + id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getCategories(): Observable<string[]> {
    return this.http.get<string[]>(this.myAppUrl + this.myApiUrl + 'categories')
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getProductsForCategory(category: string): Observable<Product[]> {
    return this.http.get<Product[]>(this.myAppUrl + this.myApiUrl + 'cat=' + category)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  deleteProduct(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.myAppUrl + this.myApiUrl + id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  updateProduct(product: Product): Observable<boolean> {

    return this.http.put<boolean>(this.myAppUrl + this.myApiUrl, product)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  addProduct(product: Product): Observable<boolean> {
    return this.http.post<boolean>(this.myAppUrl + this.myApiUrl, product)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
