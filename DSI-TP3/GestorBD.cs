using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DSI_TP3 {

    public static class GestorBD {

        public static BaseDatosModel ObtenerRegistros () {
            string dbString = File.ReadAllText ("db.json");
            return JsonConvert.DeserializeObject<BaseDatosModel> (dbString);
        }

        public static void SobrescribirRegistros (BaseDatosModel db) {
            string dbSerialized = JsonConvert.SerializeObject (db,Formatting.Indented );
            System.IO.File.WriteAllText ("db.json", dbSerialized);
        }

    }

}