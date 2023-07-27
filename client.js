const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7060/chathub").build();

function sendChat(){
    const username = document.getElementById('user').value;
    const message = document.getElementById('message').value;
    const color = document.getElementById('color').value;
    
    document.getElementById('message').value = "";
    document.getElementById('message').focus();
    fetch('https://localhost:7060/api/Chat',{
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({username, message, color})
    })
    .then(r => r.json())
    .then(d => {
        connection.invoke('GetChatUpdate', d);
    })
}

function setupConnection(){
    connection.on("ChatsUpdate", (update)=> {
        console.log(update)
        const chatbox = document.getElementById('chatbox');
        chatbox.innerHTML = '';

        update.forEach(element => {
            const chat = document.createElement('div');

            const user = document.createElement('h3');
            user.innerHTML = element.userName;
            user.style.color = element.color;

            const message = document.createElement('p');
            message.innerHTML = element.message;

            chat.appendChild(user);
            chat.appendChild(message);

            chatbox.appendChild(chat);
        });
        
    });

    connection.start()
    .catch( err => console.error(err.toString()));
}

setupConnection();