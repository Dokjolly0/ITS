import { cart } from "./cart.js";
import { parseItem } from "./cart-utils.js";
import { calculateItem, template } from "./template.js";

function updateSummary() {
  const summary = document.querySelector(".order-summary");
  const total = 2500;
  summary.querySelector(".netTotal").innerHTML = `${total}`;
}
const list = document.querySelector("#items-list");
for (let item of cart) {
  const vat = 0.22;
  const CalculateItem = calculateItem;
  const Template = template;
  const tmpElement = document.createElement("div");
  tmpElement.innerHTML = Template.trim();
  const element = tmpElement.firstChild;
  console.log(element);
  list.appendChild(element);
}
