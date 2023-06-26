namespace Etqaan.Domain.Entities
{
    public class VarkQuestion : BaseEntity
    {
        public VarkQuestion()
        {
            VarkQuestionChoices = new HashSet<VarkQuestionChoice>();
        }
        public int Id { get; set; }
        public int VarkExamId { get; set; }
        public string QuestionHead { get; set; }
        public string QuestionBody { get; set; }
        public virtual VarkExam VarkExam { get; set; }
        public virtual ICollection<VarkQuestionChoice> VarkQuestionChoices { get; set; }
    }
}