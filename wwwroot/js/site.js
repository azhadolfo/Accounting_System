﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('select').each(function () {
        $(this).select2({
            placeholder: "Select an option",
            allowClear: true
        });
    });
});