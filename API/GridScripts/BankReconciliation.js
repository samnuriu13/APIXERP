
jQuery(document).ready
		(
			function () {
			    try {
			        jQuery('#grdBankReconciliation').jqGrid
				(
					{
					    url: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBankReconciliation&SessionVarName=BankReconciliation_VoucherList'
						, editurl: rootPath + 'GridHelperClasses/GridGenericHandler.ashx?jqGridID=grdBankReconciliation&editMode=1&SessionVarName=BankReconciliation_VoucherList'
						, datatype: 'json'
						, page: 1
						, colNames: ['VID','Party', 'Voucher No', 'Voucher Date', 'Voucher Desc','Cheque No','Cheque Date','Cheque Type','Cheque Status']
						, colModel:
							[
								{ 'name': 'VID', 'key': true, 'hidden': true, 'width': 50, 'index': 'VID' },
                                { 'name': 'Party', 'index': 'Party', "width": 150 },
							    { 'name': 'VoucherNo', 'index': 'VoucherNo', "width": 100, 'align': 'center' },
                                { 'name': 'VoucherDate', 'index': 'VoucherDate', "width": 100, 'align': 'center' },
                                { 'name': 'VoucherDesc', 'index': 'VoucherDesc', "width": 200 },
                                { 'name': 'CheckNo', 'index': 'CheckNo', "width": 100, 'align': 'center' },
                                { 'name': 'CheckDate', 'index': 'CheckDate', "width": 100, 'align': 'center' },
                                { 'name': 'ChequeTypeName', 'index': 'ChequeTypeName', "width": 100, 'align': 'center' },
                                { 'name': 'ChequeStatus', 'index': 'ChequeStatus', 'width': 100, 'align': 'center', editable: true, editrules: { required: true }, formoptions: { elmsuffix: '<span style="color:red;padding-left:5px;">*</span>' }, edittype: "select", formatter: 'select', editoptions: { value: GetDropDownSource('SessionVarName=BankReconciliation_ChequeStatusList&DataTextField=ChequeStatusName&NeedBlank=Empty&DataValueField=ChequeStatusID') } },
							]
						, viewrecords: true
						, rownumbers: true
						, scrollrows: true
						, pager: jQuery('#grdBankReconciliation_pager')
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
						, caption: "Bank Reconciliation"
						, autowidth: true
						, height: '250'
						, viewsortcols: [false, 'vertical', true]
                        , shrinkToFit: false
                        , restoreAfterError: false
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
                        , ondblClickRow: function (rowid) {
                            $('.ui-icon-pencil', '#edit_' + this.id).click();
                        }
					}
				)
				.navGrid
				(
					'#grdBankReconciliation_pager',
					{
					    'edit': true, 'add': false, 'del': true, 'search': true, 'refresh': true, 'view': false, 'position': 'left', 'cloneToTop': true
					}
                     , jQuery('#grdBankReconciliation').getGridParam('editDialogOptions')
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