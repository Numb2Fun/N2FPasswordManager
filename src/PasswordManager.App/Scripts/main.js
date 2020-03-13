// Profile List Tab Control //

let lastButtonClicked; // Profile title button used to uncollapse details
let lastProfileOpened; // Profile parent of button clicked
let isEditing = false;
let isDeleting = false;
let editForm; // Profile details for value reversion in case of edit cancel

collapseAll();
linkCategoriesToProfiles();
linkProfileTitlesToSubmitBtns();

// When input for title textbox changes, the submit button is toggled 'disabled' depending on whether input exists
function linkProfileTitlesToSubmitBtns() {
    const groups = Array.from(document.querySelectorAll('.profile-edit-group'));

    groups.forEach(group => {
        const titleBox = group.querySelector('.profile-titlebox');
        const submitBtn = group.querySelector('.profile-submit');
        
        titleBox.addEventListener('input', e => {
            checkTextboxForValue(titleBox, submitBtn);
        });

        checkTextboxForValue(titleBox, submitBtn)
    });
}

// Disables input if textbox is empty
function checkTextboxForValue(textbox, inputBtn) {
    if (textbox.value === "" || textbox.value.trim() === "") {
        inputBtn.disabled = true;
    }
    else {
        inputBtn.disabled = false;
    }
}

// Resizes category max-height when child profile tabs are opened/closed
function linkCategoriesToProfiles() {
    const groups = document.querySelectorAll('.category-group');
    groups.forEach(group => {
        const profiles = group.querySelectorAll('.profile-title');
        profiles.forEach(profile => {
            profile.addEventListener('click', e => {
                const profLi = getParent(profile, 2).querySelector('.profile-edit-group');
                const newHeight = group.scrollHeight + profLi.scrollHeight;
                group.style.maxHeight = newHeight + 'px';
            });
        });
    });
}

// Toggles visibility of profiles under specific category
// param: liParentOffset => Indicates steps from button to reach parent li element
function onCategoryClick(button, liParentOffset = 2) {
    const listParent = getParent(button, liParentOffset);
    const group = listParent.querySelector('.category-group');
    toggleView(group);
};

// Toggles visibility of clicked profile and previouse profile
// param: liParentOffset => Indicates steps from button to reach parent li element
function onProfileClick(button, liParentOffset = 2) {
    // Cancel any in progress editing or deleting
    if (isEditing) {
        onCancelEditClick();
    }
    if (isDeleting) {
        onCancelDeleteClick();
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
        lastProfileOpened = getParent(button, liParentOffset);

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
        Category: editView.querySelector("#Category").value,
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
    editView.querySelector("#Category").value = editForm.Category;
    editView.querySelector("#Website").value = editForm.Website;
    editView.querySelector("#LoginName").value = editForm.LoginName;
    editView.querySelector("#Password").value = editForm.Password;
    editView.querySelector("#SignUpEmail").value = editForm.SignUpEmail;
    // Clear validation summary -> Validation Summary Not Currently in HTML
    //const summaryList = editView.querySelector(".form-message").querySelector("ul");
    //summaryList.innerHTML = "";
}

function onDeleteClick() {
    const optionView = lastProfileOpened.querySelector('.option-group');
    const deleteView = lastProfileOpened.querySelector('.delete-group');

    optionView.style.maxWidth = '0';
    deleteView.style.maxWidth = '100%';
    isDeleting = true;
}

function onCancelDeleteClick() {
    const optionView = lastProfileOpened.querySelector('.option-group');
    const deleteView = lastProfileOpened.querySelector('.delete-group');

    optionView.style.maxWidth = '100%';
    deleteView.style.maxWidth = '0';
    isDeleting = false;
}

function getParent(item, steps) {
    let parent = item;
    for (let i = 0; i < steps; i++) {
        parent = parent.parentElement;
    }
    return parent;
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
    const deleteViews = document.querySelectorAll('.delete-group');

    detailViews.forEach(item => {
        item.style.maxHeight = null;
    });

    editViews.forEach(item => {
        item.style.maxHeight = null;
    });

    deleteViews.forEach(item => {
        item.style.maxWidth = '0px';
    });
};
