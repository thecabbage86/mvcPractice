using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcPractice.Models
{
    public class CreateEditCharacterViewModel
    {
        public CreateEditCharacterViewModel()
        {
            Intelligence = 5;
            Vitality = 5;
            Strength = 5;
            Mind = 5;
        }

        public CreateEditCharacterViewModel(Character character)
        {
            this.Id = character.Id;
            this.Name = character.Name;
            this.Intelligence = character.Intelligence;
            this.Mind = character.Mind;
            this.Strength = character.Strength;
            this.Vitality = character.Vitality;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Character name required")]
        [Display(Name = "Character Name")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Range(1, 10)]
        public short Intelligence { get; set; }
        [Range(1, 10)]
        public short Vitality { get; set; }
        [Range(1, 10)]
        public short Strength { get; set; }
        [Range(1, 10)]
        public short Mind { get; set; }
    }
}