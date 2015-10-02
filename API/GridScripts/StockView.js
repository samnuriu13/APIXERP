
jQuery(document).ready
		(
			function () {
			    try {
			        jQuery('#grdStockView').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdStockView&SessionVarName=StockView_StockViewList'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdStockView&editMode=1&SessionVarName=StockView_StockViewList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'Branch', 'Cost Center', 'Location', 'Item Code', 'Item Description', 'Item Received', 'Item Issued', 'Item Returned','Current Stock']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'BranchName', 'index': 'BranchName', "width": 100 },
							    { 'name': 'CostCenterName', 'index': 'CostCenterName', "width": 100 },
                                { 'name': 'LocationName', 'index': 'LocationName', "width": 100},
                                { 'name': 'ItemCode', 'index': 'ItemCode', "width": 70 },
                                { 'name': 'ItemDescription', 'index': 'ItemDescription', "width": 300},
                                { 'name': 'TotalReceived', 'index': 'TotalReceived', "width": 70, align: 'right' },
                                { 'name': 'TotalIssued', 'index': 'TotalIssued', "width": 70, align: 'right' },
                                { 'name': 'TotalReturn', 'index': 'TotalReturn', 'width': 70, align: 'right' },
                                { 'name': 'CurrentStock', 'index': 'CurrentStock', 'width': 70, align:'right' },
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdStockView_pager')
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
						, caption: "Stock View"
						, autowidth: true
						, height: '250'
						, viewsortcols: [false, 'vertical', true]
                        , shrinkToFit: false
                        , restoreAfterError: false
					}
				)
				.navGrid
				(
					'#grdStockView_pager',
					{
					    'edit': false, 'add': false, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
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