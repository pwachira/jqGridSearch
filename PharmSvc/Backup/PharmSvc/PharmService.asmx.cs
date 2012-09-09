using System;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Transactions;
using Pharmacy.linq;
using JqGridFilter.Helpers;
using LinqToExcel;
using Remotion.Data.Linq;

namespace Pharmacy
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://imp.pharm.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PharmSvc : System.Web.Services.WebService
    {

        JavaScriptSerializer js = new JavaScriptSerializer();

        [WebMethod(CacheDuration = 7200)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public ArrayList GetSites()
        {

            ArrayList arraySites = new ArrayList();
            using (SiteClassesDataContext sdc = new SiteClassesDataContext())
            {
                var sites = sdc.GetSiteSummaryDistinct() ;
                foreach (GetSiteSummaryDistinctResult site in sites)
                {
                    arraySites.Add(site.SiteCode);

                }
            }
            return arraySites;
        }

        [WebMethod(CacheDuration = 7200)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public ArrayList DistinctPharmacyDrugs()
        {
            ArrayList arraySites = new ArrayList();
            using (CssPharmDataContext pdc = new CssPharmDataContext())
            {
                var drugs = pdc.CSS_PharmacyDrugs.Select(d => d.MappedPharmacyDrug).Distinct();
                foreach (string drug in drugs)
                {
                    arraySites.Add(drug);
                }
            }
            return arraySites;
        }

        [WebMethod(CacheDuration = 7200)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public ArrayList DistinctProfiles()
        {
            ArrayList arrayProf = new ArrayList();
            using (CssPharmDataContext pdc = new CssPharmDataContext())
            {
                var drugs = pdc.CSS_TreatmentProfiles.Select(p => p.TreatmentProfileName);
                foreach (string drug in drugs)
                {
                    arrayProf.Add(drug);
                }
            }
            return arrayProf;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public jqGridGeneric<Order> GetArchiveOrders(string SiteCode, string Environment, int rows, int page, DateTime Start,
                                         DateTime End, string filters, string sidx, string sord)
        {
            string ConnString;
            string db = "Archive";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (ArchiveClassesDataContext adc = new ArchiveClassesDataContext(ConnString))
                {
                    adc.ExecuteCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                    var ArchiveOrders = QueryRepo.qryableArchOrders(adc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<Order>(f, ArchiveOrders).OrderBy<Order>(sidx, sord);
                    return new jqGridGeneric<Order>(page, rows, o);
                }
            }
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public List<TimeStats> GetTimeStats(string SiteCode, string Environment, DateTime Start, DateTime End, string filters, string sidx, string sord)
        {
            string ConnString;
            string db = "Archive";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (ArchiveClassesDataContext adc = new ArchiveClassesDataContext(ConnString))
                {
                    var timestats = QueryRepo.qryableArchOrders(adc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<Order>(f, timestats);
                    TimeStats o1 = (TimeStats)QueryRepo.FilteredTimeStats(o, sidx, sord);
                    List<TimeStats> ts = new List<TimeStats>();
                    ts.Add(o1);
                    return ts;
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public List<ArchiveMinMax> ArchiveMinMax(string SiteCode, string Environment, DateTime Start, DateTime End, string filters, string sidx, string sord)
        {
            string ConnString;
            string db = "Archive";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (ArchiveClassesDataContext adc = new ArchiveClassesDataContext(ConnString))
                {
                    var timestats = QueryRepo.qryableArchOrders(adc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<Order>(f, timestats);
                    return QueryRepo.FilteredMinMax(o, sidx, sord);
                }
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public List<OrderControl> DistinctOrderControls(string SiteCode, string Environment, DateTime Start, DateTime End, string filters, string sidx, string sord)
        {
            string ConnString;
            string db = "Archive";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (ArchiveClassesDataContext adc = new ArchiveClassesDataContext(ConnString))
                {
                    var o = QueryRepo.qryableArchOrders(adc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var oc = Search.FilterEntity<Order>(f, o);
                    return QueryRepo.DistinctOrderControls(oc, sidx, sord);
                }
            }
        }




        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public List<FieldStats> GetFieldStats(string SiteCode, string Environment, DateTime Start, DateTime End, string filters, string sidx, string sord)
        {

            string ConnString;
            string db = "Archive";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);

            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (ArchiveClassesDataContext adc = new ArchiveClassesDataContext(ConnString))
                {
                    var fieldstats = QueryRepo.qryableArchOrders(adc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<Order>(f, fieldstats);
                    return QueryRepo.FilteredFieldStats(o, sidx, sord);
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public jqGridGeneric<DmssOrder> GetOrders(string SiteCode, string Environment, int rows, int page, DateTime Start,
                                         DateTime End, string filters, string sidx, string sord)
        {
            string ConnString;
            string db = "DMSS";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (DmssClassesDataContext ddc = new DmssClassesDataContext(ConnString))
                {
                    var orders = QueryRepo.qryableDmssOrders(ddc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<DmssOrder>(f, orders).OrderBy<DmssOrder>(sidx, sord);
                    return new jqGridGeneric< DmssOrder>(page, rows, o);
                }
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public jqGridGeneric< Prescription> GetRx(string SiteCode, string Environment, int rows, int page, DateTime Start,
                                         DateTime End, string filters, string sidx, string sord)
        {
            string ConnString;
            string db = "DMSS";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (DmssClassesDataContext ddc = new DmssClassesDataContext(ConnString))
                {
                    var p = QueryRepo.qryableDmssRx(ddc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<Prescription>(f, p).OrderBy<Prescription>(sidx, sord);
                    return new jqGridGeneric<Prescription>(page, rows, o);
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public jqGridGeneric<PrescriptionHistory> GetRxHx(string SiteCode, string Environment, int rows, int page, int RxId)
        {
            string ConnString;
            string db = "DMSS";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (DmssClassesDataContext ddc = new DmssClassesDataContext(ConnString))
                {
                    var orders = QueryRepo.qryableRxHx(ddc, RxId);
                    return new jqGridGeneric< PrescriptionHistory>(page, rows, orders);
                }
            }
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]

        public jqGridGeneric<SiteDrug> SiteDrugs(string SiteCode, string Environment, string filters, string sidx, string sord, int page, int rows, DateTime Start, DateTime End)
        {
            string ConnString;
            string db = "DMSS";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);

            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (DmssClassesDataContext ddc = new DmssClassesDataContext(ConnString))
                {
                    var drugs = QueryRepo.QryableSiteDrugs(ddc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<SiteDrug>(f, drugs).OrderBy<SiteDrug>(sidx, sord);
                    return new jqGridGeneric< SiteDrug>(page, rows, o);
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]

        public List<SiteDrug> AllSiteDrugs(string SiteCode, string Environment, string filters, string sidx, string sord, int page, int rows, DateTime Start, DateTime End)
        {
            string ConnString;
            string db = "DMSS";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);

            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (DmssClassesDataContext ddc = new DmssClassesDataContext(ConnString))
                {
                    var drugs = QueryRepo.QryableSiteDrugs(ddc, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                   return Search.FilterEntity<SiteDrug>(f, drugs)
                       .OrderBy<SiteDrug>(sidx, sord).ToList();
                   
                }
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public jqGridGeneric<SiteDrugRoute> SiteDrugRoutes(string SiteCode, string Environment, string filters, string sidx, string sord, int page, int rows)
        {
            string ConnString;
            string db = "DMSS";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);

            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (DmssClassesDataContext ddc = new DmssClassesDataContext(ConnString))
                {

                    var sdr = QueryRepo.QryableSiteDrugRoutes(ddc);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<SiteDrugRoute>(f, sdr).OrderBy<SiteDrugRoute>(sidx, sord);
                    return new jqGridGeneric<SiteDrugRoute>(page, rows, o);
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json/*, UseHttpGet = true*/)]
        public jqGridGeneric< Component> GetComponents(string SiteCode, DateTime Start, DateTime End,
                                    string Environment, int rows, int page, int HdrTk, string filters, string sidx, string sord)
        {
            string ConnString;
            string db = "Archive";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (ArchiveClassesDataContext adc = new ArchiveClassesDataContext(ConnString))
                {
                    var cpnts = QueryRepo.qryableComponents(adc, HdrTk, Start, End);
                    string[] sortPrm = sidx.Split(',', ' ');
                    if (sortPrm.Length == 1)//rxc for single order
                    {
                        var cpntsSorted = cpnts.OrderBy<Component>(sidx, sord);
                        return new jqGridGeneric<Component>(page, rows, cpntsSorted);
                    }
                    else // for many orders
                    {
                        filters f = js.Deserialize<filters>(filters);
                        var cpntsSorted = Search.FilterEntity<Component>(f, cpnts)
                                                .OrderBy<Component>(sortPrm[3], sord)
                                                .OrderBy<Component>(sortPrm[0], sortPrm[1]);
                        return new jqGridGeneric<Component>(page, rows, cpntsSorted);
                    }

                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqGridGeneric< Component> DistinctRxc(string SiteCode, string Environment, int rows, int page, DateTime Start,
                                         DateTime End, string filters, string sidx, string sord)
        {
            string ConnString;
            string db = "Archive";
            ConnString = Connections.CreateConnectionString(SiteCode, Environment, db);
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (ArchiveClassesDataContext adc = new ArchiveClassesDataContext(ConnString))
                {
                    adc.ExecuteCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                    var rxc = QueryRepo.qryableComponents(adc, 0, Start, End);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<Component>(f, rxc);
                    var ret = QueryRepo.qryableRxcDistinct(adc, o).OrderBy<Component>(sidx, sord);
                    return new jqGridGeneric<Component>(page, rows, ret);
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public jqGridGeneric<PharmacyDrug> PharmacyDrugs(string SiteCode, string Environment, int rows, int page,  string filters, string sidx, string sord)
        {
             //string ConnString = Connections.CdProdConnectionString();
            using (var ctx = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
            }))
            {
                using (CssPharmDataContext cdc = new CssPharmDataContext())
                {
                    var pd = QueryRepo.PharmDrugs(cdc);
                    filters f = js.Deserialize<filters>(filters);
                    var o = Search.FilterEntity<PharmacyDrug>(f, pd).OrderBy<PharmacyDrug>(sidx, sord);
                    return new jqGridGeneric<PharmacyDrug>(page, rows, o) ;
                }
            }
        }
    }
}
