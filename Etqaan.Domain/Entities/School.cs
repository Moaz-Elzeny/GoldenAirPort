using Etqaan.Domain.Entities.Auth;
using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class School : BaseEntity
    {
        public School()
        {
            Students = new HashSet<Student>();
            SchoolClasses = new HashSet<SchoolClass>();
            SchoolGrades = new HashSet<SchoolGrade>();
        }
        public string Id { get; set; }
        public string AppUserId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string LogoImage { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public LearningSystem LearningSystem { get; set; }
        public int StudentCapacityId { get; set; }
        public int TeachersCount { get; set; }
        public int ClassesCount { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public int SubscriptionPeriodId { get; set; }
        public decimal SubscriptionPrice { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual StudentCapacity StudentCapacity { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual SubscriptionPeriod SubscriptionPeriod { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }
        public virtual ICollection<SchoolGrade> SchoolGrades { get; set; }


    }
}

