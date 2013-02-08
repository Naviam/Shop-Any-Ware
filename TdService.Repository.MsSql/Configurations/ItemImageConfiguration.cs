using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdService.Model.Items;

namespace TdService.Repository.MsSql.Configurations
{
    public class ItemImageConfiguration : EntityTypeConfiguration<ItemImage>
    {
        /// <summary>
        /// 
        /// </summary>
        public ItemImageConfiguration()
        {
            this.Property(p => p.Path).IsRequired().HasMaxLength(100);
            this.Property(p => p.Filename).HasMaxLength(64);
        }
    }
}
