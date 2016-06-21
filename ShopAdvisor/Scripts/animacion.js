$(document).ready(function () {
    console.log("ready!");
    
    $("a").hover(function () {
        $("a").fadeIn(500)
    });

    $.ajax({
        method:'get',
        url: '/places',
        async: true,
    })
    .done(function (place) {
        console.log(place);
    });

   
});