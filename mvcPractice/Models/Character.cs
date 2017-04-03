using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcPractice.Models
{
    public class Character
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }

        [Range(1, 10)]
        public short Health { get; set; }
        [Range(1, 10)]
        public short Intelligence { get; set; }
        [Range(1, 10)]
        public short Vitality { get; set; }
        [Range(1, 10)]
        public short Strength { get; set; }
        [Range(1, 10)]
        public short Mind { get; set; }
    }



    public class CharacterDBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
    }
}