"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/messages").build();
connection.on("RecievedMessage", function (user,message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var div = document.createElement("div");
    div.innerHTML = user.toString()+"---"+ msg.toString() + "<hr/>";
    document.getElementById("messages").appendChild(div);
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("message").value  ;
    var user = "Ahemd";
    connection.invoke("SendMessage", user,message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
    
});