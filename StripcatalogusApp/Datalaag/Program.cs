using businesslaag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datalaag
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {


            JsonFileReader_ToObjects jfr = new JsonFileReader_ToObjects();
            List<Strip> stripsFromJson = jfr.leesJson_GeefAlleStripsTerug();



        }
    }
}

