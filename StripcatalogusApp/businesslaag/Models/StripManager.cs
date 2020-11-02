
using Datalaag;
using Datalaag.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Businesslaag.Models
{
    public class StripManager
    {
        private StripRepository sr;
        private AuteurRepository ar;
        private ReeksRepository rk;
        private UitgeverijRepository ui;
        private IEnumerable<Strip> stripsFromDb;
        private string connectionString;

        public StripManager()
        {
            //met databank verbinden
            DbFunctions dbf = new DbFunctions();
            connectionString = dbf.conString;
            StripRepository sr = new StripRepository(connectionString);

            //alle strips van db opvragen
            stripsFromDb = (IEnumerable<Strip>)sr.GetAll();
        }

        public object DbFunctions { get; }

        public void AddStrip(string stripTitel, List<Auteur> auteurs, Reeks reeks, int stripNr, Uitgeverij uitgeverij) {
           //help strip om gelijke strip strip te vinden in db
            Strip x = (Strip)(from strip in stripsFromDb
                      where strip.StripTitel == stripTitel //hetzelfde titel
                      && strip.Reeks.Naam == reeks.Naam //hetzelfde reeks naam
                      && strip.StripNr == stripNr //hetzelfde strip nummer
                      && strip.Uitgeverij.Naam == uitgeverij.Naam //hetzelfde uitgeverij naam
                      select strip);
            

            if (!stripsFromDb.Contains(x))
            { //als nog niet in db
                if (stripTitel == null || stripTitel == "") { }

              //kijken of auteurs al bestaan
                ar = new AuteurRepository(connectionString);
                if (auteurs.Count == 0 || auteurs == null) { 
                for (int i = 0; i < auteurs.Count; i++)
                {
                       
                }
                }
                else throw new System.Exception("U gaf geen auteurs mee! ");
                //kijken of reeks al bestaat
                rk = new ReeksRepository(connectionString);
                if (reeks == null)
                {
                   
                }
                else throw new System.Exception("U gaf geen reeks mee! ");
                //kijken of uitgeverij al bestaat
                ui = new UitgeverijRepository(connectionString);
                if (uitgeverij == null)
                {

                }
                else throw new System.Exception("U gaf geen uitgeverij mee! ");
                //Strip toevoegen
                sr = new StripRepository(connectionString);
                sr.AddStrip(new Datalaag.Models.Strip(sr.GetLastStrip().ID, stripTitel, stripNr, auteurs, reeks, uitgeverij));

            }
            else throw new System.Exception("Deze strip bestaat al in databank! ");
        }
        public void EditStrip()
        {

        }
    }
}
