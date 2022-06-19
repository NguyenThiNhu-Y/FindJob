$(function () {

    var l = abp.localization.getResource('FindJob');

    var service = findJob.cVs.cV;
    var createModal = new abp.ModalManager(abp.appPath + 'CVs/CV/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'CVs/CV/EditModal');

    var dataTable = $('#CVTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('FindJob.CV.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
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
            {
                title: l('CVContent'),
                data: "content"
            },
            {
                title: l('CVStatus'),
                data: "status"
            },
            {
                title: l('CVIdUser'),
                data: "idUser"
            },
            {
                title: l('CVIdField'),
                data: "idField"
            },
            {
                title: l('CVFileName'),
                data: "fileName"
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
