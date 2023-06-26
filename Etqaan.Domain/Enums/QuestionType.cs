using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum QuestionType
    {

        [Description("أكمل العبارة التالية")]
        [Display(Name = "Compleete The Following Statement")]
        CompleeteTheFollowingStatement = 1,

        [Description("الكتابة")]
        [Display(Name = "Writing")]
        Writing = 2,

        [Description("التحدث")]
        [Display(Name = "Speaking")]
        Speaking = 3,


        [Description("التجويد و الترتيل")]
        [Display(Name = "Tajweed")]
        Tajweed = 4,


        [Description("القراءة الجهرية")]
        [Display(Name = "Oral Reading")]
        OralReading = 5,


        [Description("اختر الاجابة الصحيحة")]
        [Display(Name = "Choose The Correct Answer")]
        ChooseTheCorrectAnswer = 6,


        [Description("اختر الاجابات الصحيحة")]
        [Display(Name = "Choose The Correct Answers")]
        ChooseTheCorrectAnswers = 7,


        [Description("ضع علامة صح او خطأ")]
        [Display(Name = "True Or False")]
        TrueOrFalse = 8,


        [Description("رتب ما يلي")]
        [Display(Name = "Sort The Following")]
        SortTheFollowing = 9,


        [Description("صل ما يلي")]
        [Display(Name = "Match The Following")]
        MatchTheFollowing = 10,


        [Description("سحب و افلات")]
        [Display(Name = "Drag and Drop")]
        DragAndDrop = 11,


        [Description("صنف ما يلي")]
        [Display(Name = "Classify The Following")]
        ClassifyTheFollowing = 12,


        [Description("أكمل مما بين القوسين")]
        [Display(Name = "Compleete From Brackets")]
        CompleeteFromBrackets = 13,


        [Description("حدد من الفقرة")]
        [Display(Name = "Select From The Paragraph")]
        SelectFromTheParagraph = 14,
    }
}
