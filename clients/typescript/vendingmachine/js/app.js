var VendingMachine = (function () {
    function VendingMachine() {
    }
    return VendingMachine;
}());
/// <reference path="vendingMachine.ts" />
var machine = new VendingMachine();
var Quarter = (function () {
    function Quarter() {
        this.value = .25;
    }
    Quarter.prototype.getImageUrl = function () {
        return "img/Quarter.png";
    };
    return Quarter;
}());
//# sourceMappingURL=app.js.map