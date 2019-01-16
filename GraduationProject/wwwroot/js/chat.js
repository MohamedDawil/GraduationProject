"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (memberImage, memberName, publishDate, sendMessage) {
    var msg = sendMessage.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = memberImage + " " + memberName + " " + sendMessage + " " + publishDate;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
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
    connection.invoke("SendMessage", productId, giverId, receiverId, sentById, sendMessage).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

$(function () {

    connection.invoke("ReadMessage", ).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});