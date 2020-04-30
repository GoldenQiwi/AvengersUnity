using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Rapport
    /// </summary>
    public class Rapport
    {
        [Required]
        [ForeignKey("Mission")]
        public int RapportID { get; set; }

        [Required]
        [Display(Name = "Auteur du rapport")]
        public int UserId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Le rapport ne peut pas dépasser 150 caractères")]
        [Display(Name ="Description de la mission")]
        public string Description { get; set; }

        public virtual Mission Mission { get; set; }
        public virtual ApplicationUser User { get; set; } 
        //Session user : 
        /*public virtual Utilisateur Utilisateur { get; set; }*/
    }
}