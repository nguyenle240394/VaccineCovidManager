var datatable;
var l;
$(function () {
    l = abp.localization.getResource('VaccinecovidManager');
    /*var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'VaccineCovids/CreateModal',
    });*/

    datatable = $('#VaccineTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(vaccineCovidManager.vaccineCovids.vaccine.getList),
            columnDefs: [
                {
                    title: l("Ten Vaccine"),
                    data: "tenVaccine"
                },
                {
                    title: l("Số lượng tồn kho"),
                    data: "soLuongTonKho"
                },
                {
                    title: l('Thời gian tạo'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                
            ]
        })
    );
})