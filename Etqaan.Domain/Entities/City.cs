﻿namespace Etqaan.Domain.Entities
{
    public class City : BaseEntity
    {
        public City()
        {
            Schools = new HashSet<School>();
        }
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}
