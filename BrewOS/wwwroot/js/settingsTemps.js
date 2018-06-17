

//var transportType = signalR.TransportType.WebSockets;

//var logger = new signalR.ConsoleLogger(signalR.LogLevel.Trace);


const connection = new signalR.HubConnectionBuilder()
    .withUrl("/temperatureHub")
    .configureLogging(signalR.LogLevel.Trace)
    .build();

//var tempHub = new signalR.HttpConnection(`http://${document.location.host}/tempHub`, { transport: transportType, logger: logger });

//var connection = new signalR.HubConnection(tempHub, logger);

console.log("Script Start");

debugger;

connection.on("Message", (Address, Temperature, Available) => {


    console.log("Connected");

    tr = document.getElementById(Address);
    
    debugger;
    if (tr == null) {
        tbody = document.getElementById("TempTable");

        var newRow = document.createElement("tr");
        tr.id = Address;
        debugger;
        var name = document.createElement("td");
        name.className = "SensorName";
        name.textContent = "";

        var address_node = document.createElement("td");
        address_node.className = "SensorAddress";
        address_node.textContent = Address;
        debugger;
        var temp = document.createElement("td");
        temp.className = SensorTemp;
        name.textContent = Temberature;

        var available_node = document.createElement("td");
        available_node.className = "SensorAvailable";
        available_node.textContent = Available;

        newRow.appendChild(name);
        newRow.appendChild(address_node);
        newRow.appendChild(temp);
        newRow.appendChild(available_node);
        debugger;
        tbody.appendChild(newRow);
    }
    else {
        tr.getElementsByClassName("SensorTemp")[0].textContent = Temperature;
        tr.getElementsByClassName("SensorAvailable")[0].value = Boolean(Available);
        debugger;
    }

});


connection.start().catch(err => console.error(err));