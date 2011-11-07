/// categories
var Category = function (title, objectId) {
    this.Title = title;
    this.ObjectId = objectId;

    this.remove = function () {
        categoryViewModel.categories.remove(this);
    };
};

var categoryItems = $.map(categoriesJson, function (item) {
    return new Category(item.Title, item.ObjectId);
});

var categoryViewModel = {
    categories: ko.observableArray(categoryItems),

    addCategory: function () {
        var title = $('input[data-value="category"]').val();
        this.categories.push(new Category(title));
        $('input[data-value="category"]').val('');
    }
};

///  tags
var Tag = function(title, objectId) {
    this.Title = title;
    this.ObjectId = objectId;

    this.remove = function(){
        tagViewModel.tags.remove(this);
    };
};

var tagItems = $.map(tagsJson, function (item) {
    return new Tag(item.Title, item.ObjectId);
});

var tagViewModel = {
    tags : ko.observableArray(tagItems),
            
    addTag: function() {
        var title = $('input[data-value="tag"]').val();
        this.tags.push(new Tag(title));
        $('input[data-value="tag"]').val('');
    }
};

$(function () {
    ko.applyBindings(tagViewModel, $(".editor-label-tags")[0]);
    ko.applyBindings(categoryViewModel, $(".editor-label-categories")[0]);
});