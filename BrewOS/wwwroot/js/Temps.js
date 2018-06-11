




const connection = new signalR.HubConnectionBuilder()
    .withUrl("/temperatureHub")
    .build();

//connection.on("UpdateSettingsTemperature", (Address, Temperature, Available) => {



//    tr = document.getElementById(Address);
//    if (tr == null) {
//        tbody = document.getElementById("TempTable");

//        var newRow = document.createElement("tr");
//        tr.id = Address;

//        var name = document.createElement("td");
//        name.className = "SensorName";
//        name.textContent = "";

//        var address_node = document.createElement("td");
//        address_node.className = "SensorAddress";
//        address_node.textContent = Address;

//        var temp = document.createElement("td");
//        temp.className = SensorTemp;
//        name.textContent = Temberature;

//        var available_node = document.createElement("td");
//        available_node.className = "SensorAvailable";
//        available_node.textContent = Available;

//        newRow.appendChild(name);
//        newRow.appendChild(address_node);
//        newRow.appendChild(temp);
//        newRow.appendChild(available_node);

//        tbody.appendChild(newRow);
//    }
//    else {
//        tr.getElementsByClassName("SensorTemp")[0].textContent = Temperature;
//        tr.getElementsByClassName("SensorAvailable")[0].textContent = Available;

//    }

//});


connection.start().catch(err => console.error(err));