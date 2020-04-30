using AvengersUnityIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvengersUnityIdentity.DAL
{
    public class ApplicationDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            var civils = new List<Civil> { };
            civils.ForEach(s => context.Civils.Add(s));
            context.SaveChanges();

            var organisations = new List<Organisation> { };
            organisations.ForEach(s => context.Organisations.Add(s));
            context.SaveChanges();

            var pays = new List<Pays>
            {
                 new Pays{PaysID=1,Nom_Pays ="France",},
                 new Pays{PaysID=2,Nom_Pays ="Japon",},
                 new Pays{PaysID=3,Nom_Pays ="USA",},
                 new Pays{PaysID=4,Nom_Pays ="Allemagne",}
            };
            pays.ForEach(s => context.Pays.Add(s));
            context.SaveChanges();

            var heros = new List<Heros> { };
            heros.ForEach(s => context.Heros.Add(s));
            context.SaveChanges();

            var vilains = new List<Vilain> { };
            vilains.ForEach(s => context.Vilains.Add(s));
            context.SaveChanges();

            var incidents = new List<Incident> { };
            incidents.ForEach(s => context.Incidents.Add(s));
            context.SaveChanges();

            var missions = new List<Mission> { };
            missions.ForEach(s => context.Missions.Add(s));
            context.SaveChanges();

            var satisfactions = new List<Satisfaction> { };
            satisfactions.ForEach(s => context.Satisfactions.Add(s));
            context.SaveChanges();

            var rapports = new List<Rapport> { };
            rapports.ForEach(s => context.Rapports.Add(s));
            context.SaveChanges();

        }
    }
}