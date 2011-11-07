$(function () {

    $('input[name=CreatedOn],input[name=UpdatedOn],input[name=PublishedOn]').each(function () {
        $(this).datepicker({
            dateFormat: 'yy-mm-dd'
        });
    });

    $('input.datetime').each(function () {
        $(this).datetimepicker({
            dateFormat: 'yy-mm-dd'
        });
    });

    $('input[data-action=check-all]').click(function () {
        $('input#ids').each(function () {
            if ($(this).is(':checked')) {
                $(this).attr('checked', false);
            } else {
                $(this).attr('checked', true);
            }
        });
    });

    $('a[data-action=deletelist]').click(function () {
        if (confirm('Вы уверенны что хотите удалить выбранные записи?')) {
            $('form[data-form=list]').submit();
        }
        return false;
    })

    $('a[data-action=delete]').click(function () {
        return confirm('Вы уверенны что хотите удалить выбранные записи?');
    });

    $('a[data-action=copy]').click(function () {
        var form = $('form#data');
        var createAction = form.attr('action').replace('update', 'create');
        form.attr('action', createAction);
        form.submit();
        return false;
    });

    $('a[rel=popup]').each(function () {
        $(this).click(function () {
            var wh = $(this).attr('href').match(/\/\d+x\d+\//i).toString().replace('/', '').split('x');
            window.open($(this).attr('href'), $(this).attr('title'), 'width=' + wh[0] + ', height=' + wh[1]);
            return false;
        });
    });

    $('img[data-type=image-preview]').each(function () {
        $(this).click(function () {
            var w = 350;
            var h = 350;
            var src = $(this).attr('src').toString();
            var path = src.replace(src.match(/\/images\//), baseImageUrl).replace(src.match(/\/\d+x\d+\//i), '/');
            window.open(path, $(this).attr('alt'), 'width=' + w + ', height=' + h);
            return false;
        });
    });

    $('button[data-action="add-file-field"]').each(function () {
        $(this).click(function () {
            var fileFieldName = $(this).attr('data-name');
            var fileFieldId = fileFieldName.replace('[]', $(this).parents('ul').find('li').length);
            $(this).parents('ul').find('li:first-child').after('<li><label for="' + fileFieldId + '">Выберите файл</label><input type="file" value="" name="' + fileFieldName + '" id="' + fileFieldId + '" /></li>');
        });
    })


    $('input[data-value="url"]').focus(function () {
        $(this).select();
    });

    $.datepicker.regional['ru'] = {
        closeText: 'Закрыть',
        prevText: '<Пред',
        nextText: 'След>',
        currentText: 'Сегодня',
        monthNames: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
        'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
        monthNamesShort: ['Янв', 'Фев', 'Мар', 'Апр', 'Май', 'Июн',
        'Июл', 'Авг', 'Сен', 'Окт', 'Ноя', 'Дек'],
        dayNames: ['воскресенье', 'понедельник', 'вторник', 'среда', 'четверг', 'пятница', 'суббота'],
        dayNamesShort: ['вск', 'пнд', 'втр', 'срд', 'чтв', 'птн', 'сбт'],
        dayNamesMin: ['Вс', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
        weekHeader: 'Не',
        dateFormat: 'dd.mm.yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['ru']);

    $.timepicker.regional['ru'] = {
        timeOnlyTitle: 'Выберите время',
        timeText: 'Время',
        hourText: 'Часы',
        minuteText: 'Минуты',
        secondText: 'Секунды',
        currentText: 'Теперь',
        closeText: 'Закрыть',
        ampm: false
    };
    $.timepicker.setDefaults($.timepicker.regional['ru']);
});
