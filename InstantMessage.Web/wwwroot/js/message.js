"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/MessageHub").build();

//connection.onreconnecting(function () {
//    var user = '欢迎 XXX'
//    var message = '加入群聊';
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//});

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + "： " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});
connection.on("ReceiveAlertMessage", function (message) {
    alert(message);
});

$("#registerButton").click(function () {
    if ($("#myUserInput").val() != "") {
        connection.start().then(function () {
            document.getElementById("sendButton").disabled = false;

            connection.invoke("Register", $("#myUserInput").val()).then(function () {
                $.post("/Home/GetUserList", "", function (res) {
                    console.log(res);
                    console.log(res.length);
                    console.log(res[0].userName);
                    for (var i = 0; i < res.length; i++) {
                        $("#userList").append("<div class='row'>" + res[i].userName + "|" + res[i].connectionId + "</div>");
                    }
                });
            }).catch(function (err) {
                return console.log(err);
            });
            event.preventDefault();
            //$.post("/Home/Register", "UserName=" + $("#myUserInput").val(), function () {
            //    $.post("/Home/GetUserList", "", function (res) {
            //        console.log(res);
            //        console.log(res.length);
            //        console.log(res[0].userName);
            //        for (var i = 0; i < res.length; i++) {
            //            $("#userList").append("<div class='row'>" + res[i].userName + "</div>");
            //        }
            //    });
            //});
            //var user = '欢迎 XXX'
            //var message = '加入群聊';
            //connection.invoke("SendMessage", user, message).catch(function (err) {
            //    return console.error(err.toString());
            //});
        }).catch(function (err) {
            return console.log(err);
        });
    }
    else {
        alert("请输入用户名");
    }
});

document.getElementById("sendAllButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessageAll", message).catch(function (err) {
        return console.log(err);
    });
    event.preventDefault();
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.log(err);
    });
    event.preventDefault();
});