// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function goToPageDisable(currentPage) {
    event.preventDefault();
    return false;
}

function goToPage(currentPage) {
    event.preventDefault();
    document.getElementById("currentPageId").value = currentPage;
    document.getElementById("btnSubmit").click();
    return false;
}


function gotTo(columnName, orderBy) {
    //event.stopPropagation();
   event.preventDefault();
    alert('11')
    if (orderBy == 'asc') {

        orderBy = 'desc'
    } else {
        orderBy = 'asc'
    }
    debugger;
    document.getElementById("columnNameId").value = columnName;
    document.getElementById("orderById").value = orderBy;
    document.getElementById("btnSubmit").click();
    return false;
}