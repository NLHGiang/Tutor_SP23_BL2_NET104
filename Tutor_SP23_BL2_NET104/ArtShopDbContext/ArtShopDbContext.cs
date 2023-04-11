using Microsoft.EntityFrameworkCore;
using Tutor_SP23_BL2_NET104.Configurations;
using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.ArtShopDbContext
{
    public partial class ArtShopContext : DbContext
    {
        public ArtShopContext()
        {
        }

        public ArtShopContext(DbContextOptions<ArtShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBill> ProductBills { get; set; }
        public virtual DbSet<CartDetails> CartDetailses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI\\SQLExpress;Database=Tutor_SP23_BL2_NET104_5;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());

            modelBuilder.ApplyConfiguration(new CartDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductBillConfiguration());

            InsertData(modelBuilder);
        }

        protected void InsertData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.Parse("9871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "Admin",
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Role()
                {
                    Id = Guid.Parse("8871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "Customer",
                    CreatedTime = DateTime.Now,
                    Status = 0
                }
                );

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = Guid.Parse("9871ad42-6960-473d-aa75-aabc6edf5014"),
                    IdRole = Guid.Parse("9871ad42-6960-473d-aa75-aabc6edf5014"),
                    Username = "giangnlh.forworking",
                    Password = "giangnlh.forworking",
                    FullName = "giangnlh.forworking",
                    Email = "giangnlh.forworking@gmail.com",
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new User()
                {
                    Id = Guid.Parse("8871ad42-6960-473d-aa75-aabc6edf5014"),
                    IdRole = Guid.Parse("8871ad42-6960-473d-aa75-aabc6edf5014"),
                    Username = "nlhg090602",
                    Password = "nlhg090602",
                    FullName = "nlhg090602",
                    Email = "nlhg090602@gmail.com",
                    CreatedTime = DateTime.Now,
                    Status = 0
                }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = Guid.Parse("1871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "Tranh Trừu Tượng",
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Category()
                {
                    Id = Guid.Parse("2871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "Tranh Tối Giản",
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Category()
                {
                    Id = Guid.Parse("3871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "Tranh Sơn Dầu",
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Category()
                {
                    Id = Guid.Parse("4871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "Tranh Tĩnh Vật",
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Category()
                {
                    Id = Guid.Parse("5871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "Khác",
                    CreatedTime = DateTime.Now,
                    Status = 0
                });

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = Guid.Parse("9971ad42-6960-473d-aa75-aabc6edf5014"),
                    IdCategory = Guid.Parse("1871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "TRANH TREO TƯỜNG TT01",
                    Image = "https://tuongvip.vn/public/uploads/products/44768/tranh-treo-tuong-nghe-thuat-truu-tuong.jpg",
                    Description = "TRANH TREO TƯỜNG TT01",
                    Amount = 100,
                    Price = 600000,
                    ReducedPrice = 500000,
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Product()
                {
                    Id = Guid.Parse("9071ad42-6960-473d-aa75-aabc6edf5014"),
                    IdCategory = Guid.Parse("1871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "TRANH TREO TƯỜNG TT02",
                    Image = "https://tuongvip.vn/public/uploads/products/44768/tranh-treo-tuong-nghe-thuat-truu-tuong.jpg",
                    Description = "TRANH TREO TƯỜNG TT02",
                    Amount = 100,
                    Price = 600000,
                    ReducedPrice = 500000,
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Product()
                {
                    Id = Guid.Parse("1171ad42-6960-473d-aa75-aabc6edf5014"),
                    IdCategory = Guid.Parse("1871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "TRANH TREO TƯỜNG TG01",
                    Image = "https://tuongvip.vn/public/uploads/products/57505/tranh-treo-tuong-nghe-thuat-hinh-hoc-toi-gian-02.jpg",
                    Description = "TRANH TREO TƯỜNG TG01",
                    Amount = 100,
                    Price = 600000,
                    ReducedPrice = 500000,
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Product()
                {
                    Id = Guid.Parse("1071ad42-6960-473d-aa75-aabc6edf5014"),
                    IdCategory = Guid.Parse("1871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "TRANH TREO TƯỜNG TG02",
                    Image = "https://tuongvip.vn/public/uploads/products/57505/tranh-treo-tuong-nghe-thuat-hinh-hoc-toi-gian-02.jpg",
                    Description = "TRANH TREO TƯỜNG TG02",
                    Amount = 100,
                    Price = 600000,
                    ReducedPrice = 500000,
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Product()
                {
                    Id = Guid.Parse("4471ad42-6960-473d-aa75-aabc6edf5014"),
                    IdCategory = Guid.Parse("4871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "TRANH TREO TƯỜNG SD01",
                    Image = "https://tuongvip.vn/public/uploads/products/59925/tranh-treo-tuong-son-dau-phong-canh-lang-que-dep-11.jpg",
                    Description = "TRANH TREO TƯỜNG SD01",
                    Amount = 100,
                    Price = 600000,
                    ReducedPrice = 500000,
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Product()
                {
                    Id = Guid.Parse("4071ad42-6960-473d-aa75-aabc6edf5014"),
                    IdCategory = Guid.Parse("4871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "TRANH TREO TƯỜNG SD02",
                    Image = "https://tuongvip.vn/public/uploads/products/59925/tranh-treo-tuong-son-dau-phong-canh-lang-que-dep-11.jpg",
                    Description = "TRANH TREO TƯỜNG SD02",
                    Amount = 100,
                    Price = 600000,
                    ReducedPrice = 500000,
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Product()
                {
                    Id = Guid.Parse("5571ad42-6960-473d-aa75-aabc6edf5014"),
                    IdCategory = Guid.Parse("5871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "TRANH TREO TƯỜNG TV01",
                    Image = "https://tuongvip.vn/public/uploads/products/36271/tranh-treo-tuong-binh-hoa-nghe-thuat-10-1.jpg",
                    Description = "TRANH TREO TƯỜNG TV01",
                    Amount = 100,
                    Price = 600000,
                    ReducedPrice = 500000,
                    CreatedTime = DateTime.Now,
                    Status = 0
                },
                new Product()
                {
                    Id = Guid.Parse("5071ad42-6960-473d-aa75-aabc6edf5014"),
                    IdCategory = Guid.Parse("5871ad42-6960-473d-aa75-aabc6edf5014"),
                    Name = "TRANH TREO TƯỜNG TV02",
                    Image = "https://tuongvip.vn/public/uploads/products/36271/tranh-treo-tuong-binh-hoa-nghe-thuat-10-1.jpg",
                    Description = "TRANH TREO TƯỜNG TV02",
                    Amount = 100,
                    Price = 600000,
                    ReducedPrice = 500000,
                    CreatedTime = DateTime.Now,
                    Status = 0
                }
                );

        }

    }
}
