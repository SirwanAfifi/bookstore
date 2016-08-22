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
        console.log(this.bookArr());
    }
    BookManager.prototype.getAllBooks = function () {
        return [
            new Book("Book1", new BookCategory("Category1")),
            new Book("Book2", new BookCategory("Category2")),
            new Book("Book3", new BookCategory("Category3")),
            new Book("Book4", new BookCategory("Category4")),
            new Book("Book5", new BookCategory("Category5")),
            new Book("Book6", new BookCategory("Category6")),
            new Book("Book7", new BookCategory("Category7")),
            new Book("Book8", new BookCategory("Category8")),
        ];
    };
    return BookManager;
}());
/// <reference path="BookManager.ts" />
/// <reference path="typings/knockout.d.ts" />
var manager = new BookManager();
ko.applyBindings(manager);
//# sourceMappingURL=app.js.map