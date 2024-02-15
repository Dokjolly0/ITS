import PRODUCTS from "../../../prodotti.json";

export function find(search?: string) {
  let results = PRODUCTS;

  if (search) {
    results = PRODUCTS.filter((item) => {
      return item.name.toLowerCase().includes(search.toLowerCase());
    });
  }
  return results;
}
