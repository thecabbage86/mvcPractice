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
        public Character()
        {
            this.Level = 1;
        }

        public Character(CreateEditCharacterViewModel createCharacter)
        {
            this.Name = createCharacter.Name;
            this.Intelligence = createCharacter.Intelligence;
            this.Mind = createCharacter.Mind;
            this.Strength = createCharacter.Strength;
            this.Vitality = createCharacter.Vitality;
            this.Level = 1;
        }

        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        //public CharacterClass Class { get; set; }
        public int Level { get; set; }

        public short Health { get { return (short)((this.Vitality + this.Strength) * 100); } set { } }
        public short MagicPoints { get { return (short)((this.Intelligence + this.Mind) * 10); } set { } }

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

        public System.Data.Entity.DbSet<mvcPractice.Models.CreateEditCharacterViewModel> CreateEditCharacterViewModels { get; set; }
    }
}