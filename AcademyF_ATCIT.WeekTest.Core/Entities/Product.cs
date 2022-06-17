using AcademyF_ATCIT.WeekTest.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace AcademyF_ATCIT.WeekTest.Core.Core.Entities
{
    public class Product : IEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Description} - {Price}€";
        }
    }
}
