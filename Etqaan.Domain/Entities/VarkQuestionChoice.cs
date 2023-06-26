namespace Etqaan.Domain.Entities
{
    public class VarkQuestionChoice : BaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int VarkScore { get; set; }
        public int VarkQuestionId { get; set; }
        public virtual VarkQuestion VarkQuestion { get; set; }
    }
}