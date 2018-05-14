$(window).on('load', function () {
    $('.input-file, input[type="file"]').each(function () {
        var $input = $(this),
        $label = $input.next('label'),
        labelVal = $label.html();

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $label.find('.img-toggle').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        $input.on('change', function (e) {
            var fileName = $input.val();

            $label.find('.img-toggle').css('opacity', '.5');
            $label.find('.img-toggle').css('border', '1px solid green');
            $label.find('.upload-ok').html('<span class="glyphicon glyphicon-ok" aria-hidden="true"></span>');

            readURL(this);
        });

        // Firefox bug fix
        $input.on('focus', function () {
            $input.addClass('has-focus');
        }).on('blur', function () {
            $input.removeClass('has-focus');
        });
    });
});