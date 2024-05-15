import PRODUCTS from "../../../products.json";
import { Product } from "./product.entity";
import { ProductModel } from "./product.model";

export class ProductService {
  async find(query: any): Promise<Product[]> {
    const q: any = {};

    if (query.name) {
      q.name = { $regex: new RegExp(`${query.name}`, "i") };
    }

    if (query.minPrice !== undefined || query.maxPrice !== undefined) {
      q.netPrice = {};
    }

    if (query.minPrice) {
      q.netPrice["$gte"] = query.minPrice;
    }

    if (query.maxPrice) {
      q.netPrice["$lte"] = query.maxPrice;
    }

    const results = await ProductModel.find(q);
    return results;
    // let results = PRODUCTS;

    // if (search) {
    //   // logica per filtrare
    //   results = PRODUCTS.filter((item) => {
    //     return item.name.toLowerCase().includes(search.toLowerCase());
    //   });
    // }
    // return results;
  }

  async getById(id: string): Promise<Product | null> {
    return ProductModel.findById(id);
    // return PRODUCTS.find((item) => {
    //   return item.id === id;
    // });
  }
}

export default new ProductService();
