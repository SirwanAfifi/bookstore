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