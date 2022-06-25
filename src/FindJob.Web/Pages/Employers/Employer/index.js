$(function () {

    var l = abp.localization.getResource('FindJob');

    var service = findJob.employers.employer;
    var createModal = new abp.ModalManager(abp.appPath + 'Employers/Employer/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Employers/Employer/EditModal');

    var dataTable = $('#EmployerTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('FindJob.Employer.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('FindJob.Employer.Delete'),
                                confirmMessage: function (data) {
                                    return l('EmployerDeletionConfirmationMessage', data.record.id);
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
                title: l('EmployerIdUser'),
                data: "idUser"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewEmployerButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
