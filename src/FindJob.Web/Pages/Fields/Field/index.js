$(function () {

    var l = abp.localization.getResource('FindJob');

    var service = findJob.fields.field;
    var createModal = new abp.ModalManager(abp.appPath + 'Fields/Field/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Fields/Field/EditModal');
    getFilter = function () {
        return {
            filter: $("input[name='Search']").val(),
        };
    };
    var dataTable = $('#FieldTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getListField, getFilter),
        columnDefs: [
            {
                title: l('Index'),
                orderable: false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            //{
            //    title: l('FieldContent'),
            //    data: "content"
            //},

            {
                title: l('Name'),
                data: "name"
            },
            {
                title: l('ParentField'),
                data: "parentField"
            },
            //{
            //    title: l('IdParentField'),
            //    data: "idParentField"
            //},
            {
                title: l('Actions'),
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                icon: 'fas fa-edit',
                                visible: abp.auth.isGranted('FindJob.Field.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                icon:'fas fa-trash-alt',
                                visible: abp.auth.isGranted('FindJob.Field.Delete'),
                                confirmMessage: function (data) {
                                    return l('FieldDeletionConfirmationMessage', data.record.id);
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

    $('#NewFieldButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    $("input[name='Search'").keyup(function () {
        dataTable.ajax.reload();
        console.log(getFilter);
    });
});
