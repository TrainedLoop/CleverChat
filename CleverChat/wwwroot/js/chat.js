const connection = new signalR.HubConnectionBuilder()
    .withUrl("/cleverHub")
    .build();

connection.on("ReceiveMessage", (user, message, cs, to) => {
    const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg;
    if (user != "CleverBot") {
        encodedMsg = user + ":" + msg;
    }
    else {
        encodedMsg = "CleverBot para " + to + ":" + msg;
    }
    const li = document.createElement("li");
    li.classList.add("list-group-item");
    li.textContent = encodedMsg;
    if (user == 'CleverBot') {
        li.classList.add("list-group-item-info");
        if (document.getElementById("userInput").value == to &&
            document.getElementById("cs").value == '') {
            document.getElementById("cs").value = cs;
        }
    }
    document.getElementById("messagesList").appendChild(li);

    $('#chat-window').scrollTop(9999);
});

connection.start().catch(err => console.error(err.toString()));

document.getElementById("sendButton").addEventListener("click", event => sendMessage());
document.getElementById("messageInput").addEventListener("keydown", (event) => {
    var key = event.which || event.keyCode;
    if (key === 13) {
        sendMessage();
    }
});


function sendMessage() {
    var user = document.getElementById("userInput").value;
    var messageInput = document.getElementById("messageInput");
    var cs = document.getElementById("cs").value;
    connection.invoke("SendMessage", user, messageInput.value, cs).catch(err => console.error(err.toString()));
    messageInput.value = "";
    event.preventDefault();
}
