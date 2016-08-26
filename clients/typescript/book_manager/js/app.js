var BookCategory = (function () {
    function BookCategory(catName) {
        this.catName = catName;
    }
    return BookCategory;
}());
/// <reference path="BookCategory.ts" />
var Book = (function () {
    function Book(bookName, category) {
        this.bookName = bookName;
        this.category = category;
    }
    return Book;
}());
/// <reference path="./book.ts" />
var BookManager = (function () {
    function BookManager() {
        this.bookArr = ko.observableArray(this.getAllBooks());
        this.bookName = ko.observable();
        console.log(this.bookArr());
    }
    BookManager.prototype.getAllBooks = function () {
        var json = null;
        $.ajax({
            'async': false,
            'global': false,
            'url': '../data/books.json',
            'dataType': "json",
            'success': function (data) {
                json = data;
            }
        });
        return json;
    };
    BookManager.prototype.getBook = function (cateName) {
        var books = _.filter(this.bookArr(), function (book) { return book.category.catName === cateName; });
        return books;
    };
    return BookManager;
}());
/// <reference path="BookManager.ts" />
/// <reference path="typings/knockout.d.ts" />
/// <reference path="typings/underscore.d.ts" />
/// <reference path="typings/jquery.d.ts" />
var manager = new BookManager();
ko.applyBindings(manager);
//# sourceMappingURL=app.js.map