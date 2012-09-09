using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pharmacy.linq;

namespace Pharmacy
{
    internal  static class Connections
    {
        public static string CreateConnectionString(string Site , string Environment, string Db)
        {    
            int substrstart;
            int substrtake;
            string startswith;
            string srvstring;
            if (Environment.Equals("Production"))
            { 
                if (Db == "DMSS")
                {
                    substrstart = 12;
                    substrtake = 11;
                    startswith = "DMSSPROD";
                    return Connections.GetConnString(substrstart, substrtake, startswith, Site, Db);
                }
                else
                {
                    
                    substrstart = 12;
                    substrtake = 12;
                    startswith = "STAGEPROD";
                   return Connections.GetConnString(substrstart, substrtake, startswith, Site,Db);
                }
            }

            else /*if (Environment.Equals("Implementation"))*///Dummy block - stay in imp
            {
                if (Db == "DMSS")
                {

                    srvstring = "DMSSIMP100";
                    return "Data Source=" + srvstring + ";Initial Catalog=" + Site + "_DMSS;Integrated Security=True";
                }
                else
                {
                    srvstring = "STAGEIMP100";
                    return "Data Source=" + srvstring + ";Initial Catalog=" + Site + "_Archive;Integrated Security=True";
               
                }
            }


        }

        private static string GetConnString(int substrstart, int substrtake, string startswith, string Site, string Db)
        //using (SiteClassesDataContext dc = new SiteClassesDataContext() )
            
        {
            SiteClassesDataContext dc = new SiteClassesDataContext("Data Source=CDPROD100;Database=ClientDictionary;Integrated Security=True");
            
            var server =  dc.Connections.Join(dc.SiteConnections,c=>c.connection_id,sc=>sc.Connection_id,
                (conn, sconn) => new { scode = sconn.SiteCode,
                                       connstr = conn.connection_string
                }).Where(csc=>csc.scode == Site)
                .Where(csc2=> csc2.connstr.Substring(substrstart, substrtake).StartsWith(startswith))
                .Select(csc3 => csc3.connstr.Substring(substrstart, substrtake)).Take(1).ToList()[0];
            dc.Dispose();
            return "Data Source=" + server + ";Database=" + Site + "_"+Db+";Integrated Security=True";

        }

 

        internal static string CdProdConnectionString()
        {
            return "Data Source=cdprod100;Database=CSS_PharmData;Integrated Security=True";
        }
    }


}
