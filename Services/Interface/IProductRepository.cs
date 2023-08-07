using Web_Ban_Giay_Asp_Net_Core.Model;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IProductRepository
    {
        ProductModel GetProductById(long id);
    }
}
