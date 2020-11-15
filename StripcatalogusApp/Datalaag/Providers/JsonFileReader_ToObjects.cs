using Businesslaag.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Datalaag
{
    public class JsonFileReader_ToObjects
   
    {
        public List<Strip> leesJson_GeefAlleStripsTerug(string locatieString)
        {
            List<Strip> listStrips = new List<Strip>();
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@locatieString))
            {
                JsonSerializer serializer = new JsonSerializer();
            //    Strip strip = (Strip)serializer.Deserialize(file, typeof(Strip));
                listStrips = JsonConvert.DeserializeObject<List<Strip>>(file.ReadToEnd());
            }
            foreach(Strip s in listStrips)
            {
                if (s.StripTitel.Contains(@"'"))
                {
                    s.StripTitel = s.StripTitel.Replace(@"'", @"''");
                };
                foreach(Auteur a in s.Auteurs)
                {
                    if (a.Naam.Contains(@"'"))
                    {
                        a.Naam = a.Naam.Replace(@"'", @"''");
                    };
                }
                if (s.Reeks.Naam.Contains(@"'"))
                {
                    s.Reeks.Naam = s.Reeks.Naam.Replace(@"'", @"''");
                };
                if (s.Uitgeverij.Naam.Contains(@"'"))
                {
                    s.Uitgeverij.Naam = s.Uitgeverij.Naam.Replace(@"'", @"''");
                };

            }
            return listStrips;
        }


        /* 
        //ljenas code
         //Hierin lees ik het data bestand in en geef ik hun terug als List<Objects>
          public string locatieJson = @"..\..\..\..\..\dump.json";
          public List<Strip> listAlleStrips;

          //stripcatalogusVOORBEELD.json ->"0":"Titel;Reeks;Nummer;Uitgeverij;Auteurs;", ...
          public List<Strip> leesJson_GeefAlleStripsTerug() {
              List<string> readerStringList;

              //TODO remove hardcoded path from file open, and add reader function to UI
              using (FileStream fs = File.Open(locatieJson, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
              using (BufferedStream bs = new BufferedStream(fs))
              using (StreamReader sreader = new StreamReader(bs))
              {

                  //listAlleAuteurs = new List<Auteur>();
                  //listAlleReeks = new List<Reeks>();
                  listAlleStrips= new List<Strip>();
                 // listtAlleUitgeverij = new List<Uitgeverij>(); ;


          string input = null;

                  while ((input = sreader.ReadLine()) != null)
                  {
                      readerStringList = new List<string>();

                      var clean = new[] { '"', '[', '{', '}', ':', ']' };
                      string woord = input;
                      string[] words = woord
                           // .Replace(@", """, "NEXT")
                           .Replace(@"""", "")
                           .Replace(":[{", ":")
                           .Replace("]},{", "}]},")
                           .Replace(" \u0026", " ")
                           .Split("}]},", StringSplitOptions.RemoveEmptyEntries); //]},{ID;







                      for
                     (int i = 0; i < words.Count(); i++) //loops through each line of the array
                      {
                          int stripNr = 0;
                          words[i] = words[i].Trim(clean);
                          string[] SplitsHelper = words[i].Split(',');


                          string[] SplitsHelper2 = SplitsHelper[0].Split(":");
                          string StripID = SplitsHelper2[1];

                          SplitsHelper2 = SplitsHelper[1].Split(":");
                          string stripTitel = SplitsHelper2[1];


                          if (!SplitsHelper[2].Contains("Nr"))
                          { //nr.24 heeft extra tittel tekst
                              stripTitel = stripTitel + ", " + SplitsHelper[2];
                               var foos = new List<String>(SplitsHelper);
                              foos.RemoveAt(2);
                              SplitsHelper = foos.ToArray();
                          }



                          SplitsHelper2 = SplitsHelper[2].Split(":");
                          if (SplitsHelper2[1] == "null") //als "null" maak dan 0
                          {  stripNr = 0;  }
                          else {
                               stripNr = Convert.ToInt32(SplitsHelper2[1]);
                          };


                          SplitsHelper2 = SplitsHelper[3].Split(":");
                          string stripReeksID = SplitsHelper2[2];

                          SplitsHelper2 = SplitsHelper[4].Split(":");
                          string stripReeks = SplitsHelper2[1];
                          if (stripReeks.Contains("geen serie")) {
                              stripReeks = "geen serie";
                          }

                          SplitsHelper2 = SplitsHelper[6].Split(":");
                          string stripUitgeverijID = SplitsHelper2[2];

                          SplitsHelper2 = SplitsHelper[7].Split(":");
                          string stripUitgeverij = SplitsHelper2[1].Trim(clean); ;

                          //als er geen auteurs zijn
                          if (SplitsHelper.Count() > 9) //bv. STRIP "ID":282 -> heeft geen auteurs
                          {
                              SplitsHelper2 = SplitsHelper[8].Split(":");
                              string stripAuteur1ID = SplitsHelper2[2];
                              SplitsHelper2 = SplitsHelper[9].Split(":");
                              string stripAuteur1Naam = SplitsHelper2[1];

                              if (SplitsHelper.Last() != SplitsHelper[9]) //betekent dat er meerdere auteurs zijn
                              {
                                  List<Auteur> auteurs = new List<Auteur>();
                                  for (int ii = 8; ii < SplitsHelper.Length; ii = ii + 2)
                                  {
                                      if (ii == 8)
                                      {
                                          SplitsHelper2 = SplitsHelper[ii].Split(":");
                                          stripAuteur1ID = SplitsHelper2[2];
                                      }
                                      else
                                      {
                                          SplitsHelper2 = SplitsHelper[ii].Split(":");
                                          stripAuteur1ID = SplitsHelper2[1];
                                      }
                                      SplitsHelper2 = SplitsHelper[ii + 1].Split(":");
                                      stripAuteur1Naam = SplitsHelper2[1].Trim(clean); ;

                                      auteurs.Add(new Auteur(Convert.ToInt32(stripAuteur1ID), stripAuteur1Naam));
                                  }
                                  //als er meerdere auteurs zijn
                                  listAlleStrips.Add(new Strip(Convert.ToInt32(StripID), stripTitel, Convert.ToInt32(stripNr), auteurs, new Reeks(Convert.ToInt32(stripReeksID), stripReeks), new Uitgeverij(Convert.ToInt32(stripUitgeverijID), stripUitgeverij)));
                              }
                              else
                              {
                                  List<Auteur> auteurs = new List<Auteur>();
                                  ////als er maar 1 auteur is
                                  auteurs.Add(new Auteur(Convert.ToInt32(stripAuteur1ID), stripAuteur1Naam));
                                  listAlleStrips.Add(new Strip(Convert.ToInt32(StripID), stripTitel, Convert.ToInt32(stripNr), auteurs, new Reeks(Convert.ToInt32(stripReeksID), stripReeks),  new Uitgeverij(Convert.ToInt32(stripUitgeverijID), stripUitgeverij)));

                              }


                          }
                          else //als er geen auteurs zijn
                          {
                              List<Auteur> auteurs = new List<Auteur>();
                              listAlleStrips.Add(new Strip(Convert.ToInt32(StripID), stripTitel, Convert.ToInt32(stripNr), auteurs, new Reeks(Convert.ToInt32(stripReeksID), stripReeks), new Uitgeverij(Convert.ToInt32(stripUitgeverijID), stripUitgeverij)));


                          }





                      }
                  }
                  return listAlleStrips;


              }

          }*/
    }
}
