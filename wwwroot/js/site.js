// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {

    $(".copy_img").on("click", function () {
        /* Select the text field */
        var v = $(this).closest("div.promocode_container").find("input[type=text]").select();

        /* Copy the text inside the text field */
        document.execCommand("copy");

        /* display message */
        alert("Copied to clipboard successfully");
    });

    //reset filter
    $("#btnReset").on("click", function () {
        $("#txtFilter").val("");

    });



});
