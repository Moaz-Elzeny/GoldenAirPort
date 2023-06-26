namespace Etqaan.Domain.Entities
{
    public class QuestionChoice : BaseEntity
    {
        public int Id { get; set; }
        public string? ChoiceText { get; set; }
        public byte SortIndex { get; set; }
        public string? ImageIcon { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}

