(function($) {
$.fn.phmPlugin = function(method) {
                var pluginMthds= {
                    init: function() { return; },
                    cummulativeJqGrid: function(options) {
                        var opts, pdata, siteenv, theId;
                        var $this = $(this);
                        pdata = options.formData.serializeForm();
                        //hack because grid unload breaks $(this)
                        theId = $this.selector;
                        opts = options.gridOpts({ pager: options.pager });
                        //UNload what wwas there before
                        $this.jqGrid('GridUnload');
                        return $(theId).jqGrid(opts)
                                .setGridParam({ postData: pdata })
                                .jqGrid('gridResize')
                                .jqGrid('navGrid', options.pager, { add: false, edit: false, del: false }, {}, {}, {},
                                { multipleSearch: true,
                                    onSearch: function() {
                                        var pdata = options.formData.serializeForm();
                                        $(theId).setGridParam({ page: 1, postData: pdata,
                                            datatype: function(postdata) {
                                            getGridOpts().resetSiteIndex();
                                                $('#d-OrderTable').data('AllSitesDrugs', []);
                                                $('#d-OrderTable').jqGrid('clearGridData', true);
                                                getGridOpts().allSitesData({ postdata: postdata, url: options.url });
                                            }
                                        });
                                    }
                                });

                    },
                    modJqGrid: function(options) {
                        var opts, pdata, siteenv, theId;
                        var $this = $(this);
                        pdata = options.formData.serializeForm();
                        siteenv = $('#siteForm').serializeForm();
                        $.extend(pdata, siteenv);
                        //hack because grid unload breaks $(this)
                        theId = $this.selector;
                        opts = options.gridOpts({ pager: options.pager });
                        $this.jqGrid('GridUnload');
                        return $(theId).jqGrid(opts)
                            .setGridParam({ postData: pdata })
                            .jqGrid('gridResize')
                            .jqGrid('navGrid', options.pager, { add: false, edit: false, del: false, refresh: false }, {}, {}, {},
                            { multipleSearch: true,
                                onSearch: function() {
                                    var pdata = options.formData.serializeForm(), siteenv = $('#siteForm').serializeForm();
                                    $.extend(pdata, siteenv);
                                    $(theId).jqGrid('clearGridData', true).setGridParam({ page: 1, datatype: 'json', postData: pdata }).trigger('reloadGrid');
                                }
                            })
                            .jqGrid('navButtonAdd', options.pager, { caption: "Columns"
                              , title: "Select Columns",
                                onClickButton: function() {$(theId).jqGrid('columnChooser');}
                            }).jqGrid('navButtonAdd', options.pager, { caption: "ExcelExport" , title: "Export Changes (If any) to Excel",
                                onClickButton: function() {}
                            });
                    },
                    getAcData: function(options) {
                        var $this = $(this);
                        $.ajax({
                            url: options.url, contentType: "application/json;charset=utf-8",
                            success: function(msg) {
                                $this.data(options.key, msg.d);
                                if (options.complete === true) {
                                    $this.autocomplete({ source: $this.data(options.key), delay: 0, minLength: 2 });
                                }
                            },
                            error: function(xhr, st, err) {
                                alert("Error ,Type: " + st + "; Response: " + xhr.status + " " + xhr.statusText);
                            }
                        });
                        return this;
                    }
                }
    
    
        //var mthds =  getMM().pluginMthds;
        if (pluginMthds[method]) {
            return pluginMthds[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
        return pluginMthds.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.phmPlugin');
        }
    };



    $.reloadGridOnLink = function(options) {

        console.log($(this));
        $('#SiteCodes').val(options.el.text());
        var pdata = $('d-OrderForm').serializeForm();
        var siteenv = $('#siteForm').serializeForm();
        $.extend(pdata, siteenv);
        $(options.gridEl).setGridParam({ page: 1, datatype: 'json', postData: pdata }).trigger('reloadGrid');

    };

    $.calcPct = function(cellVal, options, rowObj) {
        if (cellVal) {
            return (cellVal / rowObj.Count * 100).toFixed(2);
        }
        else {
            return 0.00;
        }
    };

    $.fn.serializeForm = function() {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function() {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
    $.formatDate = function(cellval, pattern) {
        if (cellval == null) return "";
        var date = new Date(parseInt(cellval.replace(/^\/Date\((\d+)\)\/$/, ('$1'))));
        var result = [];
        while (pattern.length > 0) {
            $.formatDate.patternParts.lastIndex = 0;
            var matched = $.formatDate.patternParts.exec(pattern);
            if (matched) {
                result.push($.formatDate.patternValue[matched[0]].call(this, date));
                pattern = pattern.slice(matched[0].length);
            }
            else {
                result.push(pattern.charAt(0));
                pattern = pattern.slice(1);
            }
        }
        return result.join('');
    };

    $.formatDate.patternParts =
    /^(yy(yy)?|M(M(M(M)?)?)?|d(d)?|EEE(E)?|a|H(H)?|h(h)?|m(m)?|s(s)?|S)/;

    $.formatDate.monthNames = [
    'January', 'February', 'March', 'April', 'May', 'June', 'July',
    'August', 'September', 'October', 'November', 'December'
  ];

    $.formatDate.dayNames = [
    'Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday',
    'Saturday'
  ];

    $.formatDate.patternValue = {
        yy: function(date) {
            return $.toFixedWidth(date.getFullYear(), 2);
        },
        yyyy: function(date) {
            return date.getFullYear().toString();
        },
        MMMM: function(date) {
            return $.formatDate.monthNames[date.getMonth()];
        },
        MMM: function(date) {
            return $.formatDate.monthNames[date.getMonth()].substr(0, 3);
        },
        MM: function(date) {
            return $.toFixedWidth(date.getMonth() + 1, 2);
        },
        M: function(date) {
            return date.getMonth() + 1;
        },
        dd: function(date) {
            return $.toFixedWidth(date.getDate(), 2);
        },
        d: function(date) {
            return date.getDate();
        },
        EEEE: function(date) {
            return $.formatDate.dayNames[date.getDay()];
        },
        EEE: function(date) {
            return $.formatDate.dayNames[date.getDay()].substr(0, 3);
        },
        HH: function(date) {
            return $.toFixedWidth(date.getHours(), 2);
        },
        H: function(date) {
            return date.getHours();
        },
        hh: function(date) {
            var hours = date.getHours();
            return $.toFixedWidth(hours > 12 ? hours - 12 : hours, 2);
        },
        h: function(date) {
            return date.getHours() % 12;
        },
        mm: function(date) {
            return $.toFixedWidth(date.getMinutes(), 2);
        },
        m: function(date) {
            return date.getMinutes();
        },
        ss: function(date) {
            return $.toFixedWidth(date.getSeconds(), 2);
        },
        s: function(date) {
            return date.getSeconds();
        },
        S: function(date) {
            return $.toFixedWidth(date.getMilliseconds(), 3);
        },
        a: function(date) {
            return date.getHours() < 12 ? 'AM' : 'PM';
        }
    };

    $.toFixedWidth = function(value, length, fill) {
        var result = (value || '').toString();
        fill = fill || '0';
        var padding = length - result.length;
        if (padding < 0) {
            result = result.substr(-padding);
        }
        else {
            for (var n = 0; n < padding; n++) result = fill + result;
        }
        return result;
    };
})(jQuery);
