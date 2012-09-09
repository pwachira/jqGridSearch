(function ($) {
    getColModels = function () {
        colModels = {
            archiveColModel: function () {
                return [
                            { name: 'Id', index: 'Headerrowtk', hidden: true, sortable: false },
                            { name: 'MessageControlId', index: 'MessageControlId', width: 100, sortable: false },
                            { name: 'MessageDateTime', search: false, index: 'MessageDateTime', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'SendingApplication', index: 'SendingApplication', width: 50, sortable: false },
                            { name: 'FacilityId', index: 'FacilityId', width: 50 },
                            { name: 'Location', index: 'Location', width: 50 },
                            { name: 'AccountNumber', index: 'AccountNumber', width: 100, align: 'right' },
                            { name: 'PatientName', index: 'PatientName', width: 50 },
                            { name: 'Mrn', index: 'Mrn', width: 100, align: 'right' },
                             { name: 'OrderControl', index: 'OrderControl', width: 50, align: 'center' },
                            { name: 'Condition', index: 'Condition', width: 50, align: 'center' },
                             { name: 'Priority', index: 'Priority', width: 50, align: 'center' },
                            { name: 'PrescriptionNumber', index: 'PrescriptionNumber', width: 50, align: 'right' },
                            { name: 'GiveCodeIdentifier', index: 'GiveCodeIdentifier', width: 50, align: 'right' },
                            { name: 'GiveCodeText', index: 'GiveCodeText', width: 150 },
                            { name: 'GiveCodeAltText', index: 'GiveCodeAltText', width: 150 },
                            { name: 'GiveAmount', index: 'GiveAmount', width: 100, align: 'right' },
                            { name: 'GiveUnits', index: 'GiveUnits', width: 50 },
                            { name: 'IntervalRepeat', index: 'IntervalRepeat', width: 50 },
                            { name: 'Route', index: 'Route', width: 50 },
                            { name: 'StartTime', search: false, index: 'StartTime', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'OrcStartTime', search: false, index: 'OrcStartTime', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'EndTime', search: false, index: 'EndTime', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'TransactionDate', search: false, index: 'TransactionDate', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'OrderEffectiveDate', search: false, index: 'OrderEffectiveDate', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'DataSource', index: 'DataSource', width: 150 },
                        ];
            },
            componentsColModel: function () {
                return [
                { name: 'Id', index: 'HeaderRowTk', width: 50, hidden: true, sorttype: 'int', formatter: 'integer' },
                { name: 'MessageControlId', index: 'MessageControlId', width: 50 },
                { name: 'OrderRowTk', index: 'OrderRowTk', width: 50 },
                { name: 'OrderRxcRowTk', index: 'OrderRxcRowTk', width: 50 },
                { name: 'ComponentType', index: 'ComponentType', width: 50 },
                { name: 'ComponentCodeId', index: 'ComponentCodeId', width: 50 },
                { name: 'ComponentCodeText', index: 'ComponentCodeText', width: 150 },
                { name: 'ComponentCodeAlt', index: 'ComponentCodeAlt', width: 50 },
                { name: 'ComponentCodeCoding', index: 'ComponentCodeCoding', width: 50 },
                { name: 'ComponentAmount', index: 'ComponentAmount', width: 50 },
                { name: 'ComponentUnits', index: 'ComponentUnits', width: 50 },
                { name: 'ComponentStrength', index: 'ComponentStrength', width: 50 },
                { name: 'ComponentStrengthUnits', index: 'ComponentStrengthUnits' },
                { name: 'FacilityId', index: 'FacilityId', width: '0' },
                { name: 'SendingApplication', index: 'SendingApplication', width: '0' }
                ];
            },
            distinctRxcColModel: function () {
                return [
                { name: 'OrderRxcRowTk', index: 'OrderRxcRowTk', width: 75 },
                { name: 'RxeDrugName', index: 'RxeDrugName', width: 75 },
                { name: 'RxeDrugCode', index: 'RxeDrugCode', width: 75 },
                { name: 'ComponentType', index: 'ComponentType', width: 75 },
                { name: 'ComponentCodeId', index: 'ComponentCodeId', width: 75 },
                { name: 'ComponentCodeText', index: 'ComponentCodeText', width: 75 },
                { name: 'Count', index: 'Count', align: 'right' },
                { name: 'SendingApplication', index: 'SendingApplication', width: '0' },
                { name: 'FacilityId', index: 'FacilityId', width: '0' }
                ];
            },

            timesColModel: function () {
                return [
                     { name: 'PctStartTime', index: 'PctStartTime', search: false, width: '100', align: 'right', sorttype: 'float',
                         formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                     },
                     { name: 'PctEndTime', index: 'PctEndTime', search: false, width: '100', align: 'right', sortable: false,
                         formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                     },
                     { name: 'PctOrdEffctTime', index: 'PctOrdEffctTime', search: false, sortable: false, width: '100', align: 'right',
                         formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                     },
                     { name: 'PctTrscTime', index: 'PctTrscTime', search: false, width: '100', align: 'right', sortable: false,
                         formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                     },
                     { name: 'PctMsgTime', index: 'PctMsgTime', search: false, width: '100', align: 'right', sortable: false,
                         formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                     },
                     { name: 'Count', index: 'Count', search: false, align: 'right' },
                     { name: 'OrderControl', index: 'OrderControl', width: '0' },
                //0 width fields just here for search purposes
                {name: 'FacilityId', index: 'FacilityId', width: '0' },
                { name: 'SendingApplication', index: 'SendingApplication', width: '0' }
                        ];
            },
            fieldsColModel: function () {
                return [
                            { name: 'OrderControl', index: 'OrderControl', width: '60' },
                            { name: 'Mrn', index: 'Mrn', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'Location', index: 'Location', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'PrescriptionNumber', index: 'PrescriptionNumber', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'GiveCodeIdentifier', index: 'GiveCodeIdentifier', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'GiveCodeText', index: 'GiveCodeText', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'GiveCodeAlternateText', index: 'GiveCodeAlternateText', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'GiveAmount', index: 'GiveAmount', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'GiveUnits', index: 'GiveUnits', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'IntervalRepeat', index: 'IntervalRepeat', width: '75', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'Route', index: 'Route', width: '50', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'DosageForm', index: 'DosageForm', width: '60', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                            { name: 'OrderingProvider', index: 'OrderingProvider', width: '60', align: 'right',
                                formatter: function (cellValue, options, rowObject) { return $.calcPct(cellValue, options, rowObject); }
                            },
                          { name: 'Count', index: 'Count', search: false, align: 'right' },
                          { name: 'SendingApplication', index: 'SendingApplication', width: '0' },
                          { name: 'FaciityId', index: 'FacilityId', width: '0' }
                        ];
            },
            ordersColModel: function () {
                return [
                            { name: 'Id', index: 'OrderId', width: 50 },
                            { name: 'ItemId', index: 'ItemId', width: 30 },
                            { name: 'MessageLDT', index: 'MessageLDT', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'SiteTk', index: 'SiteTk', width: 50 },
                            { name: 'Mrn', index: 'Mrn', width: 100 },
                            { name: 'Location', index: 'Location', width: 50 },
                            { name: 'PatientName', index: 'PatientName', width: 150 },
                            { name: 'OrderControl', index: 'OrderControl', width: 50 },
                            { name: 'PrescriptionNumber', index: 'PrescriptionNumber', width: 100, align: 'right' },
                            { name: 'UniquePrescriptionNumber', index: 'UniquePrescriptionNumber', width: 70, align: 'right' },
                            { name: 'SiteDrugCode', index: 'SiteDrugCode', width: 50 },
                            { name: 'SiteDrugName', index: 'SiteDrugName', width: 100 },
                            { name: 'Strength', index: 'Strength', width: 50, align: 'right' },
                            { name: 'Units', index: 'Units', width: 50 },
                            { name: 'RepeatPatternCode', index: 'RepeatPatternCode', searchoptions: colModels.searchoptions, width: 50 },
                            { name: 'SiteRouteCode', index: 'SiteRouteCode', searchoptions: colModels.searchoptions, width: 50 },
                            { name: 'DoctorName', index: 'DoctorName', searchoptions: colModels.searchoptions, width: 100 },
                            { name: 'OrderStartLDT', index: 'OrderStartLDT', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'OrderEndLDT', index: 'OrderEndLDT', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'TransactionLDT', index: 'TransactionLDT', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'OrderEffectiveLDT', index: 'OrderEffectiveLDT', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } }
                        ];
            },
            rxColModel: function () {

                return [
                            { name: 'Id', index: 'Id', width: 50, searchoptions: colModels.searchoptions },
                            { name: 'OrderId', index: 'OrderId', width: 50, searchoptions: colModels.searchoptions },
                            { name: 'PrescriptionNumber', index: 'PrescriptionNumber', width: 100 },
                            { name: 'UniquePrescriptionNumber', index: 'UniquePrescriptionNumber', width: 50 },
                            { name: 'SiteTk', index: 'SiteTk', width: 50 },
                            { name: 'MRN', index: 'MRN', width: 100 },
                            { name: 'Location', index: 'Location', width: 50 },
                            { name: 'SiteDrugCode', index: 'SiteDrugCode', width: 50 },
                            { name: 'SiteDrugName', index: 'SiteDrugName', width: 150 },
                            { name: 'SiteRouteCode', index: 'SiteRouteCode', width: 50 },
                            { name: 'RepeatPatternCode', index: 'RepeatPatternCode', width: 50 },
                            { name: 'isAutoDiscontinued', index: 'isAutoDiscontinued', width: 50 },
                            { name: 'Condition', index: 'Condition', width: 50 },
                            { name: 'Priority', index: 'Priority', width: 50 },
                            { name: 'MessageLDT', index: 'MessageLDT', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'PrescriptionStartLDT', index: 'PrescriptionStartLDT', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'PrescriptionStopLDT', index: 'PrescriptionStopLDT', width: 100, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
                            { name: 'DoctorName', index: 'DoctorName' }
                        ];
            },
            rxSubGridColModel: function () {
                return [
                { name: 'Id', index: 'PrescriptionId', sortable: false },
                { name: 'OrderId', index: 'OrderId', sortable: false },
                { name: 'ItemId', index: 'ItemId', sortable: false },
                { name: 'ChangeType', index: 'ChangeType', sortable: false },
                { name: 'RelatedPrescriptionId', index: 'RelatedPrescriptionId', sortable: false },
                { name: 'ChangeLDT', index: 'ChangeLDT', sortable: false, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } }
       ];
            },
            siteDrugsColModel: function () {

                return [
                { name: 'Id', index: 'Id', width: '50' },
                { name: 'InsertedLDT', index: 'InsertedLDT', search: false, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); }, width: '100' },
                { name: 'MappedLDT', index: 'MappedLDT', search: false, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); }, width: '100' },
                { name: 'SiteDrugCode', index: 'SiteDrugCode', width: '100', align: 'right' },
                { name: 'SiteDrugName', index: 'SiteDrugName', width: '300', sorttype: 'text' },
                { name: 'MappedPharmacyDrug', index: 'MappedPharmacyDrug', width: '150', editable: true, editoptions: { dataInit: function (el) {
                    $(el).autocomplete({ source: $('#Mapping').data('distinctDrugs'), minLength: 3, delay: 0 });
                }
                }
                },
                { name: 'Strength', index: 'Strength', width: '50', align: 'right' },
                { name: 'Units', index: 'Units', width: '50' },
                { name: 'MappedPharmacyUnit', index: 'MappedPharmacyUnit', width: '50', align: 'right' },
                { name: 'isReleased', index: 'isReleased', width: '75', editable: true, edittype: 'checkbox', align: 'center', formatter: 'checkbox' },
                { name: 'isReviewed', index: 'isReviewed', align: 'center', formatter: 'checkbox', disabled: false }
               ];
            },
            mapProfilesColModel: function (options) {

                return [
            { name: 'NewTreatmentProfileName', index: 'NewTreatmentProfileName',
                editable: true, editoptions: { dataInit: function (el) {
                    //TODO use options to bring in the table element data
                    $(el).autocomplete({ source: $('#MapTable').data('TreatmentProfileName'), minLength: 3, delay: 0 });
                }
                }
            },
            { name: 'Id', index: 'TreatmentProfileId', width: '50', align: 'right' },
            { name: 'TreatmentProfileName', index: 'TreatmentProfileName' },
            { name: 'InsertNew', index: 'InsertNew', width: '25' },
            { name: 'Changed', index: 'Changed', width: '25' },
            { name: 'PharmacyDrugId', index: 'PharmacyDrugId', width: '50', align: 'right' },
            { name: 'MappedPharmacyDrug', index: 'MappedPharmacyDrug' },
            { name: 'MappedPharmacyUnit', index: 'MappedPharmacyUnit', width: '50' },
            { name: 'MappedPharmacyRoute', index: 'MappedPharmacyRoute', width: '50' },
            { name: 'PharmacyClassName', index: 'PharmacyClassName', width: '50' },
            { name: 'Lineage', index: 'Lineage' }
            ];
            },
            facilitySplitColModel: function () {

                return [
            { name: 'SiteTk', index: 'SiteTk' },
            { name: 'FacilityCode', index: 'FacilityCode' },
            { name: 'Site', index: 'Site' },
            { name: 'Name', index: 'Name' }
           ];
            },
            minMaxColModel: function () {

                return [
          { name: 'FacilityId', index: 'FacilityId', width: '50' },
          { name: 'SendingApplication', index: 'SendingApplication', width: '50' },
          { name: 'OrderControl', index: 'OrderControl', width: '50' },
         { name: 'MinStartTime', index: 'MinStartTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
         { name: 'MaxStartTime', index: 'MaxStartTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
         { name: 'MinEndTime', index: 'MinEndTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
         { name: 'MaxEndTime', index: 'MaxEndTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
         { name: 'MinOrdEffctTime', index: 'MinOrdEffctTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
         { name: 'MaxOrdEffctTime', index: 'MaxOrdEffctTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
         { name: 'MinTrscTime', index: 'MinTrscTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
          { name: 'MaxTrscTime', index: 'MaxTrscTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
         { name: 'MinMsgTime', index: 'MinMsgTime', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
         { name: 'MaxMsgTime', index: 'MaxMsgTime', search: false, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } }
          ];
            },
            routesColModel: function () {

                return [
          { name: 'Id', index: 'SiteRouteId', width: '100' },
          { name: 'SiteRouteCode', index: 'SiteRouteCode', width: '100' },
          { name: 'InsertedLDT', index: 'InsertedLDT', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
          { name: 'ModifiedLDT', index: 'ModifiedLDT', search: false, width: '100', formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
          { name: 'MappedPharmacyRoute', index: 'MappedPharmacyRoute' }

            ];
            },

            drugRoutesColModel: function () {

                return [
          { name: 'Id', index: 'Id', width: '100' },
          { name: 'SiteRouteId', index: 'SiteRouteId', width: '100' },
          { name: 'SiteRouteCode', index: 'SiteRouteCode', width: '100' },
          { name: 'SiteDrugName', index: 'SiteDrugName', width: '100' },
          { name: 'PharmacyDrugId', index: 'PharmacyDrugId' },
          { name: 'MappedPharmacyDrug', index: 'MappedPharmacyDrug' },
          { name: 'TreatmentProfile', index: 'TreatmentProfile' }

            ];
            },
            orderCtrlColModel: function () {
                return [
          { name: 'OrderControlDesc', index: 'OrderControl' },
          { name: 'MinDate', index: 'MinDate', search: false, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
          { name: 'MaxDate', index: 'MaxDate', search: false, formatter: function (cellval) { return $.formatDate(cellval, 'MM/dd/yy HH:mm'); } },
          { name: 'Count', index: 'Count', align: 'right', search: false },
          { name: 'SendingApplication', index: 'SendingApplication', width: '0' },
          { name: 'FacilityId', index: 'FacilityId', width: '0' }
                ];
            },

     pharmDrugsColModel: function () {
                return [
          { name: 'Id', index: 'Id' },
          { name: 'MappedPharmacyDrug', index: 'MappedPharmacyDrug' },
          { name: 'TreatmentProfileName', index: 'TreatmentProfileName', editable: true, editoptions: {
              dataInit: function (el) {
                 $(el).autocomplete({source: _.pluck($('#ClassTable').data('TreatmentProfileName'), 'TreatmentProfileName'),
                      delay:1,
                      minLength:3}); 
                     }
                }
          },
          { name: 'MappedPharmacyUnit', index: 'MappedPharmacyUnit' },
          { name: 'MappedPharmacyRoute', index: 'MappedPharmacyRoute' },
          { name: 'TreatmentProfileId', index: 'TreatmentProfileId', align: 'right' },
          { name: 'PharmacyDrugProperties', index: 'PharmacyDrugProperties', align: 'right' },
          { name: 'PharmacyClassName', index: 'PharmacyClassName',width: '0' },
                ];
            },

            partialDrugsColModel: function () {
                return [

                ];
            },

            profilesColModel: function () {
                return [

                ];
            },

            classesColModel: function () {
                return [

                ];
            }
        }


        return {
            archiveColModel: colModels.archiveColModel,
            componentsColModel: colModels.componentsColModel,
            distinctRxcColModel: colModels.distinctRxcColModel,
            drugRoutesColModel: colModels.drugRoutesColModel,
            facilitySplitColModel: colModels.facilitySplitColModel,
            fieldsColModel: colModels.fieldsColModel,
            mapProfilesColModel: colModels.mapProfilesColModel,
            ordersColModel: colModels.ordersColModel,
            routesColModel: colModels.routesColModel,
            rxColModel: colModels.rxColModel,
            rxSubGridColModel: colModels.rxSubGridColModel,
            siteDrugsColModel: colModels.siteDrugsColModel,
            timesColModel: colModels.timesColModel,
            minMaxColModel: colModels.minMaxColModel,
            orderCtrlColModel: colModels.orderCtrlColModel,
            pharmDrugsColModel: colModels.pharmDrugsColModel
        };
    };
})(jQuery);