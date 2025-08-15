using adin_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adin_api.Data.Configuration.Entities
{

    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image
                {
                    Id = 1,
                    Link = "https://m.media-amazon.com/images/I/71VcbZYF0hL._AC_SX466_.jpg",
                    Name="Hammer"
                },
                new Image
                {
                    Id = 2,
                    Link = "https://mobileimages.lowes.com/productimages/8d4b8c73-1811-464f-9b22-d29608f151f0/00617143.jpg",
                    Name="Drill"
                },
                new Image
                {
                    Id = 3,
                    Link = "https://www.vigor-equipment.com/media/image/96/11/d6/v3613ErzzIwdipftMQ.jpg",
                    Name="Screwdriver"
                }
                );
        }

    }
}
