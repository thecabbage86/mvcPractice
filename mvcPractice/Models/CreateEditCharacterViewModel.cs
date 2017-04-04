using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcPractice.Models
{
    public class CreateEditCharacterViewModel : IValidatableObject
    {
        private const int MAX_INIT_STATS_TOTAL = 26;

        public int Id { get; set; }

        [Required(ErrorMessage = "Character name required")]
        [Display(Name = "Character Name")]
        [MaxLength(20, ErrorMessage = "Character name must be no greater than 20 characters.")]
        public string Name { get; set; }

        [Range(1, 10)]
        [Display(Description = "Governs magic attack power. Max point allocation: 10")]
        public short Intelligence { get; set; }

        [Range(1, 10)]
        [Display(Description = "Governs defense. Max point allocation: 10")]
        public short Vitality { get; set; } 

        [Range(1, 10)]
        [Display(Description = "Governs attack power. Max point allocation: 10")]
        public short Strength { get; set; }

        [Range(1, 10)]
        [Display(Description = "Governs magic defense. Max point allocation: 10")]
        public short Mind { get; set; }

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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int statsTotal = Intelligence + Mind + Vitality + Strength;

            if (statsTotal > MAX_INIT_STATS_TOTAL)
            {
                yield return new ValidationResult(string.Format("Stat allocation exceeds maximum total of {0} points.", MAX_INIT_STATS_TOTAL));
            }

            if (statsTotal < MAX_INIT_STATS_TOTAL)
            {
                yield return new ValidationResult(string.Format("Allocate remaining {0} points before creating character.", MAX_INIT_STATS_TOTAL - statsTotal));
            }
        }
    }
}