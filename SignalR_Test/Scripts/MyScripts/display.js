$(function () {

    var connection = $.hubConnection(FRConfiguration.CrossDomainAPI + '/signalr');
    connection.logging = true;
    connection.qs = { 'createdBy': 'Linoy' };


    connection.stateChanged(function () {
        console.log('connection lifetime events: state changed');
    });

    var proxy = connection.createHubProxy("MessageHub");
    connection.start().done(function () {
        console.log('Connected !!');

        $.get(FRConfiguration.CrossDomainAPI + '/api/message/publish/123', function (data) {
            console.log('endpoint invoked and return' + data);
        });

    }).fail(function (error) {
        console.log('Connection failed!!');
        console.log(error);
    });



    proxy.on('pushMessage', function (result) {
        console.log('Message from client : ' + result);
    });

    proxy.on('invokeClientMethod', function (result) {
        console.log(result);
    });

    proxy.on('typedMessages', function (result) {
        console.log(result);
    });

    proxy.on('sendPrivateGroup', function (result) {
        console.log(result);
    });





    $('.btnSend').on('click', function () {

        var message = $('.txtMessage').val();  
        proxy.invoke('invokeServerMethod', message).done(function (result) {
            console.log('invokeServerMethod callback!!');
        });
    });

    $('.btnJoinGroup').on('click', function () {

        var message = $('.txtGroup').val();
        proxy.invoke('addToGroup', message).done(function (result) {
            console.log('Add to group invoked');
        });
    });

    $('.btnSendPrivateMsg').on('click', function () {

        var message = $('.txtMessage').val();
        proxy.invoke('sendMessageToGroup', message, $('.txtGroup').val()).done(function (result) {
            console.log('message send to group members');
        });
    });

});