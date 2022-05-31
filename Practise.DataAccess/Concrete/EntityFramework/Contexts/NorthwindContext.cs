using Microsoft.EntityFrameworkCore;
using Practise.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.DataAccess.Concrete.EntityFramework.Contexts
{
    //Context olabilmesi için DbContextten inherit edilmesi gerekiyor. 
    public class NorthwindContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; DataBase=Northwind;Trusted_Connection=true");
        }
        //Veri tabanımızla ilgili nesnemizi bağlıyoruz
        public DbSet<Product> Products { get; set; }
        }
    }

