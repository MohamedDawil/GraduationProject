$(document).on('pageshow', '#index', function (e, data) {
    $('#content').height(getRealContentHeight());
});

function getRealContentHeight() {
    var header = $.mobile.activePage.find("div[data-role='header']:visible");
    var footer = $.mobile.activePage.find("div[data-role='footer']:visible");
    var content = $.mobile.activePage.find("div[data-role='content']:visible:visible");
    var viewport_height = $(window).height();

    var content_height = viewport_height - header.outerHeight() - footer.outerHeight();
    if ((content.outerHeight() - header.outerHeight() - footer.outerHeight()) <= viewport_height) {
        content_height -= (content.outerHeight() - content.height());
    }
    return content_height;
}

var loadFile = function (event) {
    var output = document.getElementById('output');
    output.src = URL.createObjectURL(event.target.files[0]);
};

$(document).ready(function () {
    $("#back-button").hide();
});

$("button").click(function () {
    $("#back-button").toggle();
});

function mapsSelector(lat, lng) {
    if /* if we're on iOS, open in Apple Maps */
    ((navigator.platform.indexOf("iPhone") !== -1) ||
    (navigator.platform.indexOf("iPad") !== -1) ||
        (navigator.platform.indexOf("iPod") !== -1))
        window.open("maps://maps.google.com/maps?daddr=" + lat + "," + lng + "&amp;ll=");
    else /* else use Google */
        window.open("https://maps.google.com/maps?daddr=" + lat + "," + lng + "&amp;ll=");
}

function showInfo(id) {
    var x = document.getElementById("seInfoDiv_" + id);
    if (x.style.display === "none") {
        x.style.display = "block";
        document.getElementById("info_" + id).innerHTML = "Dölj info";
    }
    else {
        x.style.display = "none";
        document.getElementById("info_" + id).innerHTML = "Se info";
    }
}

function claimProduct(id) {
    $.ajax({
        url: "/Receivers/ClaimProduct",
        data: {
            id: id
        },
        type: "POST",
        success: function (response) {
            console.log("_ProductBox.claimProduct (success): " + response);
            document.getElementById("product_" + id).innerHTML = "Avboka vara";
            document.getElementById("product_" + id).onclick = function () { unClaimProduct(id); }
        },
        error: function (response) {
            console.log("_ProductBox.claimProduct (error): " + response);
            //document.getElementById("product_" + id).innerHTML = "Boka vara";
        }
    });
}

function unClaimProduct(id) {
    $.ajax({
        url: "/Receivers/UnclaimProduct",
        data: {
            id: id
        },
        type: "POST",
        success: function (response) {
            console.log("_ProductBox.unClaimProduct (success)" + response);
            document.getElementById("product_" + id).innerHTML = "Boka vara";
            document.getElementById("product_" + id).onclick = function () { claimProduct(id); }
        },
        error: function (response) {
            console.log("_ProductBox.unClaimProduct (error)" + response);
        }
    });
}