using LifeLink.Models;
using LifeLink.Persistence;
using System;
using System.Linq;

namespace LifeLink.Persistence
{
    public static class DatabaseSeeder
    {
        public static void SeedData(LifeLinkDbContext dbContext)
        {
            if (!dbContext.Parameter.Any(p => p.Id == Constants.ADMIN))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        Constants.ADMIN,      
                        Constants.GK_USER,
                        Constants.PK_USER_ROLES,
                        "Admin",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == Constants.FIELD_OPERATOR))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        Constants.FIELD_OPERATOR,      
                        Constants.GK_USER,
                        Constants.PK_USER_ROLES,
                        "Field Operator",
                        ""                
                    )
                );
            }

                
            dbContext.SaveChanges();
            
        }
    }
}
