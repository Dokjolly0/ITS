import { Component } from '@angular/core';
import { CART } from './cart';
import {
  getDiscountAmount,
  getDiscountedPrice,
  getPrice,
  getVAT,
  parseItem,
} from './cart-utils';
import { CartItem } from './cart-item.entity';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  items = CART;
  //price = getPrice(this.item.netPrice, 0.22);
  vat = getVAT('IT');
  //calculateItem = parseItem(this.item, this.vat);
}
