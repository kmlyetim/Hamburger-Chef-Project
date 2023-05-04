// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function UserList() {
    $.ajax({
        url: "/Admin/AdminHome/GetUser",
        type: "GET",
        success: function (response) {
            $("#user-order").html(response);
        }        
    })
}

function OrderList() {
    $.ajax({
        url: "/Admin/AdminHome/GetOrder",
        type: "GET",
        success: function (response) {
            $("#user-order").html(response);
        }
    })
}

function SendMessage() {
    $.ajax({
        url: "/User/UserHome/SendMessage",
        type: "GET",
        success: function (response) {
            $("#send-id").html(response);
        }
    })
}
