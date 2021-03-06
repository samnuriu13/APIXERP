﻿jQuery(document).ready
		(
			function () {
			    jQuery('#grdItemSubGroup').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdItemSubGroup&SessionVarName=SubGroupItem_ItemSubGroupList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdItemSubGroup&editMode=1&SessionVarName=SubGroupItem_ItemSubGroupList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Item Group', 'Item Sub-Group']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'ItemGroupID', 'index': 'ItemGroupID', 'width': 220, editable: true, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=ItemGroup_ItemGroupList&DataTextField=GroupName&NeedBlank=Empty&DataValueField=ItemGroupID') } },
								{ 'name': 'SubGroupName', 'index': 'SubGroupName', 'editable': true, 'width': 220 },
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdItemSubGroup_pager')
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
						, rowNum: 10
						, rowList: [10, 20, 30]
						, caption: 'Item Sub-Group'
						, autowidth: true
						, height: '200'
						, viewsortcols: [false, 'vertical', true]
                        , shrinkToFit: false
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
                        , ondblClickRow: function (rowid) {
                            $('.ui-icon-pencil', '#edit_' + this.id).click();
                        }
					}
				)
				.navGrid
				(
					'#grdItemSubGroup_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdItemSubGroup').getGridParam('editDialogOptions')
   			     , jQuery('#grdItemSubGroup').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);



