using Web_Ban_Giay_Asp_Net_Core.Model;
using Web_Ban_Giay_Asp_Net_Core.Models;

namespace Web_Ban_Giay_Asp_Net_Core.Services.Interface
{
    public interface IProductRepository
    {
        ProductModel GetProductById(long id);

        List<ProductModel_Part2> GetListProductOfTypeByName(int id_type, string keyword, int quantity);

        List<ProductModel_Part2> GetListProductByTypeAndStatus(int id_type, int id_status, int page, int pageSize);

        int GetProductCountOfTypeAndStatus(int id_type, int id_status);
    }
}
