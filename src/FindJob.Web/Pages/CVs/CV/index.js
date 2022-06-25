var l;
var service;
var dataTable;
$(function () {

    l = abp.localization.getResource('FindJob');

    service = findJob.cVs.cV;
    var createModal = new abp.ModalManager(abp.appPath + 'CVs/CV/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'CVs/CV/EditModal');
    var detailModal = new abp.ModalManager(abp.appPath + 'CVs/CV/DetailModal');

    dataTable = $('#CVTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        //order: [[0, "asc"]],
        order: false,
        ajax: abp.libs.datatables.createAjax(service.getListCV),
        columnDefs: [
            {
                title: l('Index'),
                orderable: false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                title: l('FullName'),
                data: "fullName"
            },
            {
                title: l('FieldName'),
                data: "fieldName"
            },
            //{
            //    title: l('CVIdUser'),
            //    data: "idUser"
            //},
            //{
            //    title: l('CVIdField'),
            //    data: "idField"
            //},
            {
                title: l('CVFileName'),
                data: "fileName"
            },
            {
                title: l('CVStatus'),
                data: { status: "status", id: "id" },
                render: function (data) {

                    var check = '';
                    if (data.status == 1)
                        check = "checked";
                    var str = '<label class="switch">' +
                        `<input type = "checkbox" id="${data.id}" ${check} onclick="ChangeStatus(this.id,${data.status})">` +
                        '<span class="slider round"></span>' +
                        '</label >';
                    return str;

                }
            },
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('FindJob.CV.Update'),
                                action: function (data) {
                                    //editModal.open({ id: data.record.id });
                                    location.href = '/CVs/CV/EditModal?Id=' + data.record.id
                                }
                            },
                            //{
                            //    text: l('Detail'),
                            //    //visible: abp.auth.isGranted('FindJob.CV.Detail'),
                            //    action: function (data) {
                            //        detailModal.open({ id: data.record.id });
                            //        //location.href = '/CVs/CV/DetailModal?Id=' + data.record.id
                            //    }
                            //},
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('FindJob.CV.Delete'),
                                confirmMessage: function (data) {
                                    return l('CVDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCVButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
function ChangeStatus(id, status) {
    if ($('#' + id).is(':checked')) {
        $("#" + id).prop("checked", false);
    }
    else {
        $("#" + id).prop("checked", true);
    }
    dataTable.ajax.reload();

    var mess = l('BlockTheCategory');
    if (status == 0) {
        mess = l('UnblockTheCategory');
    }

    abp.message.confirm(mess, l('Notify'))
        .then(function (confirmed) {

            if (confirmed) {
                service.changeStatus(id)
                abp.message.success(l('YourChangesHaveBeenSuccessfullySaved'), l('Congratulations'));
                dataTable.ajax.reload();
            }
            dataTable.ajax.reload();

        });
};