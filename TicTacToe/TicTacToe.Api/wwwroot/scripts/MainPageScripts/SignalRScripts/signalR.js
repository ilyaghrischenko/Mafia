async function initiateConnection(userLogin) {
    // Создаем соединение
    window.connection = new signalR.HubConnectionBuilder()
        .withUrl(`/gameHub?userName=${encodeURIComponent(userLogin)}`)
        .build();
    // Запускаем соединение
    await connection.start().then(() => {
        console.log('SignalR Connected');
    }).catch(err => console.error(err.toString()));
}