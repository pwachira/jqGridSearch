using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Pharmacy.linq;
using JqGridFilter.Helpers;

namespace Pharmacy
{
    public static class QueryRepo
    {
        /* internal QueryRepo()
         { 
         }
         */
        internal static TimeStats FilteredTimeStats(IQueryable<Order> orders, string sidx, string sord)
        {
            int count = orders.Count();
            return new TimeStats
            {
                PctEndTime = orders.Count(a => a.EndTime != null),
                PctMsgTime = orders.Count(g => g.MessageDateTime != null),
                PctOrdEffctTime = orders.Count(g => g.OrderEffectiveDate != null),
                PctStartTime = orders.Count(g => g.StartTime != null),
                PctTrscTime = orders.Count(g => g.TransactionDate != null),
                Count = count
            };
        }


        internal static List<FieldStats> FilteredFieldStats(IQueryable<Order> filteredOrders, string sord, string sidx)
        {
            return filteredOrders.GroupBy(g => g.OrderControl, (oc, orders) => new FieldStats
            {
                OrderControl = oc,
                DosageForm = orders.Count(o2 => o2.GiveDosageForm.Length > 0),
                GiveAmount = orders.Count(o2 => o2.GiveAmount.Length > 0),
                GiveCodeAlternateText = orders.Count(o2 => o2.GiveCodeAltText.Length > 0),
                GiveCodeIdentifier = orders.Count(o2 => o2.GiveCodeIdentifier.Length > 0),
                GiveCodeText = orders.Count(o2 => o2.GiveCodeText.Length > 0),
                GiveUnits = orders.Count(o2 => o2.GiveUnits.Length > 0),
                IntervalRepeat = orders.Count(o2 => o2.IntervalRepeat.Length > 0),
                Location = orders.Count(o2 => o2.Location.Length > 0),
                Mrn = orders.Count(o2 => o2.Mrn.Length > 0),
                OrderingProvider = orders.Count(o2 => o2.OrderingProvider.Length > 0),
                PrescriptionNumber = orders.Count(o2 => o2.PrescriptionNumber.Length > 0),
                Route = orders.Count(o2 => o2.Route.Length > 0),
                Count = orders.Count()
            }).ToList();
        }

        internal static IQueryable<Order> qryableArchOrders(ArchiveClassesDataContext archdc, DateTime Start, DateTime End)
        {
            return archdc.DtsRdeOrdersStdArchives.Where(o => o.DtsRdeStdArchive.messageDateTime <= End.AddDays(1)
                                                           && o.DtsRdeStdArchive.messageDateTime >= Start)
                                                      .Select(o1 => new Order
                                                      {
                                                          Id = o1.headerRow_tk,
                                                          MessageControlId = o1.DtsRdeStdArchive.messageControlId,
                                                          SendingApplication = o1.DtsRdeStdArchive.sendingApplication,
                                                          FacilityId = o1.DtsRdeStdArchive.facilityId,
                                                          Location = o1.DtsRdeStdArchive.location,
                                                          MessageDateTime = (Nullable<DateTime>)o1.DtsRdeStdArchive.messageDateTime,
                                                          GiveCodeIdentifier = o1.rxe_GiveCode_Identifier,
                                                          GiveCodeText = o1.rxe_GiveCode_Text,
                                                          GiveCodeAltText = o1.rxe_GiveCode_AlternateText,
                                                          AccountNumber = o1.DtsRdeStdArchive.patientAccountNumber,
                                                          EndTime = (Nullable<DateTime>)o1.rxe_QuantityTiming_EndTime,
                                                          GiveAmount = o1.rxe_MinimumGiveAmount,
                                                          GiveUnits = o1.rxe_GiveUnits,
                                                          IntervalRepeat = o1.rxe_QuantityTiming_IntervalRepeatPattern,
                                                          Mrn = o1.DtsRdeStdArchive.patient,
                                                          OrderControl = o1.orderControl,
                                                          Condition = o1.rxe_QuantityTiming_Condition,
                                                          Priority = o1.rxe_QuantityTiming_Priority,
                                                          OrderEffectiveDate = (Nullable<DateTime>)o1.orderEffectiveDate,
                                                          PatientName = o1.DtsRdeStdArchive.patientName,
                                                          PrescriptionNumber = o1.prescriptionNumber,
                                                          Route = o1.rxr_Route,
                                                          GiveDosageForm = o1.rxe_GiveDosageForm,
                                                          OrderingProvider = o1.orderingProviderName,
                                                          StartTime = (Nullable<DateTime>)o1.rxe_QuantityTiming_StartTime,
                                                          TransactionDate = (Nullable<DateTime>)o1.transactionDate
                                                      }).OrderBy(o1 => o1.MessageDateTime);

        }
        internal static IQueryable<DmssOrder> qryableDmssOrders(DmssClassesDataContext dc, DateTime Start, DateTime End)
        {
            return dc.CSS_RxOrderDetails.Where(o => o.CSS_RxOrder.MessageLDT >= Start && o.CSS_RxOrder.MessageLDT <= End.AddDays(1))
                                                    .Select(o1 => new DmssOrder
                                                    {
                                                        DoctorName = o1.CSS_SiteDoctor.DoctorName,
                                                        ItemId = o1.ItemId,
                                                        Location = o1.CSS_RxOrder.Location,
                                                        MessageLDT = o1.CSS_RxOrder.MessageLDT,
                                                        Mrn = o1.CSS_RxOrder.MRN,
                                                        OrderControl = o1.CSS_SiteOrderControl.OrderControlCode,
                                                        OrderEffectiveLDT = o1.OrderEffectiveLDT,
                                                        OrderEndLDT = o1.original_OrderStopLDT,
                                                        Id = o1.OrderId,
                                                        OrderStartLDT = o1.original_OrderStartLDT,
                                                        PatientName = o1.CSS_RxOrder.PatientName,
                                                        PrescriptionNumber = o1.PrescriptionNumber,
                                                        RepeatPatternCode = o1.CSS_IntervalRepeatPattern.RepeatPatternCode,
                                                        SiteDrugCode = o1.CSS_SiteDrug.SiteDrugCode,
                                                        SiteDrugName = o1.CSS_SiteDrug.SiteDrugName,
                                                        SiteRouteCode = o1.CSS_SiteRoute.SiteRouteCode,
                                                        SiteTk = o1.site_tk,
                                                        Strength = o1.CSS_SiteDrug.Strength,
                                                        TransactionLDT = o1.CSS_RxOrder.TransactionLDT,
                                                        UniquePrescriptionNumber = o1.UniquePrescriptionNumber,
                                                        Units = o1.CSS_SiteDrug.Units
                                                    });

        }

        internal static IQueryable<Prescription> qryableDmssRx(DmssClassesDataContext dc, DateTime Start, DateTime End)
        {
            return dc.CSS_Prescriptions.Where(p => p.MessageLDT >= Start && p.MessageLDT <= End.AddDays(1))
                .Select(p2 => new Prescription
                {
                    Condition = p2.CSS_SiteDrugCondition.SiteDrugConditionCode,
                    DoctorName = p2.CSS_SiteDoctor.DoctorName,
                    isAutoDiscontinued = p2.isAutoDiscontinued,
                    Location = p2.Location,
                    MessageLDT = p2.MessageLDT,
                    MRN = p2.MRN,
                    OrderId = (int)p2.OrderId,
                    Id = p2.PrescriptionId,
                    PrescriptionNumber = p2.PrescriptionNumber,
                    PrescriptionStartLDT = p2.PrescriptionStartLDT,
                    PrescriptionStopLDT = p2.PrescriptionStopLDT,
                    Priority = p2.CSS_SiteDrugPriority.SiteDrugPriorityCode,
                    RepeatPatternCode = p2.CSS_IntervalRepeatPattern.RepeatPatternCode,
                    SiteDrugCode = p2.CSS_SiteDrug.SiteDrugCode,
                    SiteDrugName = p2.CSS_SiteDrug.SiteDrugName,
                    SiteRouteCode = p2.CSS_SiteRoute.SiteRouteCode,
                    SiteTk = p2.site_tk,
                    UniquePrescriptionNumber = p2.UniquePrescriptionNumber
                }).OrderBy(p3 => p3.MessageLDT);

        }


        internal static IQueryable<PrescriptionHistory> qryableRxHx(DmssClassesDataContext dc, int rxId)
        {
            return dc.CSS_PrescriptionChangeHistories.Where(p => p.PrescriptionId == rxId)
                .Select(p2 => new PrescriptionHistory
                {
                    Id = p2.PrescriptionId,
                    OrderId = (Nullable<int>)p2.OrderId,
                    ItemId = (Nullable<int>)p2.ItemId,
                    ChangeType = p2.ChangeType,
                    ChangeLDT = (Nullable<DateTime>)p2.ChangeLDT,
                    RelatedPrescriptionId = (int)p2.relatedTreatmentPrescriptionId
                }).OrderBy(p3 => p3.ChangeLDT);

        }

        internal static IQueryable<SiteDrug> QryableSiteDrugs(DmssClassesDataContext dc, DateTime Start, DateTime End)
        {
            return dc.CSS_SiteDrugs.Where(s => s.InsertedLDT > Start && s.InsertedLDT < End.AddDays(1)).Select(d => new SiteDrug
            {
                InsertedLDT = d.InsertedLDT,
                MappedLDT = d.MappedLDT,
                isReleased = d.isReleased,
                isReviewed = d.isReviewed,
                MappedPharmacyDrug = d.MappedPharmacyDrug,
                MappedPharmacyUnit = d.MappedPharmacyUnit,
                SiteDrugCode = d.SiteDrugCode,
                Id = d.SiteDrugId,
                SiteDrugName = d.SiteDrugName,
                Strength = d.Strength,
                Units = d.Units
            }).OrderBy(s => s.InsertedLDT);
        }

        internal static IQueryable<Component> qryableComponents(ArchiveClassesDataContext adc, int HdrTk, DateTime Start, DateTime End)
        {
            var cpnts = adc.DtsRdeOrdersRxcStdArchives
                .Where(c => c.DtsRdeOrdersStdArchive.DtsRdeStdArchive.messageDateTime >= Start &&
                    c.DtsRdeOrdersStdArchive.DtsRdeStdArchive.messageDateTime <= End.AddDays(1))
                .Select(c2 => new Component
                {
                    Id = (int)c2.headerRow_tk,
                    FacilityId = c2.DtsRdeOrdersStdArchive.DtsRdeStdArchive.facilityId,
                    SendingApplication = c2.DtsRdeOrdersStdArchive.DtsRdeStdArchive.sendingApplication,
                    MessageControlId = c2.DtsRdeOrdersStdArchive.DtsRdeStdArchive.messageControlId,
                    OrderRowTk = c2.orderRow_tk,
                    OrderRxcRowTk = c2.orderRxcRow_tk,
                    RxeDrugName = c2.DtsRdeOrdersStdArchive.rxe_GiveCode_Text,
                    ComponentAmount = c2.RDE_Orders_RXC_ComponentAmount,
                    ComponentCodeAlt = c2.RDE_Orders_RXC_ComponentCodeAlternateText,
                    ComponentCodeCoding = c2.RDE_Orders_RXC_ComponentCodeNameOfCodingSystem,
                    ComponentCodeId = c2.RDE_Orders_RXC_ComponentCodeIdentifier,
                    ComponentCodeText = c2.RDE_Orders_RXC_ComponentCodeText,
                    ComponentStrength = c2.RDE_Orders_RXC_ComponentStrength,
                    ComponentUnits = c2.RDE_Orders_RXC_ComponentUnitsIdentifier,
                    ComponentStrengthUnits = c2.RDE_Orders_RXC_ComponentStrengthUnitsText,
                    ComponentType = c2.RDE_Orders_RXC_RxComponentType
                });
            if (HdrTk == 0)
            {
                return cpnts;
            }
            else
            {
                return cpnts.Where(c => c.Id == HdrTk);
            }
        }

        /* internal IQueryable<ProfileForMap> QryableMapProfiles(CssPharmDataContext pdc, DateTime Start, DateTime End)
         {
             return pdc.CSS_PharmacyClassCombos.Where(c => c. > Start && t.InsertedUDT < End.AddDays(1))
                 .Select(t=>new ProfileForMap { 
                 Changed = new byte(),
                 InsertNew =  new byte(),
                 Lineage = "",
                 MappedpharmacyRoute = t.                
                 });
         }*/

        internal static List<ArchiveMinMax> FilteredMinMax(IQueryable<Order> o, string sidx, string sord)
        {
            return o.GroupBy(g => new { g.SendingApplication, g.OrderControl, g.FacilityId }
        , (a, d) => new ArchiveMinMax
        {
            OrderControl = a.OrderControl,
            FacilityId = a.FacilityId,
            SendingApplication = a.SendingApplication,
            MaxEndTime = (Nullable<DateTime>)d.Max(g => g.EndTime),
            MaxMsgTime = (Nullable<DateTime>)d.Max(g => g.MessageDateTime),
            MaxOrdEffctTime = (Nullable<DateTime>)d.Max(g => g.OrderEffectiveDate),
            MaxStartTime = (Nullable<DateTime>)d.Max(g => g.StartTime),
            MaxTrscTime = (Nullable<DateTime>)d.Max(g => g.TransactionDate),
            MinEndTime = (Nullable<DateTime>)d.Min(g => g.EndTime),
            MinMsgTime = (Nullable<DateTime>)d.Min(g => g.MessageDateTime),
            MinOrdEffctTime = (Nullable<DateTime>)d.Min(g => g.OrderEffectiveDate),
            MinStartTime = (Nullable<DateTime>)d.Min(g => g.StartTime),
            MinTrscTime = (Nullable<DateTime>)d.Min(g => g.TransactionDate),
        }).OrderBy<ArchiveMinMax>(sidx, sord).ToList();
        }



        internal static IQueryable<SiteDrugRoute> QryableSiteDrugRoutes(DmssClassesDataContext ddc)
        {
            return ddc.CSS_SiteDrugRoutes.Select(sdr => new SiteDrugRoute
            {
                PharmacyDrugId = (int)sdr.PharmacyDrugId,
                Id = sdr.SiteDrugId,
                SiteDrugName = sdr.CSS_SiteDrug.SiteDrugName,
                SiteRouteCode = sdr.CSS_SiteRoute.SiteRouteCode,
                SiteRouteId = sdr.SiteRouteId
            });
        }

        internal static IQueryable<Component> qryableRxcDistinct(ArchiveClassesDataContext adc, IQueryable<Component> components)
        {

            return components.GroupBy(c => new {  c.ComponentCodeText, c.ComponentType,  c.OrderRxcRowTk, c.RxeDrugName }
                 , (c2, g) => new Component
                 {
                     RxeDrugName = c2.RxeDrugName,
                     OrderRxcRowTk = c2.OrderRxcRowTk,
                     ComponentCodeText = c2.ComponentCodeText,
                     ComponentType = c2.ComponentType,
                     Count = g.Count()
                 });

        }

        internal static List<OrderControl> DistinctOrderControls(IQueryable<Order> o, string sidx, string sord)
        {
            return o.GroupBy(a => a.OrderControl, (b, c) => new OrderControl
            {
                OrderControlDesc = b,
                MaxDate = c.Max(d => d.MessageDateTime),
                MinDate = c.Min(d => d.MessageDateTime),
                Count = c.Count()
            }).AsQueryable().OrderBy<OrderControl>(sidx, sord).ToList();
        }

        internal static IQueryable<PharmacyDrug> PharmDrugs( CssPharmDataContext dc)
        {
            return dc.CSS_PharmacyDrugs.Select(p => new PharmacyDrug 
            { 
            MappedPharmacyDrug = p.MappedPharmacyDrug,
            MappedPharmacyRoute = p.MappedPharmacyRoute,
            MappedPharmacyUnit = p.MappedPharmacyUnit,
            Id = p.PharmacyDrugId,
            PharmacyDrugProperties = p.PharmacyDrugProperties,
            TreatmentProfileId = p.TreatmentProfileId,
            TreatmentProfileName =p.CSS_TreatmentProfile.TreatmentProfileName
            });
            
            
        }
    }
}
