using Web_Ban_Giay_Asp_Net_Core.Model;
using Web_Ban_Giay_Asp_Net_Core.Models;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IProductRepository
    {
        ProductModel GetProductById(long id);

        List<ProductModel_Part2> GetListProductByName(string keyword, int quantity);
    }
}
