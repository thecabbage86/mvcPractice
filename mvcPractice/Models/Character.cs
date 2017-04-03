using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcPractice.Models
{
    public class Character
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        //public CharacterStats Stats { get; set; }
    }

    //public class CharacterStats
    //{
    //    public int Health { get; set; }
    //    public int Intelligence { get; set; }
    //    public int Vitality { get; set; }
    //    public int Strength { get; set; }
    //    public int Mind { get; set; }
    //}

    public class CharacterDBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
    }
}