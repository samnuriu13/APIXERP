﻿namespace API.GridHelperClasses
{
    public enum CallBackMode
    {
        None,
        RequestData,
        EditRow,
        AddRow,
        DeleteRow,
        Search,
        AddDummyRecord,
        EditByForce
    }

    public enum DataCallBackMode
    {
        None,
        DuplicateBankNameCheck,
        getRowCount,
        AllSelectOrUnselect,
        AllCheckOrAllUncheckEmployeeList,
        ShowAllCheckOrUncheck,
        SetSelectedParameterValueInParameterGrid,
        CheckBlankReportParameter,
        InitParameterTableValue,
        PopulateGrideWithMenu,
        AllSelectCheckedOrUnchecked,
        AllInsertCheckedOrUnchecked,
        AllUpdateCheckedOrUnchecked,
        AllDeleteCheckedOrUnchecked,
        MenuAllCheckOrUncheck,
        DateDifference,
        FilterByEntityType,
        DuplicateEntityNameCheck,
        SearchOption,
        SetSelectedParameterValueInParameterGridForSearch,
        AllSelectOrAllClear,
        AllSelectOrAllClearEmp,
        SetActualValue,
        LatestNews,
        ChangePassword,
        GetFromDateAndToDate,
        CheckAllIndividual,
        _SearchByEmpCodeToSetEmail,
        CheckAllSupervisor,
        DuplicateFiscalYearCheck,
        ItemSegment,
        ItemStructure,
        ItemGroupWiseDeptMaping,
        deptWiseGroup,
        GetRequisitionDetail,
        GetRefTransDetail,
        GetRefDetail,
        ParentList,
        CheckTransaction,
        FilterByReportType,
        AddNewVoucherRow,
        GridComplete,
        AddNewRequisitionRow
    }
}

