"use strict";

var apiurl = "/api/";

$(document).ready(function () {
    getItems();

    $("#btnBuy").click(onBuyClick);
});

function getItems() {
    ajax("Items", onSuccessGetItems);
}

function onSuccessGetItems(data) {
    if (data) {
        const itemsAsHtml = data.map(x => 
            `<tr>
            <td>${x.Name}</td>
            <td>${x.Description}</td>
            <td>${x.Price}</td>
            <td><button onClick='return onSelect("${x.Name}")' class='btn btn-sm btn-success'>Select</button></td> 
            </tr>`);
        $("div#items").html(
            "<table class='table table-striped'><tr><th>Name</th><th>Description</th><th>Price</th><th></th>" +
            itemsAsHtml.join('') +
            "</table>");
    }
    else {
        $("div#items").html("Nothing in stock, sorry!");
    }    
}

function onSelect(name) {
    $("#txtProductName").val(name);
    return false;   // prevent postback
}

function onBuyClick() {
    const itemName = $("#txtProductName").val();
    const apiKey = $("#txtAPIkey").val();
    if (itemName.length === 0) {
        showStatus("Please select an item to buy");
    } else {
        ajax("Purchase/" + itemName, onBuySuccess, "POST", {}, apiKey);
    }
}

function onBuySuccess(data) {
    // update the items
    getItems();

    // and show the purchase result
    showStatus("Successful purchase of " + data.Name);
    $("#txtProductName").val('');
}

function showStatus(msg) {
    $("#result").html(msg);
}

//---------------------------------------------------
// AJAX Helper 
//---------------------------------------------------
function ajax(servicename, success, method, data, apiKey) {

    // optional parameters handled in the old school way, so it works on old browsers
    if (typeof method === 'undefined') {
        method = 'GET';
    }
    if (typeof data === 'undefined') {
        data = {};
    }

    // get our token.  If not available, then return
    var extraheader = {};
    if (apiKey) {
        extraheader = { 'Authorization': 'Bearer ' + apiKey };
    }
    var returnDataFormat = 'json';

    $.ajax(
        {
            url: apiurl + servicename,
            cache: false,
            dataType: returnDataFormat,
            data: data,
            processData: true,
            headers: extraheader,
            method: method,
            success: success,
            error: function (xhr, err) {
                const errInfo = JSON.parse(xhr.responseText);
                showStatus("Error: " + errInfo.Message);
            }
        }
    );
}
