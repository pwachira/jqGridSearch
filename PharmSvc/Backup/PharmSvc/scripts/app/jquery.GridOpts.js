(function($) {
    //app = window.app || {};
    getGridOpts = function() {
        var pharmMthds = {
            drugChangesArray: [],
            setDefaultGridOptions: function() {
                $.extend($.jgrid.defaults, {
                    jsonReader: { repeatitems: false, cell: "", id: 'Id', root: 'd.rows', page: 'd.page', total: 'd.total', records: 'd.records' },
                    ajaxGridOptions: { contentType: 'application/json;charset=utf-8' },
                    serializeGridData: function(postData) { return JSON.stringify(postData); },
                    mtype: 'POST', datatype: 'local', rowNum: 22, viewrecords: true,
                    sortable: true,
                    altRows: true, altclass: 'GridAlt',
                    gridview: true, rownumbers: true,
                    cellEdit: true, cellsubmit: 'clientArray',
                    scroll: 1,
                    width: 'auto', height: '100',
                    data: [{}, {}, {}],
                    cmTemplate: { searchoptions: { sopt: ['cn', 'eq', 'ne']} },
                    loadError: function(xhr, st, err) {
                        alert("Error ,Type: " + st + "; Response: " + xhr.status + " " + xhr.statusText);
                    }
                });
            },

            defaultSimpleGridOptions: function() {
                return {
                    jsonReader: { repeatitems: false, cell: '', id: '0', root: function(obj) { return obj.d; }, page: function(obj) { return 1; }, records: function(obj) { return obj.d.length; } }
                };
            },


            pushChangedCells: function(changedCells) {
                for (i = 0; i < changedCells.length; i++) {
                    for (j = 0; j < DrugChangesArray.length; j++) {
                        if (changedCells[i].SiteDrugId === DrugChangesArray[j].SiteDrugId) {
                            DrugChangesArray.splice(j, 1);
                        }
                    }
                    DrugChangesArray.push(changedCells[i]);
                }
                return DrugChangesArray;
            },
            siteRoutesGridOpts: function(options) {
                var rtColModel = getColModels().routesColModel();
                return {
                    url: 'PharmService.asmx/SiteRoutes',
                    colNames: ['SiteRouteId', 'SiteRouteCode', 'InsertedLDT', 'ModifiedLDT', 'MappedPharmacyRoute'],
                    colModel: rtColModel,
                    sortorder: 'ASC',
                    sortname: 'Id',
                    caption: 'SiteRoutes',
                    pager: options.pager,
                    scroll: false
                };
            },
            siteDrugRoutesGridOpts: function(options) {
                var drColModel = getColModels().drugRoutesColModel();
                return {
                    url: 'PharmService.asmx/SiteDrugRoutes',
                    colNames: ['Id', 'SiteRouteId', 'SiteRouteCode', 'SiteDrugName', 'PharmacyDrugId'],
                    colModel: drColModel,
                    sortorder: 'ASC',
                    sortname: 'Id',
                    caption: 'SiteDrugRoutes',
                    pager: options.pager,
                    scroll: false
                };
            },
            facilitySplitGridOpts: function(options) {
                var fColModel = getColModels().facilitySplitColModel();
                return {
                    url: 'PharmService.asmx/FacilitySplit',
                    colNames: ['SiteTk', 'FacilityCode', 'Site', 'Name'],
                    colModel: fColModel,
                    sortorder: 'ASC',
                    sortname: 'SiteTk',
                    caption: 'Facility Split-SiteCodes',
                    pager: options.pager
                };
            },

            archMinMaxGridOpts: function(options) {
                var minMaxColModel = getColModels().minMaxColModel();
                return $.extend(pharmMthds.defaultSimpleGridOptions(), {
                    url: "PharmService.asmx/ArchiveMinMax",
                    colNames: ['FacilityId', 'SendingApplication', 'OrderControl', 'MinStart', 'MaxStart', 'MinEnd', 'MaxEnd',
              'MinEfctvDate', 'MaxEfctvDate', 'MinTrscDate', 'MaxTrscDate', 'MinMsgDate', 'MaxMsgDate'
            ],
                    colModel: minMaxColModel,
                    sortorder: 'ASC',
                    rowNum: 50,
                    sortname: 'FacilityId',
                    caption: 'MinMaxDates',
                    pager: options.pager
                });
            },
            mapProfilesGridOpts: function(options) {
                var tpColModel = getColModels().mapProfilesColModel();
                return {
                    url: 'PharmService.asmx/MapProfiles',
                    jsonReader: { repeatitems: false, cell: "", id: 'PharmacyDrugId', root: 'd.rows', page: 'd.page', total: 'd.total', records: 'd.records' },
                    colNames: ['NewTreatmentProfileName', 'TreatmentProfileId', 'TreatmentProfileName', 'InsertNew',
                'Changed', 'PharmacyDrugId', 'MappedPharmacyDrug', 'MappedPharmacyUnit',
                'MappedPharmacyRoute', 'PharmacyClassName', 'Lineage'],
                    colModel: tpColModel,
                    rowNum: 50,
                    sortorder: 'DESC',
                    sortname: 'PharmacyDrugId',
                    caption: 'Profiles',
                    pager: options.pager,
                    afterSaveCell: function() {
                        console.log($('#MapTable').jqGrid('getChangedCells'));

                    }
                };
            },
            siteDrugsGridOpts: function(options) {
                var sdColModel = getColModels().siteDrugsColModel();
                return {
                    url: 'PharmService.asmx/SiteDrugs',
                    colNames: ['Id', 'InsertedLDT', 'MappedLDT', 'SiteDrugCode', 'SiteDrugName', 'MappedPharmacyDrug', 'Strength', 'Units', 'MappedPharmacyUnit', 'isReleased', 'isReviewed'],
                    colModel: sdColModel,
                    sortorder: 'ASC',
                    sortname: 'Id',
                    caption: 'SiteDrugs',
                    pager: options.pager,
                    scroll: false
                };
            },
            archiveSubgridOpts: function(row_id, subgridpager, form) {
                var opts = getColModels().componentsColModel(),
                frm = form.serializeForm(),
                pdata = $.extend(frm, { HdrTk: parseInt(row_id, 10), Start: '1/1/1970', End: '12/12/2079', filters: "{}" });
                return {
                    url: 'PharmService.asmx/GetComponents',
                    postData: pdata,
                    colNames: ['HeaderRowTk', 'MessageControlId', 'OrderRowTk', 'OrderRxcRowTk', 'ComponentType', 'ComponentCodeId',
                    'ComponentCodeText', 'ComponentCodeAlt', 'ComponentCodeCoding', 'ComponentAmount', 'ComponentUnits', 'ComponentStrength', 'ComponentStrengthUnits', 'SendingApplication', 'FacilityId'],
                    colModel: opts,
                    sortorder: 'ASC',
                    sortname: 'Id',
                    toppager: false,
                    datatype: 'json',
                    pager: subgridpager,
                    scroll: false,
                    caption: 'RXC-Components'
                };
            },

            rxSubgridOpts: function(row_id, subgridpager) {
                var opts = getColModels().rxSubGridColModel(), form = $('#siteForm').serializeForm(), pdata = $.extend(form, { RxId: parseInt(row_id, 10) });
                return {
                    url: 'PharmService.asmx/GetRxHx',
                    datatype: 'json',
                    toppager: false,
                    postData: pdata,
                    colNames: ['PrescriptionId', 'OrderId', 'ItemId', 'ChangeType', 'RelatedPrescriptionId', 'ChangeLDT'],
                    colModel: opts,
                    sortorder: 'ASC',
                    sortname: 'Id',
                    pager: subgridpager,
                    scroll: false,
                    caption: 'PrescriptionHistory'
                };

            },

            componentsGridOpts: function(options) {
                var opts = getColModels().componentsColModel();
                return {
                    url: 'PharmService.asmx/GetComponents',
                    colNames: ['HeaderRowTk', 'MessageControlId', 'OrderRowTk', 'OrderRxcRowTk', 'Type', 'CodeId',
                'CodeText', 'CodeAlt', 'CodeCoding', 'Amount', 'Units', 'Strength', 'StrengthUnits', 'FacilityId', 'SendingApplication'],
                    colModel: opts,
                    cmTemplate: { searchoptions: { sopt: ['eq', 'ne', 'cn']} },
                    caption: 'RXC-Components',
                    pager: options.pager,
                    scroll: false,
                    postData: { HdrTk: 0 },
                    sortorder: 'ASC',
                    sortname: 'Id',
                    grouping: true,
                    groupingView: {
                        groupField: ['OrderRxcRowTk'],
                        groupDataSorted: true
                    }
                };
            },
            distinctRxcGridOpts: function(options) {
                var opts = getColModels().distinctRxcColModel();
                return {
                    url: 'PharmService.asmx/DistinctRxc',
                    colNames: ['OrderRxcRowTk', 'RxeDrugName', 'Type',
                    'CodeText', 'Total', 'SendingApplication', 'FacilityId'],
                    colModel: opts,
                    postdata: { HdrTk: 0 },
                    caption: 'DistinctRXC',
                    pager: options.pager,
                    scroll: false,
                    sortorder: 'ASC',
                    sortname: 'OrderRxcRowTk'
                };
            },
            archiveGridOptions: function(options) {
                var opts = getColModels().archiveColModel();
                return {
                    url: 'PharmService.asmx/GetArchiveOrders',
                    colNames: ['Headerrowtk', 'MessageControlId', 'MessageDateTime', 'SendingApplication', 'FacilityId',
                'Location', 'AccountNumber', 'PatientName', 'Mrn', 'OrderControl', 'Condition', 'Priority',
                'PrescriptionNumber', 'GiveCodeIdentifier', 'GiveCodeText', 'GiveCodeAltText', 'GiveAmount', 'GiveUnits',
                'IntervalRepeat', 'Route', 'StartTime', 'EndTime', 'TransactionDate', 'OrderEffectiveDate'],
                    colModel: opts,
                    caption: 'ArchiveOrders',
                    pager: options.pager,
                    scroll: false,
                    sortorder: 'ASC',
                    sortname: 'MessageDateTime',
                    subGrid: true,
                    subGridRowExpanded: function(subgrid_id, row_id) {
                        var subgrid_table_id, subgridpager, subgridOpts;
                        subgrid_table_id = subgrid_id + "_t";
                        subgridpager = "subgridpager_" + subgrid_id;
                        subgridOpts = pharmMthds.archiveSubgridOpts(row_id, subgridpager, $('#siteForm'));
                        $("#" + subgrid_id).html("<table id= '" + subgrid_table_id + "'class='scroll'></table><br/><div id=" + subgridpager + "/>");
                        return $("#" + subgrid_table_id).jqGrid(subgridOpts).jqGrid('gridResize');
                    }
                };
            },

            timesGridOpts: function(options) {
                var timeColModel = getColModels().timesColModel();
                return $.extend(pharmMthds.defaultSimpleGridOptions(), {
                    url: "PharmService.asmx/GetTimeStats",
                    colNames: ['%StartDate', '%EndDate',
            '%EfctvDate', '%TrscDate', '%MsgDate', 'Total', 'OrderControl', 'FacilityId', 'SendingApplication'
            ],
                    colModel: timeColModel,
                    sortorder: 'ASC',
                    rowNum: 50,
                    sortname: 'FacilityId',
                    caption: 'TimeStats',
                    pager: options.pager
                });
            },

            fieldsGridOpts: function(options) {
                var fieldsColModel = getColModels().fieldsColModel();
                return $.extend(pharmMthds.defaultSimpleGridOptions(), {
                    url: "PharmService.asmx/GetFieldStats",
                    colNames: ['OrderControl', 'Mrn', 'Location', 'PrescriptionNumber', 'GiveCodeIdentifier', 'GiveCodeText', 'GiveCodeAlternateText',
                    'GiveAmount', 'GiveUnits', 'IntervalRepeat', 'Route', 'DosageForm', 'OrderingProvider', 'Total', 'SendingApplication', 'FacilityId'],
                    colModel: fieldsColModel,
                    sortorder: 'ASC',
                    sortname: 'OrderControl',
                    caption: 'Data%',
                    pager: options.pager
                });
            },
            orderControlGridOpts: function(options) {
                var ocColModel = getColModels().orderCtrlColModel();
                return $.extend(pharmMthds.defaultSimpleGridOptions(), {
                    url: "PharmService.asmx/DistinctOrderControls",
                    colNames: ['OrderControl', 'MinDate', 'MaxDate', 'Total', 'SendingApplication', 'FacilityId'],
                    colModel: ocColModel,
                    sortorder: 'ASC',
                    sortname: 'OrderControlDesc',
                    caption: 'OrderControls',
                    pager: options.pager
                });
            },
            ordersGridOpts: function(options) {
                var ordersColModel = getColModels().ordersColModel();
                return {
                    url: 'PharmService.asmx/GetOrders',
                    colNames: ['OrderId', 'ItemId', 'MessageLDT', 'SiteTk', 'Mrn', 'Location', 'PatientName',
            'OrderControl', 'PrescriptionNumber', 'UniquePrescriptionNumber', 'SiteDrugCode', 'SiteDrugName', 'Strength',
            'Units', 'RepeatPatternCode', 'SiteRouteCode', 'DoctorName', 'OrderStartLDT', 'OrderEndLDT',
            'TransactionLDT', 'OrderEffectiveLDT'],
                    colModel: ordersColModel,
                    sortorder: 'ASC',
                    sortname: 'Id',
                    caption: 'DMSSOrders',
                    rowNum: 15,
                    pager: options.pager
                };
            },
            siteListGridOpts: function(options) {

                return {
                    datatype: 'local',
                    colNames: ['SiteCode'],
                    colModel: [{ name: 'SiteCode', index: 'SiteCode'/*, formatter: function(cellVal) {
                        return '<a href="#"class = "SiteLink" >' + cellVal + '</a>';
                    } */}],
                        sortorder: 'ASC',
                        sortname: 'SiteCode',
                        caption: 'Sites',
                        //rowNum: 400,
                        width: '150'
                    };
                },

                rxGridOpts: function(options) {
                    var rxColModel = getColModels().rxColModel();
                    return {
                        url: 'PharmService.asmx/GetRx',
                        colNames: ['PrescriptionId', 'OrderId', 'PrescriptionNumber', 'UniquePrescriptionNumber', 'SiteTk', 'MRN',
            'Location', 'SiteDrugCode', 'SiteDrugName', 'SiteRouteCode', 'RepeatPatternCode', 'isAutoDiscontinued', 'Condition',
            'Priority', 'MessageLDT', 'PrescriptionStartLDT', 'PrescriptionStopLDT', 'DoctorName'],
                        colModel: rxColModel,
                        caption: 'Prescriptions',
                        sortorder: 'ASC',
                        sortname: 'Id',
                        rowNum: 15,
                        pager: options.pager,
                        scroll: false,
                        subGrid: true,
                        subGridRowExpanded: function(subgrid_id, row_id) {
                            var subgrid_table_id, subgridpager, subgridOpts;
                            subgrid_table_id = subgrid_id + "_t";
                            subgridpager = "subgridpager_" + subgrid_id;
                            subgridOpts = pharmMthds.rxSubgridOpts(row_id, subgridpager);
                            $("#" + subgrid_id).html("<table id= '" + subgrid_table_id + "'class='scroll' ''></table><br/><div id=" + subgridpager + "/>");
                            return $("#" + subgrid_table_id).jqGrid(subgridOpts).jqGrid('gridResize');
                        }
                    };
                },
                allDrugsGridOpts: function(options) {
                    var alldrugsColModel = [{ name: 'SiteCode', index: 'SiteCode'}].concat(getColModels().siteDrugsColModel());
                    return {
                        //url: 'PharmService.asmx/SiteDrugs',
                        colNames: ['SiteCode', 'SiteDrugId', 'InsertedLDT', 'MappedLDT', 'SiteDrugCode', 'SiteDrugName', 'MappedPharmacyDrug', 'Strength', 'Units', 'MappedPharmacyUnit', 'isReleased', 'isReviewed'],
                        colModel: alldrugsColModel,
                        sortorder: 'ASC',
                        sortname: 'Id',
                        caption: 'AllSiteDrugs',
                        pager: options.pager,
                        scroll: false
                    };
                },
                pharmDrugsGridOpts: function(options) {
                    var pharmDrugsColModel = getColModels().pharmDrugsColModel();
                    return {
                        url: 'PharmService.asmx/PharmacyDrugs',
                        colNames: ['PharmacyDrugId', 'MappedPharmacyDrug', 'TreatmentProfileName', 'MappedPharmacyUnit', 'MappedPharmacyRoute', 'TreatmentProfileId', 'PharmacyDrugProperties'],
                        colModel: pharmDrugsColModel,
                        sortorder: 'ASC',
                        sortname: 'Id',
                        caption: 'PharmacyDrugs',
                        pager: options.pager
                    };
                },
                partialDrugsGridOpts: function(options) {
                    var partialDrugsColModel = GetColModels().partialDrugsColModel();
                    return {
                        //url: 'PharmService.asmx/SiteDrugs',
                        colNames: ['SiteCode', 'SiteDrugId', 'InsertedLDT', 'MappedLDT', 'SiteDrugCode', 'SiteDrugName', 'MappedPharmacyDrug', 'Strength', 'Units', 'MappedPharmacyUnit', 'isReleased', 'isReviewed'],
                        colModel: alldrugsColModel,
                        sortorder: 'ASC',
                        sortname: 'Id',
                        caption: 'AllSiteDrugs',
                        pager: options.pager,
                        scroll: false
                    };
                },
                profilesGridOpts: function(options) {
                    var profilesColModel = GetColModels().profilesColModel();
                    return {
                        //url: 'PharmService.asmx/SiteDrugs',
                        colNames: ['SiteCode', 'SiteDrugId', 'InsertedLDT', 'MappedLDT', 'SiteDrugCode', 'SiteDrugName', 'MappedPharmacyDrug', 'Strength', 'Units', 'MappedPharmacyUnit', 'isReleased', 'isReviewed'],
                        colModel: alldrugsColModel,
                        sortorder: 'ASC',
                        sortname: 'SiteDrugId',
                        caption: 'AllSiteDrugs',
                        pager: options.pager,
                        scroll: false
                    };
                },
                classesGridOpts: function(options) {
                    var classesColModel = GetColModels().classesColModel();
                    return {
                        //url: 'PharmService.asmx/SiteDrugs',
                        colNames: ['SiteCode', 'SiteDrugId', 'InsertedLDT', 'MappedLDT', 'SiteDrugCode', 'SiteDrugName', 'MappedPharmacyDrug', 'Strength', 'Units', 'MappedPharmacyUnit', 'isReleased', 'isReviewed'],
                        colModel: alldrugsColModel,
                        sortorder: 'DESC',
                        sortname: 'SiteDrugId',
                        caption: 'AllSiteDrugs',
                        pager: options.pager
                    };
                },
                //index for holding current site during all site drug loop/recurse
                currSiteIndex: 0,
                resetSiteIndex: function() { return pharmMthds.currSiteIndex = 0; },
                //set to large number to break loop >500
                setSiteIndex: function(n) { return pharmMthds.currSiteIndex = n; },
                incSiteIndex: function() { return pharmMthds.currSiteIndex++; },
                //ajax recursive function
                allSitesData: function(options) {
                    if (pharmMthds.currSiteIndex < $('#SiteCodes').data('siteCodes').length) {

                        setTimeout(function() {
                            $.ajax({
                                url: "PharmService.asmx/AllSiteDrugs",
                                type: 'POST',
                                data: JSON.stringify($.extend(options.postdata,
                                                    { Environment: $('#EnvSelect').val(), SiteCode: $('#SiteCodes').data('siteCodes')[pharmMthds.currSiteIndex] })),
                                contentType: "application/json;charset=utf-8", datatype: "json",
                                success: function(msg) {
                                    var data, rows = msg.d;
                                    if (rows.length > 0) {
                                        rows.map(function(row, i) { row.SiteCode = $('#SiteCodes').data('siteCodes')[pharmMthds.currSiteIndex]; });
                                        data = $('#d-OrderTable').data('AllSitesDrugs').concat(rows);
                                        $('#d-OrderTable').data('AllSitesDrugs', data);

                                        $('#d-OrderTable').jqGrid('setGridParam', {datatype:'local', data:data}).trigger('reloadGrid');
                                    }

                                    pharmMthds.incSiteIndex();
                                    pharmMthds.allSitesData(options);
                                },
                                error: function(xhr, st, err) {
                                    console.log("Error ,Type: " + st + "; Response: " + xhr.status + " " + xhr.statusText);
                                    pharmMthds.incSiteIndex();
                                    pharmMthds.allSitesData(options);
                                }
                            })
                        }
                        , 1000);
                    };
                }
            };
            return {
                setDefaultGridOptions: pharmMthds.setDefaultGridOptions,
                siteDrugsGridOpts: pharmMthds.siteDrugsGridOpts,
                archiveGridOptions: pharmMthds.archiveGridOptions,
                timesGridOpts: pharmMthds.timesGridOpts,
                archMinMaxGridOpts: pharmMthds.archMinMaxGridOpts,
                fieldsGridOpts: pharmMthds.fieldsGridOpts,
                ordersGridOpts: pharmMthds.ordersGridOpts,
                rxGridOpts: pharmMthds.rxGridOpts,
                siteListGridOpts: pharmMthds.siteListGridOpts,
                siteRoutesGridOpts: pharmMthds.siteRoutesGridOpts,
                siteDrugRoutesGridOpts: pharmMthds.siteDrugRoutesGridOpts,
                facilitySplitGridOpts: pharmMthds.facilitySplitGridOpts,
                componentsGridOpts: pharmMthds.componentsGridOpts,
                resetSiteIndex: pharmMthds.resetSiteIndex,
                setSiteIndex: pharmMthds.setSiteIndex,
                allSitesData: pharmMthds.allSitesData,
                allDrugsGridOpts: pharmMthds.allDrugsGridOpts,
                distinctRxcGridOpts: pharmMthds.distinctRxcGridOpts,
                orderControlGridOpts: pharmMthds.orderControlGridOpts,
                pharmDrugsGridOpts: pharmMthds.pharmDrugsGridOpts
            };

        };


    })(jQuery);