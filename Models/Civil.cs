using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Civil
    /// </summary>
    public enum Civilite { M, Mme, Autre }
    public class Civil
    {
        
        
            [ForeignKey("User")]

            public int CivilID { get; set; }

            [Required]
            public string Prenom { get; set; }
            [Required]
            public string Nom { get; set; }
            [Required]
            public Civilite Civilite { get; set; }

            [Required]
            public string Adresse { get; set; }

            [Required]
            public int PaysID { get; set; }


            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date de naissance")]
            public DateTime Date_de_naissance { get; set; }

            /// <summary>
            /// Méthode qui renvoit un civil au format "Civ. Prenom Nom, Pays".
            /// </summary>
            public string NomComplet
            {
                get
                {
                    return Civilite + ". " + Prenom + " " + Nom + ", " + Pays.Nom_Pays;
                }
            }

            public virtual Heros Heros { get; set; }


            public virtual ApplicationUser User { get; set; }

            public virtual Pays Pays { get; set; }
    }
}