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
    }
}
