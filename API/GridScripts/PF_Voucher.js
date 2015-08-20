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
				, colNames: ['VID', 'Account Head','Party', 'Dr', 'Cr']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'COAKey', 'index': 'COAKey', 'width': 250, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=Voucher_AccCOAList&DataTextField=COAName&NeedBlank=Empty&DataValueField=COAKey') } },
                        { 'name': 'PartyKey', 'index': 'PartyKey', 'width': 250, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=Voucher_ContactInfoList&DataTextField=Name&NeedBlank=Empty&DataValueField=ContactID') } },
				        { 'name': 'Dr', 'index': 'Dr', 'width': 105, editable: true, editrules: { number: true }, 'align': 'right' },
				        { 'name': 'Cr', 'index': 'Cr', 'width': 105, editable: true, editrules: { number: true }, 'align': 'right' },
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , scroll:true
				, pager: jQuery('#grdPFVoucher_pager')
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
                , sortname: 'VID'
                , sortorder: "desc"
                , footerrow: true
	            , userDataOnFooter: true
				, postData: { FooterRowCaption: '"COAKey":"Total:"',
				    AggregateColumn: '[Dr]:Sum,[Cr]:Sum'
				}
				, rowNum: 100
				, rowList: [10, 20, 30]
				, caption: gridCaption
				, autowidth: true
				, height: '220'
				, viewsortcols: [false, 'vertical', true]
                , shrinkToFit: false
                , addDialogOptions:
				                {
				                    modal: true,
				                    width: 500,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_AccVoucher,
				                    beforeShowForm: TotalDrOrCr,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , editDialogOptions:
				                {
				                    modal: true,
				                    width: 500,
				                    closeAfterEdit: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_AccVoucher,
				                    //beforeShowForm: TotalDrOrCr,
				                    bottominfo: "Fields marked with (*) are required"
				                }
                   , ondblClickRow: function (rowid) {
                       $('.ui-icon-pencil', '#edit_' + this.id).click();
                   }
			}
		)
		.navGrid
		(
			'#grdPFVoucher_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdPFVoucher').getGridParam('editDialogOptions')
   			, jQuery('#grdPFVoucher').getGridParam('addDialogOptions')
         )
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function BeforeSubmit_AccVoucher(postdata, formid) {
    var vid;

    if (postdata.grdPFVoucher_id == '_empty')
        vid = -1;
    else
        vid = postdata.grdPFVoucher_id;
    var cOAKey = postdata.COAKey;
    var dr = postdata.Dr;
    var cr = postdata.Cr;
    var retVal = jQuery.ajax
                    (
                        {
                            url: rootPath + 'GridHelperClasses/DataHandler.ashx?CallMode=DuplicateAccHeadCheck&COAKey=' + cOAKey + '&VID=' + vid,
                            async: false
                        }
                    ).responseText;
//    if (retVal == "False") {
//        if (postdata.grdPFVoucher_id == '_empty')
//            return [false, "Add Failed! Duplicate Acc head found.", ""]
//        else
//            return [false, "UpDate Failed! Duplicate Acc head found.", ""];
//    }
    if (dr != 0 && cr != 0) {
        return [false, "Failed! Dr or Cr must be equal to zero.", ""];
    }
    else {
        return [true, "", ""];
    }
}

function TotalDrOrCr(formid) {
    var ids = jQuery("#grdPFVoucher").jqGrid('getDataIDs');
    var Dr = 0;
    var Cr = 0;
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdPFVoucher").jqGrid('getRowData', cid);
        Dr += parseFloat(data.Dr);
        Cr += parseFloat(data.Cr);
    }
    if (Dr - Cr < 0)
        $("#Dr").val(Cr - Dr);
    else
        $("#Cr").val(Dr - Cr);

};



