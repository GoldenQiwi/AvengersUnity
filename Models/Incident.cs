using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Incident
    /// </summary>
    public enum Gravite { Insignifiant = 0, Mineur = 1, Modéré = 2, Grave = 3, Catastrophique = 4, Mortel = 5 }
    public enum Type_Degat { Innondation = 0, Incendie = 1, Physique = 2, Naturel = 3, Kidnapping = 4, Vol = 5, Matériel = 6, Autres = 7 }
    public class Incident
    {
        [Key]
        public int IncidentID { get; set; }

        [Required]
        [Display(Name ="Auteur de l'incident")]
        public int UserId { get; set; }

        [Required]
        [Display(Name ="Titre de l'incident")]
        public string Nom_Incident { get; set; }

        [Required]
        [Display(Name ="Niveau de gravité")]
        public Gravite Gravite { get; set; }

        [Required]
        [Display(Name = "Type de dégats")]
        public Type_Degat Type_degat { get; set; }

        [Required]
        public string Lieu { get; set; }

        public virtual ICollection<Mission> Missions { get; set; }

        //public virtual Pays Pays { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}