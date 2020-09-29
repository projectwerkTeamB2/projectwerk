using businesslaag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datalaag
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            JsonFileReader_ToObjects jfr = new JsonFileReader_ToObjects();
            List<Strip> stripsFromJson =  jfr.leesJson_GeefAlleStripsTerug();



        }
        }
}
