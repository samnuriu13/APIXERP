jQuery(document).ready
(
	function () {
	    var GridSessionVar = menuName + "_AccVoucherDetList";
	    jQuery('#grdPFVoucher').jqGrid
    (
        {
            url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdPFVoucher&SessionVarName=' + GridSessionVar
            , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdPFVoucher&editMode=1&SessionVarName=' + GridSessionVar
            , datatype: 'json'
            , page: 1
            , colNames: ['VID', 'Account Head', '', 'Party','', 'Branch/Unit', 'Cost Center', 'Dr', 'Cr']
            , colModel:
                [
                    { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                    { 'name': 'COAKey', 'index': 'COAKey', 'width': 175, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=Voucher_AccCOAList&DataTextField=COAName&NeedBlank=Empty&DataValueField=COAKey') } },
                    { 'name': 'Button', index: 'Button', width: 25, sortable: false },
                    { 'name': 'PartyKey', 'index': 'PartyKey', 'width': 175, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=Voucher_ContactInfoList&DataTextField=Name&NeedBlank=Empty&DataValueField=ContactID') } },
                    { 'name': 'PartyButton', index: 'PartyButton', width: 25, sortable: false },
                    { 'name': 'BranchID', 'index': 'BranchID', 'width': 160, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=Voucher_UnitList&DataTextField=HKName&NeedBlank=Empty&DataValueField=HKID') } },
                    { 'name': 'CostCenterID', 'index': 'CostCenterID', 'width': 160, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=Voucher_CostCenterList&DataTextField=HKName&NeedBlank=Empty&DataValueField=HKID') } },
                    { 'name': 'Dr', 'index': 'Dr', 'width': 130, editable: true, editrules: { number: true }, 'align': 'right' },
                    { 'name': 'Cr', 'index': 'Cr', 'width': 130, editable: true, editrules: { number: true }, 'align': 'right' },
                ]
            , viewrecords: true
            , rownumbers: true
            , scrollrows: true
            , scroll: true
            , pager: jQuery('#grdPFVoucher_pager')
            , loadError: jqGrid_aspnet_loadErrorHandler
            , hoverrows: true
            , gridComplete: addParamButton
            , jsonReader:
            {
                root: 'rows',
                page: 'currentpage',
                total: 'totalpages',
                records: 'pagerecords',
                repeatitems: false
            }
            , sortable: true
            , sortname: 'VID'
            , sortorder: "desc"
            , footerrow: true
            , userDataOnFooter: true
            , postData: {
                FooterRowCaption: '"COAKey":"Total:"',
                AggregateColumn: '[Dr]:Sum,[Cr]:Sum'
            }
            , rowNum: 100
            , rowList: [10, 20, 30]
            , caption: gridCaption
            , autowidth: true
            , height: '220'
            , viewsortcols: [false, 'vertical', true]
            , shrinkToFit: false
            , onSelectRow: function (id) {

                lastgrdVoucherSelection = id;
                var ids = jQuery("#grdPFVoucher").jqGrid('getDataIDs');
                if ((ids.length == 1) || (id)) {
                    var grid = jQuery("#grdPFVoucher");
                    grid.restoreRow(lastgrdVoucherSelection);
                    grid.editRow(id, true, '', '', '', '',
                    function (id) {

                        var COAKey2 = $("#cphBody_cphInfbody_ctrlVoucher_hfCOAKey").val();
                        var retVal = jQuery.ajax
	                                    (
	                                        {
	                                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=GridComplete&MenuName=' + menuName + '&COAKey=' + COAKey2,
	                                            async: false
	                                        }
                                        ).responseText;
                        $("#grdPFVoucher").trigger("reloadGrid");

                    }
                    );
                    var COAKey1 = $("#cphBody_cphInfbody_ctrlVoucher_hfCOAKey").val();
                    var gridCOAKey = $("#grdPFVoucher option:selected").val();
                    if (COAKey1 == gridCOAKey && COAKey1 != "") {

                        jQuery("#" + id + "_Dr", "#grdPFVoucher").attr("disabled", true);
                        jQuery("#" + id + "_Cr", "#grdPFVoucher").attr("disabled", true);
                        jQuery("#" + id + "_PartyKey", "#grdPFVoucher").attr("disabled", true);
                    }
                    if (menuName == "CashPaymantVoucher" || menuName == "BankPaymentVoucher") {
                        jQuery("#" + id + "_Cr", "#grdPFVoucher").attr("disabled", true);
                    }
                    if (menuName == "BankReceiveVoucher" || menuName == "CashReceiveVoucher") {
                        jQuery("#" + id + "_Dr", "#grdPFVoucher").attr("disabled", true);
                    }
                }
            }
        }
    )
    .navGrid
    (
        '#grdPFVoucher_pager',
        {
            'edit': false, 'add': false, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
        }
     )
        .navButtonAdd('#grdPFVoucher_pager',
        {
            caption: "",
            buttonicon: "ui-icon ui-icon-plus",
            onClickButton: function () {
                var COAKey = $("#cphBody_cphInfbody_ctrlVoucher_hfCOAKey").val();
                var retVal = jQuery.ajax
                (
                    {
                        url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=AddNewVoucherRow&menuName=' + menuName + '&COAKey=' + COAKey,
                        async: false
                    }
                ).responseText;

                $("#grdPFVoucher").trigger("reloadGrid");
            },
            position: "first"
        });
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);
var lastgrdVoucherSelection;
function editRow(id) {
    if (id && id !== lastgrdVoucherSelection) {
        var grid = jQuery("#grdPFVoucher");
        grid.restoreRow(lastgrdVoucherSelection);
        grid.editRow(id, true);
        lastgrdVoucherSelection = id;
    }
};

function addParamButton() {
    var grid = jQuery("#grdPFVoucher");
    var ids = grid.jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cl = ids[i];
        var data = grid.jqGrid('getRowData', cl);
        var btn = "<input style='height:22px;width:27px;', class=\"btnStyle\" id=Find_" + data.VID + " type='button' value='...' onclick=\"afterCellButtonClick(" + data.VID + ");\" />";
        grid.jqGrid('setRowData', ids[i], { Button: btn });

        btn = "<input style='height:22px;width:27px;', class=\"btnStyle\" id=Find_" + data.VID + " type='button' value='...' onclick=\"afterCellPartyButtonClick(" + data.VID + ");\" />";
        grid.jqGrid('setRowData', ids[i], { PartyButton: btn });
    }
};
function afterCellButtonClick(vid) {
    OpenDialog_COA(vid);
}
function getSelectedItem(vid) {
    var gridID = '#grdFind';
    var gridID_parent = '#grdPFVoucher';

    var rowid_popup = jQuery(gridID).jqGrid('getGridParam', 'selrow');

    var COAKey5 = jQuery(gridID).getCell(rowid_popup, 'COAKey');

    if (rowid_popup == null) return true;

    var ids = jQuery(gridID_parent).jqGrid('getDataIDs');

    jQuery("#grdPFVoucher").jqGrid('editRow', vid, true);

    $("#" + vid + "_COAKey").val(COAKey5);

    return true;
}
function afterCellPartyButtonClick(vid) {
    OpenDialog_Party(vid);
}
function getSelectedParty(vid) {
    var gridID = '#grdPartyFind';
    var gridID_parent = '#grdPFVoucher';

    var rowid_popup = jQuery(gridID).jqGrid('getGridParam', 'selrow');

    var COAKey5 = jQuery(gridID).getCell(rowid_popup, 'ContactID');

    if (rowid_popup == null) return true;

    var ids = jQuery(gridID_parent).jqGrid('getDataIDs');

    jQuery("#grdPFVoucher").jqGrid('editRow', vid, true);

    $("#" + vid + "_PartyKey").val(COAKey5);

    return true;
}
//===================================================COA Popup Grid=========================================== 

jQuery(document).ready
(
    function () {
        jQuery('#grdFind').jqGrid
        (
            {
                url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdFind&SessionVarName=Voucher_AccCOAList'
                , datatype: 'json'
                , page: 1
                , colNames: ['VID','', 'COA Code', 'COA Name']
                , colModel:
                    [
                        { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'COAKey', 'index': 'COAKey', 'hidden': true },
                        { 'name': 'COACode', 'index': 'COACode',search: true },
                        { 'name': 'COAName', 'index': 'COAName', search: true }
                    ]
                , viewrecords: true
                , rownumbers: true
                , scrollrows: true
                , pager: jQuery('#grdFind_pager')
                , loadError: jqGrid_aspnet_loadErrorHandler
                , hoverrows: true
                , jsonReader:
                {
                    root: 'rows',
                    page: 'currentpage',
                    total: 'totalpages',
                    records: 'pagerecords',
                    repeatitems: false
                }
                , sortable: true
                , rowNum: 10
                , rowList: [10, 20, 30]
                , width: '300'
                , height: '300'
                , viewsortcols: [false, 'vertical', true]
                , ondblClickRow: function (rowid) {
                    $(".ui-button-text").click();
                }
            }
        )
        .navGrid
        (
            '#grdFind_pager',
            {
                'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
            }, {}, {}, {}, { closeOnEscape: true, closeAfterSearch: true, multipleSearch: true }  
        );
        jQuery("#grdFind").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false });
        function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
            jQuery(document.body).css('font-size', '100%');
            jQuery(document.body).html(xht.responseText);
        }
    }
);


//===================================================Party Popup Grid=========================================== 

jQuery(document).ready
(
    function () {
        jQuery('#grdPartyFind').jqGrid
        (
            {
                url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdPartyFind&SessionVarName=Voucher_ContactInfoList'
                , datatype: 'json'
                , page: 1
                , colNames: ['VID', '', 'COA Code', 'COA Name']
                , colModel:
                    [
                        { 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'ContactID', 'index': 'ContactID', 'hidden': true },
                        { 'name': 'Name', 'index': 'Name', search: true },
                        { 'name': 'ShortName', 'index': 'ShortName', search: true }
                    ]
                , viewrecords: true
                , rownumbers: true
                , scrollrows: true
                , pager: jQuery('#grdPartyFind_pager')
                , loadError: jqGrid_aspnet_loadErrorHandler
                , hoverrows: true
                , jsonReader:
                {
                    root: 'rows',
                    page: 'currentpage',
                    total: 'totalpages',
                    records: 'pagerecords',
                    repeatitems: false
                }
                , sortable: true
                , rowNum: 10
                , rowList: [10, 20, 30]
                , width: '300'
                , height: '300'
                , viewsortcols: [false, 'vertical', true]
                , ondblClickRow: function (rowid) {
                    $(".ui-button-text").click();
                }
            }
        )
        .navGrid
        (
            '#grdPartyFind_pager',
            {
                'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
            }, {}, {}, {}, { closeOnEscape: true, closeAfterSearch: true, multipleSearch: true }
        );
        jQuery("#grdPartyFind").jqGrid('filterToolbar', { stringResult: true, searchOnEnter: false });
        function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
            jQuery(document.body).css('font-size', '100%');
            jQuery(document.body).html(xht.responseText);
        }
    }
);


