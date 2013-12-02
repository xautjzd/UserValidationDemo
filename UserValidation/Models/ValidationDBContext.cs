using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using UserValidation.Models.POCO;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace UserValidation.Models
{
    public class ValidationDBContext : DbContext
    {
        private readonly static string UserValidationDB = "UserValidationDB";

        public ValidationDBContext()
            : base(UserValidationDB)
        { 
        }

        public DbSet<User> Users { get; set; }

        //重写方法, 可以在这移除一些配置数据库映射关系的契约
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // 移除复数表名的契约    
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();      // 防止黑幕交易 要不然每次都要访问 EdmMetadata这个表       
            //throw new UnintentionalCodeFirstException();
        }
    }
}