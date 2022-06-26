$(function () {

    var l = abp.localization.getResource('FindJob');

    var service = findJob.manageCandidates.manageCandidate;
    var createModal = new abp.ModalManager(abp.appPath + 'ManageCandidates/ManageCandidate/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ManageCandidates/ManageCandidate/EditModal');

    var dataTable = $('#ManageCandidateTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('Actions'),
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('FindJob.ManageCandidate.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('FindJob.ManageCandidate.Delete'),
                                confirmMessage: function (data) {
                                    return l('ManageCandidateDeletionConfirmationMessage', data.record.id);
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
                title: l('ManageCandidateIdCV'),
                data: "idCV"
            },
            {
                title: l('ManageCandidateIdEmployer'),
                data: "idEmployer"
            },
            {
                title: l('ManageCandidateStatus'),
                data: "status"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewManageCandidateButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
