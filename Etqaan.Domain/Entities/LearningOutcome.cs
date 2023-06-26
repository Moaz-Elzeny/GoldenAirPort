namespace Etqaan.Domain.Entities
{
    public class LearningOutcome : BaseEntity
    {
        public LearningOutcome()
        {
            QuestionLearningOutComes = new HashSet<QuestionLearningOutCome>();

        }
        public int Id { get; set; }
        public decimal Number { get; set; }
        public string Description { get; set; }
        public int StandardId { get; set; }
        public virtual Standard Standard { get; set; }
        public virtual ICollection<QuestionLearningOutCome> QuestionLearningOutComes { get; set; }

    }
}