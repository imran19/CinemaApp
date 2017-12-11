/// <reference path="jquery-1.10.2.min.js" />
/// <reference path="date.js" />

var selectedSeats = [];

$(document).ready(function () {


    var tomorrow = new Date.today().addDays(1).toString("MM/dd/yyyy");
    var actualDate = new Date.today().toString("MM/dd/yyyy");

    $("#ReservedSeats").prop("readonly", true);
    $("#Time").prop("readonly", true);
    $("#Date").prop("readonly", true);
    $("#Date").val(tomorrow);
    $("input").prop("required", true);


    var varTime = $("#Time").val();
    var price = $(".hidden-price").val();

    $(".seat").click(function () {
        if (!$(this).hasClass("reserved")) {
            $(this).toggleClass("selected");

            if ($(this).hasClass("selected")) {
                var seatId = $(this).html();

                selectedSeats.push(seatId);
            } else {
                selectedSeats.pop(seatId);
            }

            $("#ReservedSeats").val(selectedSeats.join(','));
        }
        $(".price").html(selectedSeats.length * price + " KM");
        $(".labelSeatNumber").html(selectedSeats.join(','));

    });



    //By default script language does not know type as int or float. 
    //So we can fix that by multiplying 1 to the value you expect to be a number.
    //this rule is for 'var' variable.

    $(".reserved").click(function () {
        alert("Seat is occupied.");
    });

    $(".Back").click(function () {
        $("#Bill").hide();
        $("#Next").show();
        $("body").css("background-color", "");
    });

    $("#Next").click(function () {
        var check = confirm("Is customer sure about selected seats?");
        if (check == true) {
            $("body").css("background-color", "rgba(0,0,0,0.6");
            $("#Next").hide();
            $("#Bill").fadeToggle(500);
        } else
            return false;
    });

    var countReservedSeat = $("#ReservedSeats").val();

    $(".date").html(actualDate);
    $(".labelTime").html(varTime);
    $(".labelMovie").html($(".movieName").val());

    var logo = $(".logo img");
    var a = Math.floor((Math.random() * 5) + 1);
    console.log(a);
    switch (a) {
        case 3:
            logo.attr("src", "/assets/images/qrcodes/fb.me.png");
            break;
        case 2:
            logo.attr("src", "/assets/images/qrcodes/specialMessageForProfessor.png");
            break;
        case 1:
            logo.attr("src", "/assets/images/qrcodes/sarajevo.png");
            break;
        case 4:
            logo.attr("src", "/assets/images/qrcodes/turkey.png");
            break;
        default:
            logo.attr("src", "/assets/images/qrcodes/linkedin.png");
            break;
    }

});