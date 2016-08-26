/// <reference path="./book.ts" />

class BookManager {

    bookArr = ko.observableArray<Book>(this.getAllBooks());

    constructor() {
        console.log(this.bookArr());
    }

    private getAllBooks(): Array<Book> {
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
    }

    getBook(cateName: string): Array<Book> {
        var books = _.filter(this.bookArr(), function (book) { return book.category.catName === cateName; });
        return books;
    }

}