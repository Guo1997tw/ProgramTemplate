using PractiseWebsite.Repositorys.Models;

namespace PractiseWebsite.Models
{
    public class CategorieModel
    {
        public int categoryId { get; set; }

        public string categoryName { get; set; } = null!;

        public List<ProductModel> product { get; set; }
    }
}