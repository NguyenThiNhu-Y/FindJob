var l;
var service;
var dataTable;
$(function () {

    l = abp.localization.getResource('FindJob');

    service = findJob.cVs.cV;

    getFilter = function () {
        return {
            filter: $("input[name='Search']").val(),
        };
    };
    dataTable = $('#ManageCandidateTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        //order: [[0, "asc"]],
        order: false,
        ajax: abp.libs.datatables.createAjax(service.getListCV, getFilter),
        columnDefs: [
            {
                title: l('Index'),
                orderable: false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                title: l('FullNameCandidate'),
                data: "fullName"
            },
            {
                title: l('FieldName'),
                data: "fieldName"
            },
            
            {
                title: l('CVFileName'),
                data: "fileName"
            },
            
           
        ]
    }));

    

    $("input[name='Search'").keyup(function () {
        dataTable.ajax.reload();
        console.log(getFilter);
    });
});
