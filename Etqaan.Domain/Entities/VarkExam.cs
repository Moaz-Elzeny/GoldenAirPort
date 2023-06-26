namespace Etqaan.Domain.Entities
{
    public class VarkExam : BaseEntity
    {
        public VarkExam()
        {
            VarkQuestions = new HashSet<VarkQuestion>();
            VarkExamResponses = new HashSet<VarkExamResponse>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<VarkQuestion> VarkQuestions { get; set; }
        public ICollection<VarkExamResponse> VarkExamResponses { get; set; }
    }
}
