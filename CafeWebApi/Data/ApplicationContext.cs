using Microsoft.EntityFrameworkCore;

namespace CafeWebApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Breakfast> Breakfasts { get; set; }
        public DbSet<TypeDish> TypesDish { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breakfast>().HasData(
                 new Breakfast[]
                 {
                    new Breakfast { Id=1, Name="Суп", TypeDishId = 1, Description = "Суп являются основным первым блюдом любого обеденного комплекса. Каждая кухня мира предлагает множество разнообразных рецептов, которые кардинально отличаются. Это позволяет не только насытить организм, но и разнообразить свой рацион, удовлетворив вкусовые предпочтения даже наиболее изысканных гурманов."},
                    new Breakfast { Id=2, Name="Соус", TypeDishId = 2, Description= "Соус (в перевод с французского языка sauce означает «поливку») представляет собой дополнение к блюду/гарниру. С помощью него удается сделать блюдо более привлекательным и повысить его калорийность."},
                    new Breakfast { Id=3, Name="Борщ", TypeDishId = 3, Description = "Одним из наиболее любимых видов первых блюд большинства людей считается борщ."}
                 });

            modelBuilder.Entity<TypeDish>().HasData(
                new TypeDish[]
                {
                    new TypeDish { Id=1, Name="Мясной" },
                    new TypeDish { Id=2, Name="Сырный" },
                    new TypeDish { Id=3, Name="Зеленый" }
                });

        }
    }
}
