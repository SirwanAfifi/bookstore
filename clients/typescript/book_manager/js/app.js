var BookCategory = (function () {
    function BookCategory(catName) {
        this.catName = catName;
    }
    return BookCategory;
}());
/// <reference path="BookCategory.ts" />
var Book = (function () {
    function Book(bookName, category, price) {
        this.bookName = bookName;
        this.category = category;
        this.price = price;
    }
    return Book;
}());
/// <reference path="./book.ts" />
var BookManager = (function () {
    function BookManager() {
        this.bookArr = ko.observableArray(this.getAllBooks());
        this.bookName = ko.observable();
        //console.log(this.bookArr());
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
/// <reference path="./book.ts" />
/// <reference path="./bookManager.ts" />
var ShoppingCart = (function () {
    function ShoppingCart() {
        var _this = this;
        this.items = ko.observableArray();
        this.total = ko.observable();
        this.addItem = function (book) {
            if (!_.contains(_this.items(), book)) {
                _this.items.push(book);
                console.log(book.bookName + " added to cart!");
            }
            else {
                console.log('this book is already in the cart!');
            }
            console.log(_this.getTotal());
        };
        this.removeItem = function (book) { };
    }
    ShoppingCart.prototype.getTotal = function () {
        var _this = this;
        var total = 0;
        _.each(this.items(), function (book) {
            total += book.price;
            _this.total(total);
        });
        return total;
    };
    return ShoppingCart;
}());
/// <reference path="BookManager.ts" />
/// <reference path="shoppingCart.ts" />
/// <reference path="typings/knockout.d.ts" />
/// <reference path="typings/underscore.d.ts" />
/// <reference path="typings/jquery.d.ts" />
var manager = new BookManager();
var shoppingCart = new ShoppingCart();
var viewModel = {
    manager: manager,
    shoppingCart: shoppingCart
};
ko.applyBindings(viewModel);
//# sourceMappingURL=app.js.map