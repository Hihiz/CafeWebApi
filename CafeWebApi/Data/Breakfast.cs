using Microsoft.AspNetCore.Identity;

namespace CafeWebApi.Data
{
    public class Breakfast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeDishId { get; set; }
        public string Description { get; set; }

        public virtual TypeDish TypeDish { get; set; }

    }
}
