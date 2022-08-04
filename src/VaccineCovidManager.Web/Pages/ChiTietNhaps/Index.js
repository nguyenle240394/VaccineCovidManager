var datatable;
var l;
$(function () {
    l = abp.localization.getResource('VaccinecovidManager');
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'ChiTietNhaps/CreateModal',
    });

    datatable = $('#NhapVaccineTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(vaccineCovidManager.chiTietNhaps.chiTietNhap.getList),
            columnDefs: [
                {
                    title: l("Nhà sản xuất"),
                    data: "tenNoiSX"
                },
                {
                    title: l("Vaccine"),
                    data: "tenVaccine"
                },
                {
                    title: l("Ngày sản xuất"),
                    data: "ngaySx"
                },
                {
                    title: l("Hạn sử dụng"),
                    data: "hanSuDung"
                },
                {
                    title: l("Số lượng nhập"),
                    data: "slNhap"
                },
                {
                    title: l('Thời gian nhập'), data: "creationTime",
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
    createModal.onResult(function () {
        datatable.ajax.reload();
    });
    
    $('#NhapVaccine').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    
})