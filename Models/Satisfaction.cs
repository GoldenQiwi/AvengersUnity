using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Satisfaction
    /// </summary>
    public enum Niveau { Passable = 0, Moyen = 1, Correct = 2, Satisfait = 3, Super = 4, Parfait = 5 }
    public enum Type { Heros=0, Vilain=1, Mission=2, Incident=3}

    public class Satisfaction
    {
        [Key]
        [ForeignKey ("Mission")]
        public int SatisfactionID { get; set; }

        [Required]
        [Display(Name = "Auteur de la satisfaction")]
        public int UserId { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        [Display(Name ="Nom du Heros")]
        public string Identification_Heros { get; set; }

        [Display(Name = "Appréciation")]
        public Niveau Niveau { get; set; }

        [Required]
        public int Note { get; set; }

        [Required]
        [Display(Name ="Commentaire de satisfaction")]
        public string Contenu { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Mission Mission { get; set; }

    }
}