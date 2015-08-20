jQuery(document).ready
(
	function () {
	    jQuery('#grdContactTypeDetail').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdContactTypeDetail&SessionVarName=ContactInfo_ContactTypeChildList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdContactTypeDetail&editMode=1&SessionVarName=ContactInfo_ContactTypeChildList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', '...', 'Type  Detail']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                        { 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 20 },
                        { 'name': 'ContactTypeChildName', 'index': 'ContactTypeChildName', editable: true, 'width': 200 }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
                , shrinkToFit: false
				, pager: jQuery('#grdContactTypeDetail_pager')
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
				, caption: 'Type Details'
				, autowidth: true
				, height: '240'
			    , gridComplete: addCheckBox_grdContactTypeDetail
				, viewsortcols: [false, 'vertical', true]
                , addDialogOptions:
				                {
				                    modal: true,
				                    closeAfterAdd: true,
				                    closeOnEscape: false,
				                    viewPagerButtons: false,
				                    errorTextFormat: function (data) { return 'Error: ' + data.responseText },
				                    bottominfo: "Fields marked with (*) are required"
				                }
                , editDialogOptions:
				        {
				            modal: true,
				            closeAfterEdit: true,
				            closeOnEscape: false,
				            viewPagerButtons: false,
				            bottominfo: "Fields marked with (*) are required"
				        }

			}
		)
		.navGrid
		(
			'#grdContactTypeDetail_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdContactTypeDetail').getGridParam('editDialogOptions')
   			, jQuery('#grdContactTypeDetail').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);

function addCheckBox_grdContactTypeDetail() {

    var SessionVarName = 'ContactInfo_ContactTypeChildList';
    var ColumnName = 'IsChecked';
    var isSelectAll = 1;

    var ids = jQuery("#grdContactTypeDetail").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdContactTypeDetail").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
            isSelectAll = 0;
        }
        jQuery("#grdContactTypeDetail").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};

