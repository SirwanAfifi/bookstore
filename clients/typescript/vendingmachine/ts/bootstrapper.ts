/// <reference path="vendingMachine.ts" />
/// <reference path="typings/knockout.d.ts" />


var machine = new VendingMachine();
machine.size = 12;
ko.applyBindings(machine);
