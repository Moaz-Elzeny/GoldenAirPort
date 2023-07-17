namespace Etqaan.Application.Schools.DTOs
{
    public record SchoolsListDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Logo { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
        public string LearningSystem { get; init; }
        public string StudentsCount { get; init; }
        public string TeachersCount { get; init; }
        public string ClassesCount { get; init; }
        public string SubjectsCount { get; init; }
        public string AchievmentLevel { get; init; } //مستوى التحصيل
        public string ProgressDegree { get; init; }// درجة التقدم
        public string SubscriptionType { get; init; }
        public string RemainderOfSubscription { get; init; }// متبقي من الاشتراك
        public string SubscriptionYearlyAmount { get; init; } // قيمة الاشتراك السنوي
        public string SubscribeDate { get; init; }


    }
}
