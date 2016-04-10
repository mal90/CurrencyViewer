var currencyModule = (function () {
    var getURI = function ()
    {
        return 'api/rates';
    }

    return {
        find: function () {
            var uri = getURI();
            var id = $('#prodId').val();
            $('#product').text("Generating rates , please wait ..");
            $.getJSON(uri)
                .done(function (data) {
                    $('#product').text(data);
                })
                .fail(function (jqXHR, textStatus, err) {
                    $('#product').text('Error: ' + err);
                });
        }

    };

})();