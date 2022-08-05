
$(function () {
    var l = abp.localization.getResource('VaccinecovidManager');
    /*var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'VaccineCovids/CreateModal',
    });*/
    var createModal = new abp.ModalManager(abp.appPath + 'VaccineCovids/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'VaccineCovids/EditModal');

    var datatable = $('#VaccineTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(vaccineCovidManager.vaccineCovids.vaccine.getList),
            columnDefs: [
                {
                    title: l("STT"),
                    data: 'stt'
                },
                {
                    title: l("Tên Vaccine"),
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
                {
                    title: l('Tác vụ'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Sửa'),
                                    iconClass: "fa fa-pencil-square-o",
                                    visible: abp.auth.isGranted('VaccineCovidManager.VaccineCovids.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Xóa'),
                                    iconClass: "fa fa-trash-o",
                                    visible: abp.auth.isGranted('VaccineCovidManager.VaccineCovids.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'Thông báo Xác nhận xóa Vaccine Covid',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        vaccineCovidManager.vaccineCovids.vaccine
                                            .delete(data.record.id)
                                            .then(function (data) {
                                                if (data) {
                                                    abp.notify.info(l('Xóa thành công'));
                                                    datatable.ajax.reload();
                                                } else {
                                                    abp.message.error(l("Xóa thất bại"));
                                                }
                                            });
                                    }
                                }
                            ]
                    }
                }
            ]
        })
    );
    createModal.onResult(function () {
        datatable.ajax.reload();
    });

    editModal.onResult(function () {
        datatable.ajax.reload();
    });

    $('#VaccineCovidButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
})