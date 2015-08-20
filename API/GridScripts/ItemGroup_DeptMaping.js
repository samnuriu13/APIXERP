jQuery(document).ready
		(
			function () {
			    jQuery('#grdItemGroupDeptMaping').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdItemGroupDeptMaping&SessionVarName=ItemGroup_DetpMaping_ItemGroupDeptMapingList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdItemGroupDeptMaping&editMode=1&SessionVarName=ItemGroup_DetpMaping_ItemGroupDeptMapingList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', '...', 'Department']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                               	{ 'name': 'IsChecked', 'index': 'IsChecked', 'align': 'center', 'width': 5 },
								{ 'name': 'Department', 'index': 'Department', 'editable': false, 'width': 100 },
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
					    , gridComplete: addCheckBox_grdDept
                        //, onSelectRow: function (id) {
                        //    var ids = jQuery("#grdItemGroupDeptMaping").jqGrid('getDataIDs');

                        //    if ((ids.length == 1) || (id)) {
                        //        var grid = jQuery("#grdItemGroupDeptMaping");
                        //        grid.restoreRow(lastgrdRequistitionSelection);

                        //        grid.editRow(id, true, '', '', '', '',
                        //               function (id) {
                        //               }
                        //               );
                        //        lastgrdRequistitionSelection = id;

                        //        //to prevent auto-postback
                        //        $(':input').keydown(function (event) {
                        //            if (event.keyCode == 13 && event.which == 13) {
                        //                event.preventDefault();
                        //            }
                        //        });

                        //    }
                        //}
						, pager: jQuery('#grdItemGroupDeptMaping_pager')
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
						, rowNum: 50
						, rowList: [10, 20, 30]
						, caption: 'Item Group Dept Maping'
						, autowidth: true
						, height: '200'
						, viewsortcols: [false, 'vertical', true]
					}
				)
				.navGrid
				(
					'#grdItemGroupDeptMaping_pager',
					{
					    'edit': false, 'add': false, 'del': false, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdItemGroupDeptMaping').getGridParam('editDialogOptions')
   			     , jQuery('#grdItemGroupDeptMaping').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);
function addCheckBox_grdDept() {
    var SessionVarName = 'ItemGroup_DetpMaping_ItemGroupDeptMapingList';
    var ColumnName = 'IsChecked';

    var ids = jQuery("#grdItemGroupDeptMaping").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var cid = ids[i];
        var data = jQuery("#grdItemGroupDeptMaping").jqGrid('getRowData', cid);
        var chk;
        if (data.IsChecked == "True") {
            chk = "<input checked=\"checked\" type=\"checkbox\" onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        else {
            chk = "<input type=\"checkbox\"  onclick=\"afterCellCheckUpdate('" + data.VID + "', this,'" + SessionVarName + "','" + ColumnName + "');\"/>";
        }
        jQuery("#grdItemGroupDeptMaping").jqGrid('setRowData', ids[i], { IsChecked: chk });

    }
};

//var lastgrdRequistitionSelection;
//function editRow(id) {
//    if (id) {
//        var grid = jQuery("#grdItemGroupDeptMaping");
//        grid.restoreRow(lastgrdRequistitionSelection);
//        grid.editRow(id, true);
//        lastgrdRequistitionSelection = id;
//    }
//};



