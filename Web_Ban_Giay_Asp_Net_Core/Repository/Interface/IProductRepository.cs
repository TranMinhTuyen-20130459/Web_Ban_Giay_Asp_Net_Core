namespace Web_Ban_Giay_Asp_Net_Core.Repository.Interface
{
    public interface IProductRepository
    {
        ProductModel GetProductById(long id);

        List<ProductModel_Ver2> GetListProductOfTypeByName(int id_type, string keyword, int quantity);

        List<ProductModel_Ver2> GetListProductByTypeAndStatus(int id_type, int id_status, int page, int pageSize);

        int GetProductCountOfTypeAndStatus(int id_type, int id_status);

        List<ProductModel_Ver2> GetListProductBy_TypeAndBrandAndSex(int id_type, int id_brand, int id_sex, int page, int pageSize);

        int GetProductCountOf_TypeAndBrandAndSex(int id_type, int id_brand, int id_sex);

        List<ProductModel_Ver2> GetAllProduct(int page, int pageSize);

        int GetCountAllProduct();

        long? CreateProduct(ProductModel_Ver3 productModel);

        bool UpdateProduct(ProductModel_Ver4 productModel);

        bool DeleteProduct(ProductModel_Ver5 productModel);

    }
}
