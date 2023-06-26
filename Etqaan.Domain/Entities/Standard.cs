namespace Etqaan.Domain.Entities
{
    public class Standard : BaseEntity
    {
        public Standard()
        {
            LearningOutcomes = new HashSet<LearningOutcome>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string? NameEn { get; set; }
        public int AxisId { get; set; }
        public virtual Axis Axis { get; set; }
        public virtual ICollection<LearningOutcome> LearningOutcomes { get; set; }
    }
}
