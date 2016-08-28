/// <reference path="./book.ts" />
/// <reference path="./bookManager.ts" />

class ShoppingCart {
    
    items = ko.observableArray<Book>();
    total = ko.observable();
    
    addItem = (book: Book): void => {
        if (!_.contains(this.items(), book)) {
            this.items.push(book);
            console.log(`${book.bookName} added to cart!`);
        } else {
            console.log('this book is already in the cart!');
        }

        console.log(this.getTotal());
    }

    removeItem = (book: Book): void => {}

    getTotal(): number {
        let total: number = 0;
        _.each(this.items(), (book) => {
            total += book.price;
            this.total(total);
        });
        return total;
    }

}