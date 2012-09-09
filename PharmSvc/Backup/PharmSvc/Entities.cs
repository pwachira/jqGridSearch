using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy
{
    public class OrderBase
    {

    }
    public class Order : OrderBase
    {
        public decimal Id { get; set; }
        public string MessageControlId { get; set; }
        public Nullable<DateTime> MessageDateTime { get; set; }
        public string SendingApplication { get; set; }
        public string FacilityId { get; set; }
        public string Location { get; set; }
        public string AccountNumber { get; set; }
        public string PatientName { get; set; }
        public string Mrn { get; set; }
        public string OrderControl { get; set; }
        public string Condition { get; set; }
        public string Priority { get; set; }
        public string PrescriptionNumber { get; set; }
        public string GiveCodeIdentifier { get; set; }
        public string GiveCodeText { get; set; }
        public string GiveCodeAltText { get; set; }
        public string GiveAmount { get; set; }
        public string GiveUnits { get; set; }
        public string GiveDosageForm { get; set; }
        public string IntervalRepeat { get; set; }
        public string Route { get; set; }
        public string OrderingProvider { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public Nullable<DateTime> OrderEffectiveDate { get; set; }

    }


    public class jqGridGeneric<O> 
    {
        public long records { get; set; }
        public int page { get; set; }
        public long total { get; set; }
        public List<O> rows;
        private int skip;

        public jqGridGeneric()
        {

        }
        public jqGridGeneric(int page, int pgsize, IQueryable<O> orders)
        {
            this.skip = page * pgsize - pgsize;
            this.records = orders.Count();
            this.page = page;
            this.total = (long)Math.Ceiling((double)this.records / (double)pgsize);
            this.rows = orders.Skip(this.skip).Take(pgsize).ToList();
        }

    }




    public class TimeStats
    {
        public string OrderControl { get; set; }
        public string FacilityId { get; set; }
        public string SendingApplication { get; set; }
        public int PctStartTime { get; set; }
        public int PctEndTime { get; set; }
        public int PctOrdEffctTime { get; set; }
        public int PctTrscTime { get; set; }
        public int PctMsgTime { get; set; }
        public int Count { get; set; }

    }

    public class ArchiveMinMax
    {
        public string OrderControl { get; set; }
        public string FacilityId { get; set; }
        public string SendingApplication { get; set; }
        public Nullable<DateTime> MinStartTime { get; set; }
        public Nullable<DateTime> MaxStartTime { get; set; }
        public Nullable<DateTime> MinEndTime { get; set; }
        public Nullable<DateTime> MaxEndTime { get; set; }
        public Nullable<DateTime> MinOrdEffctTime { get; set; }
        public Nullable<DateTime> MaxOrdEffctTime { get; set; }
        public Nullable<DateTime> MinTrscTime { get; set; }
        public Nullable<DateTime> MaxTrscTime { get; set; }
        public Nullable<DateTime> MinMsgTime { get; set; }
        public Nullable<DateTime> MaxMsgTime { get; set; }
    }
    public class FieldStats
    {
        public string OrderControl { get; set; }
        public float Mrn { get; set; }
        public float Location { get; set; }
        public float PrescriptionNumber { get; set; }
        public float GiveCodeIdentifier { get; set; }
        public float GiveCodeText { get; set; }
        public float GiveCodeAlternateText { get; set; }
        public float GiveAmount { get; set; }
        public float GiveUnits { get; set; }
        public float IntervalRepeat { get; set; }
        public float Route { get; set; }
        public float DosageForm { get; set; }
        public float OrderingProvider { get; set; }
        public int Count { get; set; }
    }
    public class DmssOrder
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string PrescriptionNumber { get; set; }
        public int UniquePrescriptionNumber { get; set; }
        public int SiteTk { get; set; }
        public string Mrn { get; set; }
        public string Location { get; set; }
        public string PatientName { get; set; }
        public string OrderControl { get; set; }
        public string SiteDrugCode { get; set; }
        public string SiteDrugName { get; set; }
        public string Strength { get; set; }
        public string Units { get; set; }
        public string RepeatPatternCode { get; set; }
        public string SiteRouteCode { get; set; }
        public Nullable<DateTime> MessageLDT { get; set; }
        public Nullable<DateTime> OrderStartLDT { get; set; }
        public Nullable<DateTime> OrderEndLDT { get; set; }
        public Nullable<DateTime> TransactionLDT { get; set; }
        public Nullable<DateTime> OrderEffectiveLDT { get; set; }
        public string DoctorName { get; set; }
    }

    public class Prescription
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PrescriptionNumber { get; set; }
        public int UniquePrescriptionNumber { get; set; }
        public int SiteTk { get; set; }
        public string MRN { get; set; }
        public string Location { get; set; }
        public string SiteDrugCode { get; set; }
        public string SiteDrugName { get; set; }
        public string SiteRouteCode { get; set; }
        public string RepeatPatternCode { get; set; }
        public int isAutoDiscontinued { get; set; }
        public string Condition { get; set; }
        public string Priority { get; set; }
        public Nullable<DateTime> MessageLDT { get; set; }
        public Nullable<DateTime> PrescriptionStartLDT { get; set; }
        public Nullable<DateTime> PrescriptionStopLDT { get; set; }
        public string DoctorName { get; set; }
    }

    public class PrescriptionHistory
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public string ChangeType { get; set; }
        public Nullable<int> RelatedPrescriptionId { get; set; }
        public Nullable<DateTime> ChangeLDT { get; set; }
    }
    public class SiteDrug
    {
        public int Id { get; set; }
        public string SiteDrugCode { get; set; }
        public string SiteDrugName { get; set; }
        public string MappedPharmacyDrug { get; set; }
        public string Strength { get; set; }
        public string Units { get; set; }
        public string MappedPharmacyUnit { get; set; }
        public Nullable<DateTime> InsertedLDT { get; set; }
        public Nullable<DateTime> MappedLDT { get; set; }
        public bool isReleased { get; set; }
        public bool isReviewed { get; set; }
    }

    public class Component
    {
        public int Id { get; set; }
        public string FacilityId { get; set; }
        public string SendingApplication { get; set; }
        public string MessageControlId { get; set; }
        public int OrderRowTk { get; set; }
        public int OrderRxcRowTk { get; set; }
        public string ComponentType { get; set; }
        public string ComponentCodeId { get; set; }
        public string ComponentCodeText { get; set; }
        public string ComponentCodeAlt { get; set; }
        public string ComponentCodeCoding { get; set; }
        public string ComponentAmount { get; set; }
        public string ComponentUnits { get; set; }
        public string ComponentStrength { get; set; }
        public string ComponentStrengthUnits { get; set; }
        public string RxeDrugName { get; set; }
        public int Count { get; set; }
    }


    public class PharmacyDrug
    {
        public int Id { get; set; }
        public string MappedPharmacyDrug { get; set; }
        public string TreatmentProfileName { get; set; }
        public string MappedPharmacyUnit { get; set; }
        public string MappedPharmacyRoute { get; set; }
        public Nullable<int> TreatmentProfileId { get; set; }
        public long PharmacyDrugProperties { get; set; }

    }

    public class filters
    {
        public string groupOp { get; set; }
        public List<rule> rules { get; set; }
    }
    public class rule
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
    }
    public class ProfileForMap
    {
        public string NewTreatmentProfileName { get; set; }
        public int TreatmentProfileId { get; set; }
        public string TreatmentProfileName { get; set; }
        public byte InsertNew { get; set; }
        public byte Changed { get; set; }
        public int PharmacyDrugId { get; set; }
        public string MappedPharmacyUnit { get; set; }
        public string MappedPharmacyDrug { get; set; }
        public string MappedPharmacyRoute { get; set; }
        public string PharmacyClassName { get; set; }
        public string Lineage { get; set; }
    }

    public class SiteDrugRoute
    {
        public int Id { get; set; }
        public int SiteRouteId { get; set; }
        public string SiteRouteCode { get; set; }
        public string SiteDrugName { get; set; }
        public Nullable<int> PharmacyDrugId { get; set; }

    }
    public class OrderControl
    {
        public string OrderControlDesc { get; set; }
        public Nullable<DateTime> MinDate { get; set; }
        public Nullable<DateTime> MaxDate { get; set; }
        public int Count { get; set; }

    }
}
