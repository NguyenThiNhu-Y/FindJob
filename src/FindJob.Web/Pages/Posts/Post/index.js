$(function () {

    var l = abp.localization.getResource('FindJob');

    var service = findJob.posts.post;
    var createModal = new abp.ModalManager(abp.appPath + 'Posts/Post/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Posts/Post/EditModal');

    var dataTable = $('#PostTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('FindJob.Post.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('FindJob.Post.Delete'),
                                confirmMessage: function (data) {
                                    return l('PostDeletionConfirmationMessage', data.record.id);
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
                title: l('PostContent'),
                data: "content"
            },
            {
                title: l('PostStatus'),
                data: "status"
            },
            {
                title: l('PostIdUser'),
                data: "idUser"
            },
            {
                title: l('PostIdField'),
                data: "idField"
            },
            {
                title: l('PostFileName'),
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

    $('#NewPostButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
