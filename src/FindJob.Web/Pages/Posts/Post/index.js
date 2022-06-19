var dataTable;
var l;
var service
$(function () {

    l = abp.localization.getResource('FindJob');

    service = findJob.posts.post;
    var createModal = new abp.ModalManager(abp.appPath + 'Posts/Post/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Posts/Post/EditModal');

    dataTable = $('#PostTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getListPost),
        columnDefs: [
            {
                title: l('Index'),
                orderable: false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            //{
            //    title: l('PostContent'),
            //    data: "content"
            //},
            
            //{
            //    title: l('PostIdUser'),
            //    data: "idUser"
            //},
            {
                title: l('FullName'),
                data: "fullName"
            },
            //{
            //    title: l('PostIdField'),
            //    data: "idField"
            //},
            {
                title: l('FieldName'),
                data: "fieldName"
            },
            {
                title: l('PostFileName'),
                data: "fileName"
            },
            {
                title: l('PostStatus'),
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
                                visible: abp.auth.isGranted('FindJob.Post.Update'),
                                action: function (data) {
                                    //editModal.open({ id: data.record.id });
                                    location.href = '/Posts/Post/EditModal?Id=' + data.record.id
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
            }
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