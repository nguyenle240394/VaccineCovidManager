var datatable;
var l;
$(function () {
    l = abp.localization.getResource('VaccineCovidManager');
    /*var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'ChiTietXuats/CreateModal',
    });*/
    
    datatable = $('#XuatVaccineTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(vaccineCovidManager.chiTietXuats.chiTietXuat.getList),
            columnDefs: [
                {
                    title: l("Vaccine"),
                    data: "tenVaccine"
                },
                {
                    title: l("Đơn vị y tế"),
                    data: "donViYTe"
                },
                {
                    title: l("Số lượng xuất"),
                    data: "soLuongXuat"
                },
                {
                    title: l('Thời gian xuất'), data: "creationTime",
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
    /*createModal.onResult(function () {
        datatable.ajax.reload();
    });

    $('#NhapVaccine').click(function (e) {
        e.preventDefault();
        createModal.open();
    });*/

})