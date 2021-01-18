
using Businesslaag.Managers;
using Businesslaag.Models;
using Datalaag;
using Datalaag.Mappers;
using Datalaag.Repositories;
using JSON.Mappers;
using JSON.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JSON
{
    public class SchrijfwegnaarJSON
    {
        ConvertToJSONlaag convertToJSONlaag = new ConvertToJSONlaag();

        public SchrijfwegnaarJSON() { }
        //schrijft alles van de databank weg naar een locatie op basis van locatie string en naam
        public void allesWegSchrijvenNaarJSONFile(string wegschrijflocatie, string naamBestandZonderDotJSON)
        {
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));
            List<StripJS> listStrips = new List<StripJS>(convertToJSONlaag.convertToStripsJS(generalManager.StripManager.GetAll()));


            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@wegschrijflocatie + @"/" + naamBestandZonderDotJSON + ".json", JsonConvert.SerializeObject(listStrips, Formatting.Indented));
  }
        //Schrijft alle foutieve strips weg naar een locatie
        public void allesWegSchrijvenNaarJSONFileVanFoutiveStripList(string wegschrijflocatie, List<StripJS> listStrips)
        {
            File.WriteAllText(@wegschrijflocatie + @"-" + "FoutieveJSONStrips" + ".json", JsonConvert.SerializeObject(listStrips, Formatting.Indented));

        }
        //Schrijft alle foutieve collections weg naar een locatie
        public void allesWegSchrijvenNaarJSONFileVanFoutiveStripCollectieList(string wegschrijflocatie, List<StripCollectionJS> listStrips)
        {
            File.WriteAllText(@wegschrijflocatie + @"-" + "FoutieveJSONCollectionStrips" + ".json", JsonConvert.SerializeObject(listStrips, Formatting.Indented));

        }
        //schrijft alles van de databank weg naar een locatie op basis van alleen locatie
        public void allesWegSchrijvenNaarJSONFile(string wegschrijflocatie)
        {
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));
            List<StripJS> listStrips = new List<StripJS>(convertToJSONlaag.convertToStripsJS(generalManager.StripManager.GetAll()));


            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@wegschrijflocatie, JsonConvert.SerializeObject(listStrips, Formatting.Indented));


        }
        //schrijft alles weg van de database op een generieke manier zodat er meerdere dingen dit kunnen gebruiken (strips en collections)
        public void allesWegSchrijvenNaarJSONFileGeneric<T>(string wegschrijflocatie)
        {
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));
            List<T> list = new List<T>((IEnumerable<T>)convertToJSONlaag.convertToStripsJS(generalManager.StripManager.GetAll()));
            list.AddRange((IEnumerable<T>)convertToJSONlaag.ConvertToStripCollectionJSList(generalManager.stripCollectionManager.GetAll()));

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@wegschrijflocatie, JsonConvert.SerializeObject(list, Formatting.Indented));


        }
    }
}
