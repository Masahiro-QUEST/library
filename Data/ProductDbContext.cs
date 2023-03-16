using System;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Data
{
    public class ProductDbContext : DbContext
    {
        #region Contructor
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
                : base(options)
        {

        }
        #endregion

        #region Public properties
        public DbSet<Product> Product { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<ReservationHistory> ReservationHistory { get; set; }
        public DbSet<ReservationTemporary> ReservationTemporary { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Private methods
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1001, title = "AI分析でわかった トップ5％社員", author="越川慎司",updated_date=new DateTime(2022,1,23), updated_by="Yamada",tag="IT"},
                new Product { Id = 1002, title = "つくりながら学ぶ！PyTorchによる発展ディープラーニング", author="小川 雄太郎 ",updated_date=new DateTime(2022,1,23), updated_by="Yamada",tag="IT"},
            };
        }
        #endregion
    }
}

