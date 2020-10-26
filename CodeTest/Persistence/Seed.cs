using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if(!context.Styles.Any())
            {
                var styles = new List<Style>
                {
                    new Style
                    {
                        Number = "05",
                        Name = "Italy Evening",
                    },
                    new Style
                    {
                        Number = "06",
                        Name = "Iceland Bloom",
                    },
                    new Style
                    {
                        Number = "07",
                        Name = "Northern",
                    },
                    new Style
                    {
                        Number = "08",
                        Name = "Rome Moon",
                    }
                };
                context.Styles.AddRange(styles);
                context.SaveChanges();
            }
        }
    }
}