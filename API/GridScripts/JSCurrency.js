jQuery(document).ready
(
	function () {
	    jQuery('#grdCurrency').jqGrid
		(
			{
			    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdCurrency&SessionVarName=Currency_CurrencyList'
				, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdCurrency&editMode=1&SessionVarName=Currency_CurrencyList'
				, datatype: 'json'
				, page: 1
				, colNames: ['VID', 'Currency', 'Description','Is Local','Rate']
				, colModel:
					[
						{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 20, 'index': 'VID' },
				        { 'name': 'CurrencyName', 'index': 'CurrencyName', 'align': 'center', 'width': 20, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { maxlength: "20"} },
				        { 'name': 'Description', 'index': 'Description', 'width': 30, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { maxlength: "30"} },
                        { 'name': 'IsLocalCurrency', 'index': 'IsLocalCurrency', 'align': 'center', width: 20, editable: true, edittype: "checkbox", formatter: 'checkbox' },
                        { 'name': 'ConversionFactor', 'index': 'ConversionFactor', 'align': 'center', 'width': 20, editable: true, formatter: 'currency', editrules: { required: true, number: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, editoptions: { maxlength: "10"} }
					]
				, viewrecords: true
				, rownumbers: true
				, scrollrows: true
				, pager: jQuery('#grdCurrency_pager')
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
				, caption: 'Currency Info'
				, autowidth: true
				, height: '100%'
				, viewsortcols: [false, 'vertical', true]
                , ondblClickRow: function (rowid) {
                    $('.ui-icon-pencil', '#edit_' + this.id).click();
                }
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
			'#grdCurrency_pager',
			{
			    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
			}
            , jQuery('#grdCurrency').getGridParam('editDialogOptions')
   			, jQuery('#grdCurrency').getGridParam('addDialogOptions')
		);
	    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
	        jQuery(document.body).css('font-size', '100%');
	        jQuery(document.body).html(xht.responseText);
	    }
	}
);