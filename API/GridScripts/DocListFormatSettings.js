jQuery(document).ready
		(
			function () {
			    jQuery('#grdDocListFormatSettings').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDocListFormatSettings&SessionVarName=DocListFormatSettings_CmnDocListFormatDetailList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdDocListFormatSettings&editMode=1&SessionVarName=DocListFormatSettings_CmnDocListFormatDetailList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Parameter Name', 'Length', 'Seperator', 'Sequence']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'ParameterName', 'index': 'ParameterName', 'width': 100, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=DocListFormatSettings_PopulateDropdownList&DataTextField=ValueDoc&NeedBlank=Empty&DataValueField=Text') } },
								{ 'name': 'Length', 'index': 'Length', 'editable': true, 'width': 100 },
                                { 'name': 'Seperator', 'index': 'Seperator', 'editable': true, 'width': 100 },
                                { 'name': 'Sequence', 'index': 'Sequence', 'editable': true, 'width': 100 },
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdDocListFormatSettings_pager')
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
						, caption: 'Doc List Format Settings'
						, autowidth: true
						, height: '200'
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
					'#grdDocListFormatSettings_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdDocListFormatSettings').getGridParam('editDialogOptions')
   			     , jQuery('#grdDocListFormatSettings').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);



