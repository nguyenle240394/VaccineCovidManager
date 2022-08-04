var datatable;
var l;
$(function () {
    l = abp.localization.getResource('VaccinecovidManager');
    /*var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'VaccineCovids/CreateModal',
    });*/

    datatable = $('#NoiSanXuatTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(vaccineCovidManager.noiSanXuats.noiSanXuat.getList),
            columnDefs: [
                {
                    title: l("Nhà sản xuất"),
                    data: "tenNhaSX"
                },
                {
                    title: l("Địa Chỉ"),
                    data: "diachi"
                },
                {
                    title: l("Email"),
                    data: "email"
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