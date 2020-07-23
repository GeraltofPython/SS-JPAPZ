$(document).ready(function () {
    $("#but").click(function () {
        //console.log("Your but was touched.");
        let x = $("#city-list").val();
        console.log(x);

        $.ajax({
            type: "GET",
            datatype: "json",
            url: "/Home/GetWeather",
            data: { wid: x },
            success: ViewData,
            error: ErrorAJAX
        });
    });
});

function ViewData(data) {
    // console.log(data);
    $("#weathers").empty();

    let name = document.createElement("h1");
    name.append(data.cityName)
    name.className = "text-center";

    $("#weathers").append(name);

    for (var i = 0; i < data.list.length; i++) {
        
        let date = document.createElement("h3");
        date.append(data["list"][i]["date"]);
        date.className = "text-center";

        let weather = document.createElement("p");
        weather.append(data["list"][i]["weatherStateName"]);
        weather.className = "text-center";

        let min = document.createElement("p");
        min.append(data["list"][i]["minTemp"]);
        min.className = "text-center";

        let max = document.createElement("p");
        max.append(data["list"][i]["maxTemp"]);
        max.className = "text-center";

        let brick = document.createElement("br");

        $("#weathers").append(date);
        $("#weathers").append(weather);
        $("#weathers").append(min);
        $("#weathers").append(max);
        $("#weathers").append(brick);
        $("#weathers").append(brick);
    }
}

function ErrorAJAX() {

}