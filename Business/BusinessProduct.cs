using Data;


namespace Business
{
    public class BusinessProduct
    {   
        DataProduct dataProduct = new DataProduct();

        public List<Product> ListProducts()
        { 
            return dataProduct.ListProducts();
        }

        public void InsertProduct(Product product)
        {
            dataProduct.InsertProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            dataProduct.UpdateProduct(product);
        }
    }
}
