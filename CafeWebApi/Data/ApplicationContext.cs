using Microsoft.EntityFrameworkCore;

namespace CafeWebApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Breakfast> Breakfasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breakfast>().HasData(
                 new Breakfast[]
                 {
                    new Breakfast { Id=1, Name="Суп", Type = "Мясной", Description = "Суп являются основным первым блюдом любого обеденного комплекса. Каждая кухня мира предлагает множество разнообразных рецептов, которые кардинально отличаются. Это позволяет не только насытить организм, но и разнообразить свой рацион, удовлетворив вкусовые предпочтения даже наиболее изысканных гурманов."},
                    new Breakfast { Id=2, Name="Соус", Type = "Сырный", Description= "Соус (в перевод с французского языка sauce означает «поливку») представляет собой дополнение к блюду/гарниру. С помощью него удается сделать блюдо более привлекательным и повысить его калорийность."},
                    new Breakfast { Id=3, Name="Борщ", Type = "Зеленый", Description = "Одним из наиболее любимых видов первых блюд большинства людей считается борщ."}
                 });
        }
    }
}
