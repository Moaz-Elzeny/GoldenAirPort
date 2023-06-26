namespace Etqaan.Domain.Entities
{
    public class StudentAnswer : BaseEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string StudentId { get; set; }
        public string Answer { get; set; }
        public virtual Question Question { get; set; }
        public virtual Student Student { get; set; }
    }
}


