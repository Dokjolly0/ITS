import { cart } from "./cart.js";
import { parseItem } from "./cart-utils.js";

function updateSummary() {
  const summary = document.querySelector(".order-summary");
  const total = 2500;
  summary.querySelector(".netTotal").innerHTML = `${total}`;
}

window.onload = function () {
  const list = document.querySelector("#items-list");
  console.log(cart);

  //Tutto quello dentro UL
  list.innerHTML = "";
  for (let item of cart) {
    const vat = 0.22;
    const calculateItem = parseItem(item, vat);
    const template = `<li class="list-group-item item">
    <div
      class="d-flex flex-row d-flex justify-content-between align-items-center"
    >
      <div class="item-name">${calculateItem.name}</div>
  
      <div
        class="d-flex flex-row align-items-center justify-content-end flex-wrap"
      >
        <span class="ms-2 d-flex flex-row align-items-center">
          <label class="me-1" for="quantity">qty:</label>
          <input
            class="form-control item-quantity"
            value="${calculateItem.quantity}"
            type="number"
            style="width: 70px"
          />
        </span>
        <span class="ms-2">
          <span class="item-price">${parseFloat(
            calculateItem.price.toFixed(2)
          )}</span>
          <span class="item-discount">(-${calculateItem.discountAmount}€)</span>
        </span>
      </div>
    </div>
  </li>`;
    const tmpElement = document.createElement("div");
    tmpElement.innerHTML = template.trim();
    const element = tmpElement.firstChild;
    console.log(element);
    list.appendChild(element);
  }
};
