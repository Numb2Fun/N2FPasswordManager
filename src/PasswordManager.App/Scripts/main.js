// Profile List Form Control //

let lastButtonClicked; // Profile title button used to uncollapse details
let lastProfileOpened; // Profile parent of button clicked
let isEditing = false;
let editForm; // Profile details for value reversion in case of edit cancel

collapseAll();

function onCategoryClick(button, liParentOffset = 2) {
    let listParent = button;
    for (let i = 0; i < liParentOffset; i++) {
        listParent = listParent.parentElement;
    }

    const group = listParent.querySelector('.category-group');
    toggleView(group);
}

// param: liParentOffset => Indicates steps from button to reach parent li element
function onProfileClick(button, liParentOffset = 2) {
    // Cancel any in progress editing
    if (isEditing) {
        onCancelEditClick();
    }
    // Close previous profile
    if (lastProfileOpened != null) {
        let view = lastProfileOpened.querySelector('.profile-detail-group')
        closeView(view);
    }
    // Open if is Not profile just closed
    // else clear out last opened values
    if (lastButtonClicked != button) {
        // Read event
        lastButtonClicked = button;
        lastProfileOpened = lastButtonClicked;
        // Assign proper parent element
        for (let i = 0; i < liParentOffset; i++) {
            lastProfileOpened = lastProfileOpened.parentElement;
        }

        let view = lastProfileOpened.querySelector('.profile-detail-group')
        openView(view);
    }
    else {
        lastProfileOpened = null;
        lastButtonClicked = null;
    }
};

function onEditClick() {
    const detailView = lastProfileOpened.querySelector('.profile-detail-group');
    const editView = lastProfileOpened.querySelector('.profile-edit-group');
    // Open edit view
    openView(editView);
    closeView(detailView);
    isEditing = true;
    // Save profile values for revert on cancel
    editForm = {
        Title: editView.querySelector("#Title").value,
        Website: editView.querySelector("#Website").value,
        LoginName: editView.querySelector("#LoginName").value,
        Password: editView.querySelector("#Password").value,
        SignUpEmail: editView.querySelector("#SignUpEmail").value
    };
}

function onCancelEditClick() {
    const detailView = lastProfileOpened.querySelector('.profile-detail-group');
    const editView = lastProfileOpened.querySelector('.profile-edit-group');
    // Reopen detail view
    openView(detailView);
    closeView(editView);
    isEditing = false;
    // Revert values in textboxes
    editView.querySelector("#Title").value = editForm.Title;
    editView.querySelector("#Website").value = editForm.Website;
    editView.querySelector("#LoginName").value = editForm.LoginName;
    editView.querySelector("#Password").value = editForm.Password;
    editView.querySelector("#SignUpEmail").value = editForm.SignUpEmail;
    // Clear validation summary
    const summaryList = editView.querySelector(".form-message").querySelector("ul");
    summaryList.innerHTML = "";
}

function openView(view) {
    view.style.maxHeight = view.scrollHeight + 'px';
}

function closeView(view) {
    view.style.maxHeight = 0;
}

function toggleView(view) {
    if (view.style.maxHeight == 0 || view.style.maxHeight == '0px') {
        view.style.maxHeight = view.scrollHeight + 'px';
    }
    else {
        view.style.maxHeight = 0;
    }
}

function collapseAll() {
    const detailViews = document.querySelectorAll('.profile-detail-group');
    const editViews = document.querySelectorAll('.profile-edit-group');

    detailViews.forEach((item) => {
        item.style.maxHeight = null;
    });

    editViews.forEach((item) => {
        item.style.maxHeight = null;
    });
};
