namespace Etqaan.Domain.Entities
{
    public class Bank : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
