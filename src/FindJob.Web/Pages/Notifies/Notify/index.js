$(function () {

    var l = abp.localization.getResource('FindJob');

    var service = findJob.notifies.notify;
    var createModal = new abp.ModalManager(abp.appPath + 'Notifies/Notify/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Notifies/Notify/EditModal');
    getFilter = function () {
        return {
            filter: $("input[name='Search']").val(),
        };
    };
    var dataTable = $('#NotifyTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getListNotify, getFilter),
        columnDefs: [
            {
                title: l('Index'),
                orderable: false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            
            {
                title: l('NotifyContent'),
                data: { content: "content", fieldName: "fieldName", idCV: "idCV"},
                render: function (data) {
                    
                    return "<a href='/CVs/CV/DetailModal?Id=" + data.idCV+"'>"+ "Bạn có một CV mới về lĩnh vực " + data.fieldName+"</a>";
                }
            },
            //{
            //    title: l('NotifyIdCV'),
            //    data: "idCV"
            //},
            //{
            //    title: l('NotifyStatus'),
            //    data: "status"
            //},
            {
                title: l('Actions'),
                rowAction: {
                    items:
                        [
                            //{
                            //    text: l('Edit'),
                            //    visible: abp.auth.isGranted('FindJob.Notify.Update'),
                            //    action: function (data) {
                            //        editModal.open({ id: data.record.id });
                            //    }
                            //},
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('FindJob.Notify.Delete'),
                                confirmMessage: function (data) {
                                    return l('NotifyDeletionConfirmationMessage', data.record.id);
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

    $('#NewNotifyButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    $("input[name='Search'").keyup(function () {
        dataTable.ajax.reload();
        console.log(getFilter);
    });
});
