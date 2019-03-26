using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HumaneSociety.Models
{
    public class Shelter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }
    }

    public class HumaneSocietyDBContext: DbContext
    {
        public DbSet<Shelter>
            HumaneSocieties { get; set; }
    }
}