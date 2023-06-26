using Etqaan.Domain.Enums;

namespace Etqaan.Domain.Entities
{
    public class Question : BaseEntity
    {
        public Question()
        {
            QuestionChoices = new HashSet<QuestionChoice>();
            QuestionLearningOutComes = new HashSet<QuestionLearningOutCome>();
            QuestionSkills = new HashSet<QuestionSkill>();
            StudentAnswers = new HashSet<StudentAnswer>();


        }
        public int Id { get; set; }
        public QuestionType QuestionType { get; set; }
        public string? QuestionHead { get; set; }
        public string? QuestionHeadImageIcon { get; set; }
        public string? QuestionHeadVoiceRecord { get; set; }
        public string? ChoicesVoiceRecord { get; set; }
        public string? LessonName { get; set; }
        public byte QuestionNumber { get; set; }
        public string? CorrectAnswer { get; set; }




        public int? QuestionBankId { get; set; }
        public virtual QuestionsBank QuestionsBank { get; set; }
        public int? ExternalExamId { get; set; }
        public virtual ExternalExam ExternalExam { get; set; }
        public int? MissionId { get; set; }

        public virtual Mission Mission { get; set; }

        public virtual ICollection<QuestionChoice> QuestionChoices { get; set; }
        public virtual ICollection<QuestionLearningOutCome> QuestionLearningOutComes { get; set; }
        public virtual ICollection<QuestionSkill> QuestionSkills { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }



    }
}
