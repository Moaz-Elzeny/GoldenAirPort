namespace Etqaan.Domain.Entities
{
    public class VarkExamResponse : BaseEntity
    {
        public int Id { get; set; }
        public int VarkExamId { get; set; }
        public string StudentId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int TotalVarkScore { get; set; }

        public virtual VarkExam VarkExam { get; set; }
        public virtual Student Student { get; set; }
    }

}
