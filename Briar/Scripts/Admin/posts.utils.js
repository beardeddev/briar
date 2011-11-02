$(function () {
    $('input[data-action="add-category"]').click(function () {
        var title = $('input[data-value="category"]').val();
        var count = $('ul[data-type="categories-list"] li').length;

        $("#categoryTemplate").tmpl({ 'title': title, 'index': count })
                .appendTo('ul[data-type="categories-list"]');
    });

    $('input[data-action="add-tag"]').click(function () {
        var title = $('input[data-value="tag"]').val();
        var count = $('ul[data-type="tags-list"] li').length;

        $("#tagTemplate").tmpl({ 'title': title, 'index': count })
                .appendTo('ul[data-type="tags-list"]');
    });

    $('ul[data-type="categories-list"] a[data-action="delete-category"]').live('click', function () {
        $(this).parent('li').remove();

        $('ul[data-type="categories-list"] li').each(function (index, Element) {
            $(this).find('input[data-value="title"]').attr('name', 'Categories[' + index + '].Title');
            $(this).find('input[data-value="id"]').attr('name', 'Categories[' + index + '].Id');
        });

        return false;
    })

    $('ul[data-type="tags-list"] a[data-action="delete-tag"]').live('click', function () {
        $(this).parent('li').remove();
        return false;
    })

});