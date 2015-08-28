﻿jQuery(document).ready
		(
			function () {
			    jQuery('#grdHeadCategoryCOAMap').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdHeadCategoryCOAMap&SessionVarName=HeadCategory_HeadCategoryByReportTypeList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdHeadCategoryCOAMap&editMode=1&SessionVarName=HeadCategory_HeadCategoryByReportTypeList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'COA']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
							    { 'name': 'ParentID', 'index': 'ParentID', 'width': 100, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=HeadCategory_ParentList&DataTextField=HeadCategoryName&NeedBlank=Empty&DataValueField=HeadCategoryID') } }
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdHeadCategoryCOAMap_pager')
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
						, caption: 'Head List'
						, autowidth: true
						, height: '100%'
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
					'#grdHeadCategoryCOAMap_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdHeadCategoryCOAMap').getGridParam('editDialogOptions')
   			     , jQuery('#grdHeadCategoryCOAMap').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);


