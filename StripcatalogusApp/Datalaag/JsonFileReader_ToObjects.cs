using businesslaag;
using Businesslaag;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Datalaag
{
   public class JsonFileReader_ToObjects
    //Hierin lees ik de data bestand in en geef ik hun terug als List<Objects>
    {
        
        public List<Strip> listAlleStrips;

        //stripcatalogusVOORBEELD.json ->"0":"Titel;Reeks;Nummer;Uitgeverij;Auteurs;", ...
        public List<Strip> leesJson_GeefAlleStripsTerug() {
            List<string> readerStringList;

            using (FileStream fs = File.Open(@"..\..\..\..\..\stripcatalogusVOORBEELD.json", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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

                    var clean = new[] { '"', ':', '{', '\'', '}' };
                    string woord = input;
                    string[] words = woord
                        .Trim(new Char[] { '"' })
                        .Trim(clean)
                        .Split(',');


                    
                    for
                   (int i = 1; i < words.Count(); i++) //loops through each line of the array
                    {
                        string[] SplitsHelper = words[i].Split('"');
                        string[] SplitsHelper2 = SplitsHelper[3].Split(';');

                        string stripTitel = SplitsHelper2[0];
                        string stripReeks = SplitsHelper2[1];
                        string stripNr = SplitsHelper2[2];
                        string stripUitgeverij = SplitsHelper2[3];
                        string stripAuteur1 = SplitsHelper2[4];

                       

                        if (SplitsHelper2[4] != SplitsHelper2.Last()) //betekent dat er meerdere auteurs zijn
                        {
                            List<Auteur> auteurs = new List<Auteur>();
                            for (int ii = 4; ii < SplitsHelper2.Length; ii++)
                            {
                                auteurs.Add(new Auteur(SplitsHelper2[ii]));
                            }
                            //als er meerdere auteurs zijn
                            listAlleStrips.Add(new Strip(stripTitel, auteurs, new Reeks( stripReeks), Convert.ToInt32( stripNr), new Uitgeverij(stripUitgeverij)));
                        }
                        else {
                            List<Auteur> auteurs = new List<Auteur>();
                            //als er maar 1 auteur is
                            auteurs.Add(new Auteur(stripAuteur1));
                            listAlleStrips.Add(new Strip(stripTitel, auteurs, new Reeks(stripReeks), Convert.ToInt32(stripNr), new Uitgeverij(stripUitgeverij)));

                        }

                    }
                }
                return listAlleStrips;


            }

        }
    }
}
