using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pharmacy.linq;
using System.Configuration;
using System.Data.SqlClient;

namespace Pharmacy
{
    internal  static class Connections
    {
     /*  static string serverString;
       static string prodServerName;
       static string connString; */
       static string sysEnv = ConfigurationManager.AppSettings["SysEnvironment"];
        
        public static string CreateConnectionString(string Site , string Environment, string Db)
        {    
           
            
            if (Environment.Equals("Production"))
            { 
                if (Db == "DMSS")
                {
                    /*serverString = "DMSSPROD";
                    prodServerName = Connections.GetProdServerName(serverString,Site, Db);
                    connString = ConfigurationManager.ConnectionStrings[sysEnv + "ProductionConnStringTemplate"].ToString();
                    //return connString.Replace("DbServer", prodServerName).Replace("SiteCode", Site).Replace("Db", Db);
                    */return "Data Source=WIN-8K7A6DLCS1E;Initial Catalog=BatonRougeGeneralLA_DMSS;Integrated Security=True";
                }
                else
                {
                   /* serverString = "STAGEPROD";
                    prodServerName = Connections.GetProdServerName(serverString, Site, Db);
                    connString = ConfigurationManager.ConnectionStrings[sysEnv + "ProductionConnStringTemplate"].ToString();
                   return connString.Replace("DbServer", prodServerName).Replace("SiteCode", Site).Replace("Db",Db);
                  */ return "Data Source=WIN-8K7A6DLCS1E;Initial Catalog=BatonRougeGeneralLA_Archive;Integrated Security=True";

                }
            }

            else
            {
                if (Db == "DMSS")
                {

                    // srvstring = "WIN-8K7A6DLCS1E";
                    return "Data Source=WIN-8K7A6DLCS1E;Initial Catalog=BatonRougeGeneralLA_DMSS;Integrated Security=True";
                }
                else
                {
                    // srvstring = "WIN-8K7A6DLCS1E";
                    return "Data Source=WIN-8K7A6DLCS1E;Initial Catalog=BatonRougeGeneralLA_Archive;Integrated Security=True";

                }
            }


        }

      /*  private static string GetProdServerName(string serverString, string Site, string Db)
            
        {
            SiteClassesDataContext dc = new SiteClassesDataContext(ConfigurationManager.ConnectionStrings[sysEnv +"ClientDictionaryConnectionString"].ToString());

            string cstr = dc.Connections.Join(dc.SiteConnections, c => c.connection_id, sc => sc.Connection_id,
                 (conn, sconn) => new
                 {
                     siteCode = sconn.SiteCode,
                     connstr = conn.connection_string
                 }).Where(csc => csc.siteCode == Site)
                 .Where(c => c.connstr.Contains(serverString))
                 .Select (c=>c.connstr)
                 .ToList()[0].ToString();

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(cstr.ToString());
            dc.Dispose();
            return csb.DataSource;
          
        
        }
        */


    }


}
