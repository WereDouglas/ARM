using ARM.DB;
using ARM.Model;
using ARM.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM.Sync
{
    public class Synchronisation
    {
        public Synchronisation()
        {
        }
        public static List<Users> u = new List<Users>();

         public static void Querying()
        {
            List<Queries> u = new List<Queries>();
            u = Queries.List("SELECT * FROM queries WHERE executed = 'false'");
            MedicalForm._Form1.FeedBack("Running Queries ... " + u.Count);
            if (u.Count>0) {
                foreach (var h in u.ToList())
                {
                    MySQL.Query(h.Querying);
                    MedicalForm._Form1.FeedBack("Executing  ..................... " + h.Querying.ToString());
                    string Query2 = "DELETE from queries WHERE id ='" + h.Id + "'";
                    MySQL.Query(Query2);
                }
                MedicalForm._Form1.FeedBack("Running Queries Complete.......................................");
            }
        }
       
    }
}
