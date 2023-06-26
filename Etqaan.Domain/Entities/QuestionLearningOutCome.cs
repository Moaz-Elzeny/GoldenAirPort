namespace Etqaan.Domain.Entities
{
    public class QuestionLearningOutCome
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int LearningOutcomeId { get; set; }
        public virtual Question Question { get; set; }
        public virtual LearningOutcome LearningOutcome { get; set; }

    }
}
