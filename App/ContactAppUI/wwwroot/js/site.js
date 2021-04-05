// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




//JS for edit details -> show date created and date posted

    $(document).ready(function () {
        $(".detailsBtn").click(function () {
            var $buttonClicked = $(this);
            var id = $buttonClicked.attr('data-id');
            var options = { "backdrop": "static", keyboard: true }; 
            console.log(id);
            $.ajax({
                type: "GET",
                dataType: "text",
                url: "/Contact/DetailsContact/"+ id ,
                
                success: function (data) {
                    $('#detailsModalContent').html(data);
                    $('#detailsModal').modal(options);
                    $('#detailsModal').modal('show');
    
                },
                error: function () {
                    alert("Oh snaaaap: Dynamic content load failed.");
                }  
            })
        });
    });







// JS for delete confirmation -> ask user to delete or cancel request, reload page after delete

$(document).ready(function () {
    $('.deleteBtn').click(function (e) {
        e.preventDefault();
        $('#deleteModalCenter').modal('show');
        console.log($(this).data('id'));
        var id = $(this).data('id');
        $('#itemid').val(id);
        console.log($('#itemid').val());
    });


    $('#Delete').click(function () {
        var id = $('#itemid').val();
        $.ajax({
            type: "POST",
            url: "/contact/deletecontact/" + id,
            success: function () {
                $('#deleteModalCenter').modal('hide');
                window.location.reload();
            },
            error: function () {
                alert("Oh snaaaap: Dynamic content load failed.")
            }
        })
    });
});
