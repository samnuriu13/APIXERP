
jQuery(document).ready
		(
			function () {
			    var GridSessionVar = menuName + "_ItemRequisitionDetailList";
			    try {
			        jQuery('#grdItemRequisition').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdItemRequisition&SessionVarName=' + GridSessionVar
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdItemRequisition&editMode=1&SessionVarName=' + GridSessionVar
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Item Group', 'Sub-Group', 'Item', 'UOM', 'Item Qty', 'Unit Price', 'Value','Reference No','Reference','Reference Type']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'ItemGroupID', 'index': 'ItemGroupID', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=ItemRequisition_ItemGroupList&DataTextField=GroupName&NeedBlank=Empty&DataValueField=ItemGroupID'), dataEvents: [{ type: 'change', fn: AfterCellChange }] } },
                                { 'name': 'ItemSubGroupID', 'index': 'ItemSubGroupID', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=ItemRequisition_ItemSubGroupList&DataTextField=SubGroupName&NeedBlank=Empty&DataValueField=ItemSubGroupID'), dataEvents: [{ type: 'change', fn: AfterCellChangeSubGroup }] } },
                                { 'name': 'ItemCode', 'index': 'ItemCode', 'width': 250, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=ItemRequisition_ItemMasterList&DataTextField=ItemDescription&NeedBlank=Empty&DataValueField=ItemCode') } },
                                { 'name': 'UOMID', 'index': 'UOMID', 'width': 100, editable: true, "align": "center", editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=ItemRequisition_UnitSetupList&DataTextField=Name&NeedBlank=Empty&DataValueField=UnitID') } },
                                { 'name': 'ItemQty', 'index': 'ItemQty', "editable": true, "width": 100, "align": "right", formatter: 'currency', editrules: { number: true, required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' } },
                                { 'name': 'UnitPrice', 'index': 'UnitPrice', "editable": true, "width": 100, "align": "right", formatter: 'currency', editrules: { number: true, required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' } },
                                { 'name': 'Amount', 'index': 'Amount', "width": 100, "align": "right", formatter: 'currency' },
                                { 'name': 'SourceReferenceNo', 'index': 'SourceReferenceNo', "width": 100 },
                                { 'name': 'SourceReference', 'index': 'SourceReference', "width": 100 },
                                { 'name': 'SourceReferenceType', 'index': 'SourceReferenceType', "width": 100 },
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdItemRequisition_pager')
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
						, caption: gridCaption
						, autowidth: true
						, height: '250'
						, viewsortcols: [false, 'vertical', true]
                        , restoreAfterError: false
                        , addDialogOptions:
				                {
				                    modal: true,
				                    width: 500,
				                    height: '100%',
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    beforeSubmit: BeforeSubmit_Requisition,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                       , editDialogOptions:
				                    {
				                        modal: true,
				                        width: 500,
				                        height: '100%',
				                        closeAfterEdit: true,
				                        closeOnEscape: false,
				                        viewPagerButtons: false,
				                        beforeSubmit: BeforeSubmit_Requisition,
				                        bottominfo: "Fields marked with (*) are required"
				                    }
					}
				)
				.navGrid
				(
					'#grdItemRequisition_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                     , jQuery('#grdItemRequisition').getGridParam('editDialogOptions')
   			         , jQuery('#grdItemRequisition').getGridParam('addDialogOptions')
				);
			    }

			    catch (e) {

			        alert(e);

			    }
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);


function AfterCellChange(e) {
    var thisval = $(e.target).val();
    var objSubGroupDropDown = document.getElementById('ItemSubGroupID');
    GetDropDownSource_All(objSubGroupDropDown, thisval);

    var objItemDropDown = document.getElementById('ItemCode');
    GetDropDownSourceItem_All(objItemDropDown, thisval);
}
function AfterCellChangeSubGroup(e) {
    var thisval = $(e.target).val();
    var objItemDropDown = document.getElementById('ItemCode');
    GetDropDownSourceItemBySubGroup_All(objItemDropDown, thisval);
}

function GetDropDownSource_All(objSubGroupDropDown, thisval, mode) {
    var QString;

    QString = 'mode=onSelectMode_SubGroup&thisval=' + thisval;
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/MultiDropdownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;
    $(objSubGroupDropDown).empty();
    $(objSubGroupDropDown).append(retSourceString);

};
function GetDropDownSourceItem_All(objItemDropDown, thisval, mode) {
    var QString;

    QString = 'mode=onSelectMode_Item&thisval=' + thisval;
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/MultiDropdownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;
    $(objItemDropDown).empty();
    $(objItemDropDown).append(retSourceString);

};
function GetDropDownSourceItemBySubGroup_All(objItemDropDown, thisval, mode) {
    var QString;

    QString = 'mode=onSelectMode_ItemBySubGroup&thisval=' + thisval;
    var retSourceString = jQuery.ajax
    	(
    	    {
    	        url: rootPath + 'GridHelperClasses/MultiDropdownSource.ashx?' + QString,
    	        async: false
    	    }
        ).responseText;
    $(objItemDropDown).empty();
    $(objItemDropDown).append(retSourceString);

};

function BeforeSubmit_Requisition(postdata, formid) {
    postdata.Amount = postdata.ItemQty * postdata.UnitPrice;
    return [true, "", ""];
}