namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IProductRepository
    {
        ProductModel GetProductById(long id);

        List<ProductModel_Ver2> GetListProductOfTypeByName(int id_type, string keyword, int quantity);

        List<ProductModel_Ver2> GetListProductByTypeAndStatus(int id_type, int id_status, int page, int pageSize);

        int GetProductCountOfTypeAndStatus(int id_type, int id_status);

        List<ProductModel_Ver2> GetListProductBy_TypeAndBrandAndSex(int id_type, int id_brand, int id_sex, int page, int pageSize);

        int GetProductCountOf_TypeAndBrandAndSex(int id_type, int id_brand, int id_sex);

        long? CreateProduct(ProductModel_Ver3 productModel);
    }
}
