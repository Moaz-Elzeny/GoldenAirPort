namespace Etqaan.Domain.Entities
{
    public class About : BaseEntity2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AboutStudent> AboutStudents { get; set; }
    }
}
