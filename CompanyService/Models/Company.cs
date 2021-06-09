using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PlaceId { get; set; }

        public Company(Guid id, string name, string placeId)
        {
            Id = id;
            Name = name;
            PlaceId = placeId;
        }

        public Company()
        {
            
        }
    }
}
