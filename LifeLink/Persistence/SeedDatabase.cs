using LifeLink.Helpers;
using LifeLink.Models;

namespace LifeLink.Persistence
{
    public static class DatabaseSeeder
    {
        public static void SeedData(LifeLinkDbContext dbContext)
        {
            if (!dbContext.Parameter.Any(p => p.Id == UserRoles.Admin))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        UserRoles.Admin,      
                        Constants.GK_USER,
                        Constants.PK_USER_ROLES,
                        "Admin",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == UserRoles.FieldOperator))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        UserRoles.FieldOperator,      
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
