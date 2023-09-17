"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


connection.on("ReceiveMessage", function (user, content) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user}: `;
    li.textContent += `${content}`;

    var li2 = document.createElement("li");
    document.getElementById("timeMessagesList").appendChild(li2);
    var date = new Date();
    var customized_date = date.getFullYear() + '-'
        + date.getMonth() + '-'
        + date.getDate() + '      '
        + date.getHours() + ":"
        + date.getMinutes() + ":"
        + date.getSeconds(); 
    li2.textContent = `${customized_date} `;
});


connection.on("userconnect", (count) => {
    var element = document.getElementById("users_num");
    element.innerHTML = count;

});
connection.on("userdisconnect", (count) => {
    var element = document.getElementById("users_num");
    element.innerHTML = count;
});



connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("title-account").value;
    var content = document.getElementById("contentInput").value;

    connection.invoke("SendMessage", user, content).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
