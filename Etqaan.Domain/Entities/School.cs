using Etqaan.Domain.Entities.Auth;

namespace Etqaan.Domain.Entities
{
    public class School : BaseEntity
    {
        public string Id { get; set; }
        public string AppUserId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string LogoImage { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int OrganizationType { get; set; }//
        public int LearningSystem { get; set; }//
        public int StudentCapacityId { get; set; }
        public int TeachersCount { get; set; }
        public int ClassesCount { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public int SubscriptionPeriodId { get; set; }
        public decimal SubscriptionPrice { get; set; }

        public virtual AppUser AppUser { get; set; }

    }
}


/*
 
- Id
- AppUserId
- NameAr
- Name En
- Logo Image
- CountryId
- CityId
- OrganizationType
- LearningSystem
- StudentCapacityId
- TeachersCount
- ClassesCount
- SubscriptionId
- SubscriptionStartDate
- SubscriptionPeriodId
- SubscriptionPrice
 
 */