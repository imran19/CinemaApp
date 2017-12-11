/// <reference path="C:\Users\Exper\Dropbox\C# Project\MVC 5\CinemaApp\CinemaApp\Scripts/jquery-1.9.1.min.js" />

$(document).ready(function () {
    $(".addClass").click(function () {
        $("body").css("background-color", "rgba(0,0,0,0.6)");
        $("#frame").show();
        $("#add").show();
    });

    $(".select-group").append($('<option></option>').attr("value", '/Screen1/Reservation').text('Saloon 1'));
    $(".select-group").append($('<option></option>').attr("value", '/Screen12/Reservation').text('Saloon 1'));
    $(".select-group").append($('<option></option>').attr("value", '/Screen13/Reservation').text('Saloon 1'));
    $(".select-group").append($('<option></option>').attr("value", '/Screen2/Reservation').text('Saloon 2'));
    $(".select-group").append($('<option></option>').attr("value", '/Screen22/Reservation').text('Saloon 2'));
    $(".select-group").append($('<option></option>').attr("value", '/Screen23/Reservation').text('Saloon 2'));
    $(".select-group").append($('<option></option>').attr("value", '/Screen3/Reservation').text('Saloon 3'));
    $(".select-group").append($('<option></option>').attr("value", '/Screen32/Reservation').text('Saloon 3'));
    $(".select-group").append($('<option></option>').attr("value", '/Screen33/Reservation').text('Saloon 3'));

    $(".select-time").append($('<option></option>').attr("value", '9.00AM').text('9.00AM'));
    $(".select-time").append($('<option></option>').attr("value", '9.15AM').text('9.15AM'));
    $(".select-time").append($('<option></option>').attr("value", '9.30AM').text('9.30AM'));
    $(".select-time").append($('<option></option>').attr("value", '9.45AM').text('9.45AM'));

    $(".select-time").append($('<option></option>').attr("value", '10.00AM').text('10.00AM'));
    $(".select-time").append($('<option></option>').attr("value", '10.15AM').text('10.15AM'));
    $(".select-time").append($('<option></option>').attr("value", '10.30AM').text('10.30AM'));
    $(".select-time").append($('<option></option>').attr("value", '10.45AM').text('10.45AM'));

    $(".select-time").append($('<option></option>').attr("value", '11.00AM').text('11.00AM'));
    $(".select-time").append($('<option></option>').attr("value", '11.15AM').text('11.15AM'));
    $(".select-time").append($('<option></option>').attr("value", '11.30AM').text('11.30AM'));
    $(".select-time").append($('<option></option>').attr("value", '11.45AM').text('11.45AM'));

    $(".select-time").append($('<option></option>').attr("value", '12.00PM').text('12.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '12.15PM').text('12.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '12.30PM').text('12.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '12.45PM').text('12.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '1.00PM').text('1.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '1.15PM').text('1.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '1.30PM').text('1.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '1.45PM').text('1.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '2.00PM').text('2.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '2.15PM').text('2.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '2.30PM').text('2.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '2.45PM').text('2.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '3.00PM').text('3.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '3.15PM').text('3.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '3.30PM').text('3.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '3.45PM').text('3.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '4.00PM').text('4.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '4.15PM').text('4.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '4.30PM').text('4.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '4.45PM').text('4.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '5.00PM').text('5.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '5.15PM').text('5.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '5.30PM').text('5.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '5.45PM').text('5.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '6.00PM').text('6.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '6.15PM').text('6.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '6.30PM').text('6.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '6.45PM').text('6.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '7.00PM').text('7.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '7.15PM').text('7.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '7.30PM').text('7.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '7.45PM').text('7.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '8.00PM').text('8.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '8.15PM').text('8.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '8.30PM').text('8.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '8.45PM').text('8.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '9.00PM').text('9.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '9.15PM').text('9.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '9.30PM').text('9.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '9.45PM').text('9.45PM'));

    $(".select-time").append($('<option></option>').attr("value", '10.00PM').text('10.00PM'));
    $(".select-time").append($('<option></option>').attr("value", '10.15PM').text('10.15PM'));
    $(".select-time").append($('<option></option>').attr("value", '10.30PM').text('10.30PM'));
    $(".select-time").append($('<option></option>').attr("value", '10.45PM').text('10.45PM'));



    $(".close").click(function () {
        $("body").css("background-color", "");
        $("#frame").hide();
        $("#edit").hide();
    });

    $(".role").append($('<option></option>').attr("value", '255').text('Receptionist'));
    $(".role").append($('<option></option>').attr("value", '250').text('Admin'));

});