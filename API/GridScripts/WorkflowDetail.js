
jQuery(document).ready
		(
			function () {
			    try {
			        jQuery('#grdWorkFlowDetail').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdWorkFlowDetail&SessionVarName=WorkFlow_CmnWorkFlowDetailList'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdWorkFlowDetail&editMode=1&SessionVarName=WorkFlow_CmnWorkFlowDetailList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID','User', 'Status', 'Sequence']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'UserID', 'index': 'UserID', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=WorkFlow_UserList&DataTextField=Name&NeedBlank=Empty&DataValueField=ContactID') } },
                                { 'name': 'StatusID', 'index': 'StatusID', 'width': 100, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=WorkFlow_lstCmnStatusList&DataTextField=StatusName&NeedBlank=Empty&DataValueField=StatusID') } },
                                { 'name': 'Sequence', 'index': 'Sequence', "width": 50, editable: true },
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdWorkFlowDetail_pager')
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
						, caption: "Work Flow Detail"
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
				                        bottominfo: "Fields marked with (*) are required"
				                    }
					}
				)
				.navGrid
				(
					'#grdWorkFlowDetail_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                     , jQuery('#grdWorkFlowDetail').getGridParam('editDialogOptions')
   			         , jQuery('#grdWorkFlowDetail').getGridParam('addDialogOptions')
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