
using Businesslaag.Managers;
using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JSON
{
    public class SchrijfwegnaarJSON
    {

        public SchrijfwegnaarJSON() { }
        public void allesWegSchrijvenNaarJSONFile(string wegschrijflocatie, string naamBestandZonderDotJSON)
        {
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
            List<Strip> listStrips = new List<Strip>(generalManager.StripManager.GetAll());


            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@wegschrijflocatie + @"/" + naamBestandZonderDotJSON + ".json", JsonConvert.SerializeObject(listStrips, Formatting.Indented));
  }
        public void allesWegSchrijvenNaarJSONFileVanStripList(string wegschrijflocatie, List<Strip> listStrips)
        {
            File.WriteAllText(@wegschrijflocatie + @"-" + "FoutieveJSON" + ".json", JsonConvert.SerializeObject(listStrips, Formatting.Indented));

        }

        public void allesWegSchrijvenNaarJSONFile(string wegschrijflocatie)
        {
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
            List<Strip> listStrips = new List<Strip>(generalManager.StripManager.GetAll());


            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@wegschrijflocatie, JsonConvert.SerializeObject(listStrips, Formatting.Indented));


        }
    }
}
