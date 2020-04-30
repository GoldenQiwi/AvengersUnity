using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.Models
{
    /// <summary>
    /// Classe Organisation
    /// </summary>
    public class Organisation
    {
        [ForeignKey("User")]
        public int OrganisationID { get; set; }

        [Required]
        [Display(Name ="Nom de l'organisation")]
        public string Nom_Organisation { get; set; }


        [Required]
        [Display(Name ="Adresse siège sociale")]
        public string Adresse { get; set; }

        [Required]
        [Display(Name ="Pays")]
        public int PaysID { get; set; }
        public virtual Pays Pays { get; set; }

        /// <summary>
        /// Méthode "NomComplet" qui renvoit les Organisations au format "Nom_Organisation, Pays"
        /// </summary>
        public string NomComplet
        {
            get
            {
                return Nom_Organisation + ", " + Pays.Nom_Pays;
            }
        }

        public virtual ApplicationUser User { get; set; }

        //public int CivilID { get; set; }
        //public virtual Civil Civil { get; set; }
    }
}