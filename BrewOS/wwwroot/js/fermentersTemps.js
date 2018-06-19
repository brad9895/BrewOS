

//var transportType = signalR.TransportType.WebSockets;

//var logger = new signalR.ConsoleLogger(signalR.LogLevel.Trace);


const connection = new signalR.HubConnectionBuilder()
    .withUrl("/temperatureHub")
    .configureLogging(signalR.LogLevel.Trace)
    .build();

//var tempHub = new signalR.HttpConnection(`http://${document.location.host}/tempHub`, { transport: transportType, logger: logger });

//var connection = new signalR.HubConnection(tempHub, logger);

console.log("Script Start");

//debugger;

connection.on("Message", (Address, Temperature, Available) => {


    console.log("Connected");

    tr = document.getElementById(Address);
    
    //debugger;
    if (tr != null) {
        tr.value = Temperature;

        if (Available)
            tr.style.color = "green";
        else
            tr.style.color = "red";
        
    }
    
});


connection.start().catch(err => console.error(err));