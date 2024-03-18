function HandleCompleted(id, isCompleted) {
    let ischecked;

    if ($('#todoCheck' + id).prop('checked') == true) {
        ischecked = true;
    } else {
        ischecked = false;
    };

    ChangeCompletedOrNot(id, ischecked);
};

function ChangeCompletedOrNot(id, isCompleted) {
    $.get('?handler=ChangeCompletedOrNot', { id: id, isCompleted: isCompleted })
        .done(function (data) {
            window.location.reload();
        });
};
