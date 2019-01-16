"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (memberImage, memberName, publishDate, sendMessage, isSent) {
    var msg = sendMessage.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

    var encodedMsg = "";

    if (isSent) {
        encodedMsg += "<div class='incoming_msg'>";
        encodedMsg += "<div class='incoming_msg_img'><img src='/Profiles/" + memberImage + "'></div>";
        encodedMsg += "<div class='received_msg'>";
        encodedMsg += "<div class='received_withd_msg'>";
        encodedMsg += "<p>";
        encodedMsg += memberName;
        encodedMsg += "</p>";
        encodedMsg += "<p>";
        encodedMsg += msg;
        encodedMsg += "</p>";
        encodedMsg += "<span class='time_date'>" + publishDate + "</span>";
        encodedMsg += "</div>";
        encodedMsg += "</div>";
        encodedMsg += "</div>";
    }
    else {
        encodedMsg += "<div class='outgoing_msg'>";
        encodedMsg += "<div class='sent_msg'>";
        encodedMsg += "<p>";
        encodedMsg += msg;
        encodedMsg += "</p>";
        encodedMsg += "<span class='time_date'>" + publishDate + "</span>";
        encodedMsg += "</div>";
        encodedMsg += "</div>";
    }

    $("#messagesList").append(encodedMsg);
    scrollDown();
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var sentById = document.getElementById("SentById").value;
    var productId = document.getElementById("ProductId").value;
    var giverId = document.getElementById("GiverId").value;
    var receiverId = document.getElementById("ReceiverId").value;
    var sendMessage = document.getElementById("SendMessage").value;
    console.log(sentById + ", " + productId + ", " + giverId + ", " + receiverId + ", " + sendMessage);
    connection.invoke("SendMessage", productId, giverId, receiverId, sentById, sendMessage).catch(function (err) {
        return console.error(err.toString());
    });
    $("#SendMessage").val('');
    event.preventDefault();
});

$(function () {
    scrollDown();

    $('#sendButton').attr('disabled', true);
    $('#SendMessage').keyup(function () {
        if ($(this).val().length != 0)
            $('#sendButton').attr('disabled', false);
        else
            $('#sendButton').attr('disabled', true);
    })
});

function scrollDown() {
    $('#messagesList').scrollTop($('#messagesList')[0].scrollHeight);
};