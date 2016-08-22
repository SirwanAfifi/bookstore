/// <reference path="BookManager.ts" />
/// <reference path="typings/knockout.d.ts" />
/// <reference path="typings/underscore.d.ts" />


var manager = new BookManager();
ko.applyBindings(manager);