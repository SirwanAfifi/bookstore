/// <reference path="./book.ts" />

class BookManager {
    
    bookArr = ko.observableArray<Book>(this.getAllBooks());

    constructor() {
        console.log(this.bookArr());
    }

    private getAllBooks(): Array<Book> {
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
    }

    getBook(cateName: string): Array<Book> {
        var books = _.filter(this.bookArr(), function(book){ return book.category.catName === cateName; });
        return books;
    }
    
}