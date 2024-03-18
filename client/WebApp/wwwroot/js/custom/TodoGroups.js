function AddNew() {
    let newTodoGroupName = $('#inputAddNewTodoGroupName').val();

    if (newTodoGroupName !== '') {
        $.get('?handler=AddNew', { groupName: newTodoGroupName })
            .done(function (data) {
                $('#inputAddNewTodoGroupName').val('');
                window.location.reload();
            });
    };
};

function Edit(id) {
    $('#spanGroupName_' + id).removeClass('d-inline').addClass('d-none');
    $('#buttonEdit_' + id).removeClass('d-inline').addClass('d-none');
    $('#buttonDelete_' + id).removeClass('d-inline').addClass('d-none');
    $('#inputGroupName_' + id).removeClass('d-none').addClass('d-inline');
    $('#buttonSave_' + id).removeClass('d-none').addClass('d-inline');
    $('#buttonCancel_' + id).removeClass('d-none').addClass('d-inline');
};

function Cancel(id) {
    $('#spanGroupName_' + id).removeClass('d-none').addClass('d-inline');
    $('#buttonEdit_' + id).removeClass('d-none').addClass('d-inline');
    $('#buttonDelete_' + id).removeClass('d-none').addClass('d-inline');
    $('#inputGroupName_' + id).removeClass('d-inline').addClass('d-none');
    $('#buttonSave_' + id).removeClass('d-inline').addClass('d-none');
    $('#buttonCancel_' + id).removeClass('d-inline').addClass('d-none');
};

function SaveUpdate(id) {
    let newTodoGroupName = $('#inputGroupName_' + id).val();

    if (newTodoGroupName !== '') {
        $.get('?handler=AddUpdate', { id: id, groupName: newTodoGroupName })
            .done(function (data) {
                window.location.reload();
            });
    };
};

function Delete(id) {
    $.get('?handler=Delete', { id: id })
        .done(function (data) {
            window.location.reload();
        });
};
