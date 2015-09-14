jQuery(document).ready
		(
			function () {
			    jQuery('#grdMenuList').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMenuList&SessionVarName=MenuSetup_MenuList'
					    , editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdMenuList&editMode=1&SessionVarName=MenuSetup_MenuList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID', 'MenuID', 'Display Member', 'Parent', 'Form Path', 'Type','Sequence','IsVisible']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 10, 'index': 'VID' },
                                { 'name': 'MenuID', 'index': 'MenuID', 'hidden': true, 'width': 10 },
                                { 'name': 'DisplayMember', 'index': 'DisplayMember', 'editable': true, 'width': 150, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' } },
                                { 'name': 'ParentID', 'index': 'ParentID', 'width': 150, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=MenuSetup_MenuListForDropDown&DataTextField=DisplayMember&NeedBlank=Empty&DataValueField=MenuID') } },
                                { 'name': 'FormName', 'index': 'FormName', 'editable': true, 'width': 250 },
                                { 'name': 'MenuType', 'index': 'MenuType', 'width': 150, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=MenuSetup_MenuTypeList&DataTextField=MenuType&NeedBlank=Empty&DataValueField=MenuType') } },
                                { 'name': 'MenuSequence', 'index': 'MenuSequence', 'editable': true, 'width': 80, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' } },
                                { 'name': 'IsVisible', 'index': 'IsVisible', 'align': 'center', width: 80, editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' } },
							]
						, viewrecords: true
						, rownumbers: false
						, scrollrows: true
						, pager: jQuery('#grdMenuList_pager')
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
                        , sortorder: "asc"
						, rowNum: 10
						, rowList: [10, 20, 30]
						, caption: 'Menu List'
						, autowidth: true
						, height: '230'
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
					'#grdMenuList_pager',
					{
					    'edit': true, 'add': true, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                 , jQuery('#grdMenuList').getGridParam('editDialogOptions')
   			     , jQuery('#grdMenuList').getGridParam('addDialogOptions')
			     );
			    function jqGrid_aspnet_loadErrorHandler(xht, st, handler) {
			        jQuery(document.body).css('font-size', '100%');
			        jQuery(document.body).html(xht.responseText);
			    }
			}
		);



