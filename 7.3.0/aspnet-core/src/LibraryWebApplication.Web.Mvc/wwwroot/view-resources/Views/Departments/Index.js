(function ($) {
    debugger;
    var _departmentAppService = abp.services.app.department,
        l = abp.localization.getSource('LibraryWebApplication'),
        _$modal = $('#DepartmentCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#DepartmentsTable');

    var _$departmentsTable = _$table.DataTable({
        
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _departmentAppService.CreateFilteredQuery,
            inputFilter: function () {
                return $('#DepartmentsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$departmentsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'departmentName',
                sortable: false
            },
            {
                targets: 2,
                data: 'description',
                sortable: false
            },
            {
                targets: 3,
                data: 'remarks',
                sortable: false
            },
            {
                targets: 4,
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-department" data-department-id="${row.id}" data-toggle="modal" data-target="#DepartmentEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-department" data-department-id="${row.id}" data-department-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').click(function (e) {
        debugger;
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var department = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _departmentService
            .create(department)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$departmentsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-department', function () {
        debugger;
        var departmentId = $(this).attr('data-department-id');
        var departmentName = $(this).attr('data-department-name');

        deleteDepartment(departmentId, departmentName);
    });

    $(document).on('click', '.edit-department', function (e) {
        debugger;
        var deptId = $(this).attr('data-department-id');

        abp.ajax({
            url: abp.appPath + 'Department/EditModal?deptId=' + deptId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#DepartmentEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    abp.event.on('department.edited', (data) => {
        _$departmentsTable.ajax.reload();
    });

    function deleteDepartment(departmentId, departmentName) {
        debugger;
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                departmentName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _departmentService
                        .delete({
                            id: departmentId
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$departmentsTable.ajax.reload();
                        });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$departmentsTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
       $('input[name=IsActive][value=""]').prop('checked', true);
        _$departmentsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$departmentsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
