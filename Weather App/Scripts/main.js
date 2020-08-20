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

        let windD = document.createElement("p");
        windD.append(data["list"][i]["windDirectionC"]);
        windD.className = "text-center";

        let weather = document.createElement("p");
        weather.append(data["list"][i]["weatherStateName"]);
        weather.className = "text-center";

        let min = document.createElement("p");
        min.append(data["list"][i]["minTemp"]);
        min.className = "text-center";

        let max = document.createElement("p");
        max.append(data["list"][i]["maxTemp"]);
        max.className = "text-center";

        let temperature = document.createElement("p");
        temperature.append(data["list"][i]["theTemp"]);
        temperature.className = "text-center";

        let humidity = document.createElement("p");
        humidity.append(data["list"][i]["humidity"]);
        humidity.className = "text-center";

        let visibility = document.createElement("p");
        visibility.append(data["list"][i]["visibility"]);
        visibility.className = "text-center";

        let sunRise = document.createElement("p");
        sunRise.append(data["list"][i]["sunRise"]);
        sunRise.className = "text-center";

        let sunSet = document.createElement("p");
        sunSet.append(data["list"][i]["sunSet"]);
        sunSet.className = "text-center"

        let timeZone = document.createElement("p");
        timeZone.append(data["list"][i]["timezone"]);
        timeZone.className = "text-center"

        let brick = document.createElement("br");

        $("#weathers").append(date);
        $("#weathers").append(windD);
        $("#weathers").append(weather);
        $("#weathers").append(min);
        $("#weathers").append(max);
        $("#weathers").append(temperature);
        $("#weathers").append(humidity);
        $("#weathers").append(visibility);
        $("#weathers").append(sunRise);
        $("#weathers").append(sunSet);
        $("#weathers").append(timeZone);
        $("#weathers").append(brick);
    }
}

function ErrorAJAX() {

}