using LifeLink.Helpers;
using LifeLink.Models;

namespace LifeLink.Persistence
{
    public static class DatabaseSeeder
    {
        public static void SeedData(LifeLinkDbContext dbContext)
        {
            // Add user roles
            if (!dbContext.Parameter.Any(p => p.Id == UserRoles.Admin))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        UserRoles.Admin,      
                        Constants.GK_USER,
                        Constants.PK_USER_ROLE,
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
                        Constants.PK_USER_ROLE,
                        "Field Operator",
                        ""                
                    )
                );
            }

            // Add evac person states
            if (!dbContext.Parameter.Any(p => p.Id == EvacPersonStatuses.Safe))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        EvacPersonStatuses.Safe,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_STATUS,
                        "Safe",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == EvacPersonStatuses.Unknown))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        EvacPersonStatuses.Unknown,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_STATUS,
                        "Unknown",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == EvacPersonStatuses.NeedsAssistance))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        EvacPersonStatuses.NeedsAssistance,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_STATUS,
                        "Needs Assistance",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == EvacPersonStatuses.GettingTreatment))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        EvacPersonStatuses.GettingTreatment,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_STATUS,
                        "Getting Treatment",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == EvacPersonStatuses.Deceased))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        EvacPersonStatuses.Deceased,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_STATUS,
                        "Deceased",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == EvacPersonStatuses.Neutral))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        EvacPersonStatuses.Neutral,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_STATUS,
                        "Neutral",
                        ""                
                    )
                );
            }
                

            // Add medications
            if (!dbContext.Parameter.Any(p => p.Id == Medications.Ibuprofen))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        Medications.Ibuprofen,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_MEDICATION,
                        "Ibuprofen",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == Medications.Morphine))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        Medications.Morphine,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_MEDICATION,
                        "Morphine",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == Medications.Aspirin))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        Medications.Aspirin,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_MEDICATION,
                        "Aspirin",
                        ""                
                    )
                );
            }

            // Add illnesses
            if (!dbContext.Parameter.Any(p => p.Id == Illnesses.TypeOneDiabetes))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        Illnesses.TypeOneDiabetes,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_ILLNESS,
                        "Diabetes (Type 1)",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == Illnesses.TypeTwoDiabetes))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        Illnesses.TypeTwoDiabetes,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_ILLNESS,
                        "Diabetes (Type 2)",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == Illnesses.Diarrhea))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        Illnesses.Diarrhea,      
                        Constants.GK_EVAC_PERSON,
                        Constants.PK_EVAC_PERSON_ILLNESS,
                        "Diarrhea",
                        ""                
                    )
                );
            }

            // Add field operator states
            if (!dbContext.Parameter.Any(p => p.Id == FieldOperatorStatuses.Neutral))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        FieldOperatorStatuses.Neutral,      
                        Constants.GK_FIELD_OPERATOR,
                        Constants.PK_FIELD_OPERATOR_STATUS,
                        "Neutral",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == FieldOperatorStatuses.ReadyForAssignment))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        FieldOperatorStatuses.ReadyForAssignment,      
                        Constants.GK_FIELD_OPERATOR,
                        Constants.PK_FIELD_OPERATOR_STATUS,
                        "Ready For Assignment",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == FieldOperatorStatuses.Active))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        FieldOperatorStatuses.Active,      
                        Constants.GK_FIELD_OPERATOR,
                        Constants.PK_FIELD_OPERATOR_STATUS,
                        "Active",
                        ""                
                    )
                );
            }
            if (!dbContext.Parameter.Any(p => p.Id == FieldOperatorStatuses.UnableToWork))
            {
                dbContext.Parameter.AddRange(
                    new Parameter
                    (
                        FieldOperatorStatuses.UnableToWork,      
                        Constants.GK_FIELD_OPERATOR,
                        Constants.PK_FIELD_OPERATOR_STATUS,
                        "Unable To Work",
                        ""                
                    )
                );
            }

            dbContext.SaveChanges();
            
        }
    }
}
