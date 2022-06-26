var l;
var service;
var dataTable;
$(function () {

    l = abp.localization.getResource('FindJob');

    service = findJob.cVs.cV;
    
    
});
function ChangeStatus(id) {

    var mess = l('ApprovalCV');
 
    abp.message.confirm(mess, l('Notify'))
        .then(function (confirmed) {

            if (confirmed) {
                service.changeStatus(id)
                abp.message.success(l('Success'), l('Congratulations'));
                location.href = '/Notifies/Notify'
            }
        });
};