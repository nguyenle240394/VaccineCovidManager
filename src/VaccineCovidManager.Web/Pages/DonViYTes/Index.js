var datatable;
var l;
$(function () {
    l = abp.localization.getResource('VaccinecovidManager');
    /*var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'VaccineCovids/CreateModal',
    });*/

    datatable = $('#DonViYTeTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(vaccineCovidManager.donViYTes.donViYTe.getList),
            columnDefs: [
                {
                    title: l("Đơn vị y tế"),
                    data: "tenDonViYTe"
                },
                {
                    title: l("Địa Chỉ"),
                    data: "diaChi"
                },
                {
                    title: l("Số điện thoại"),
                    data: "sdt"
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