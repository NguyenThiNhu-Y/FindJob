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
        //order: [[0, "asc"]],
        order: false,
        ajax: abp.libs.datatables.createAjax(service.getListEmployer),
        columnDefs: [
            {
                title: l('Index'),
                orderable: false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                orderable: false,
                title: l('UserName'),
                data: "username"
            },
            {
                orderable: false,
                title: l('EmployerCompanyName'),
                data: "companyName"
            },
            {
                orderable: false,
                title: l('EmployerAddress'),
                data: "address"
            },
            {
                orderable: false,
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                icon: 'fas fa-edit',
                                visible: abp.auth.isGranted('FindJob.Employer.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                icon: 'fas fa-trash-alt',
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
