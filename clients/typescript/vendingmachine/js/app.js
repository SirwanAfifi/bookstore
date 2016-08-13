var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Coin = (function () {
    function Coin(value) {
        this.value = value;
        this.value = value;
    }
    return Coin;
}());
var Quarter = (function (_super) {
    __extends(Quarter, _super);
    function Quarter() {
        _super.call(this, .25);
    }
    Object.defineProperty(Quarter.prototype, "Value", {
        set: function (newValue) {
            this.value = newValue;
        },
        enumerable: true,
        configurable: true
    });
    Quarter.prototype.getImageUrl = function () {
        return "img/Quarter.png";
    };
    return Quarter;
}(Coin));
var Dime = (function (_super) {
    __extends(Dime, _super);
    function Dime() {
        _super.call(this, .25);
    }
    Object.defineProperty(Dime.prototype, "Value", {
        set: function (newValue) {
            this.value = newValue;
        },
        enumerable: true,
        configurable: true
    });
    Dime.prototype.getImageUrl = function () {
        return "img/Dime.png";
    };
    return Dime;
}(Coin));
var Half = (function (_super) {
    __extends(Half, _super);
    function Half() {
        _super.call(this, .25);
    }
    Object.defineProperty(Half.prototype, "Value", {
        set: function (newValue) {
            this.value = newValue;
        },
        enumerable: true,
        configurable: true
    });
    Half.prototype.getImageUrl = function () {
        return "img/Half.png";
    };
    return Half;
}(Coin));
var Dollar = (function (_super) {
    __extends(Dollar, _super);
    function Dollar() {
        _super.call(this, .25);
    }
    Object.defineProperty(Dollar.prototype, "Value", {
        set: function (newValue) {
            this.value = newValue;
        },
        enumerable: true,
        configurable: true
    });
    Dollar.prototype.getImageUrl = function () {
        return "img/Dollar.png";
    };
    return Dollar;
}(Coin));
var coin = new Quarter();
var value = coin.Value;
coin.Value = 0.25;
var SodaCategory = (function () {
    function SodaCategory() {
        this.name = "Soda";
    }
    SodaCategory.prototype.getImageUrl = function () {
        return "img/SodaCan.png";
    };
    return SodaCategory;
}());
/// <reference path="productCategory.ts" />
var CocaCola = (function () {
    function CocaCola() {
        this.name = "Coca-Cola";
        this.price = 2.30;
        this.category = new SodaCategory();
    }
    return CocaCola;
}());
/// <reference path="product.ts" />
var productFactory = (function () {
    function productFactory() {
    }
    productFactory.GetProduct = function () {
        return new CocaCola();
    };
    return productFactory;
}());
/// <reference path="./coin.ts" />
/// <reference path="./product.ts" />
/// <reference path="./productFactory.ts" />
var VendingMachineSize;
(function (VendingMachineSize) {
    VendingMachineSize[VendingMachineSize["small"] = 6] = "small";
    VendingMachineSize[VendingMachineSize["medium"] = 9] = "medium";
    VendingMachineSize[VendingMachineSize["large"] = 12] = "large";
})(VendingMachineSize || (VendingMachineSize = {}));
var Cell = (function () {
    function Cell(product) {
        this.product = product;
        this.stock = ko.observable(3);
        this.sold = ko.observable(false);
    }
    return Cell;
}());
var VendingMachine = (function () {
    function VendingMachine() {
        var _this = this;
        this.paid = ko.observable(0);
        this.selectedCell = ko.observable(new Cell(new CocaCola()));
        this.cells = ko.observableArray([]);
        this.acceptedCoins = [new Dime(), new Quarter(), new Half(), new Dollar()];
        this.canPay = ko.pureComputed(function () { return _this.paid() -
            _this.selectedCell().product.price >= 0; });
        this.select = function (cell) {
            cell.sold(false);
            _this.selectedCell(cell);
        };
        this.acceptCoin = function (coin) {
            var oldTotal = _this.paid();
            _this.paid(oldTotal + coin.Value);
        };
        this.pay = function () {
            if (_this.selectedCell().stock() < 1) {
                alert("I'm sorry, we're out of them!");
                return;
            }
            var currentPaid = _this.paid();
            _this.paid(Math.round(((currentPaid -
                _this.selectedCell().product.price) * 100)) / 100);
            var currentStock = _this.selectedCell().stock();
            _this.selectedCell().stock(currentStock - 1);
            _this.selectedCell().sold(true);
        };
    }
    Object.defineProperty(VendingMachine.prototype, "size", {
        set: function (givenSize) {
            this.cells([]);
            for (var index = 0; index < givenSize; index++) {
                var product = productFactory.GetProduct();
                this.cells.push(new Cell(product));
            }
        },
        enumerable: true,
        configurable: true
    });
    return VendingMachine;
}());
/// <reference path="vendingMachine.ts" />
/// <reference path="typings/knockout.d.ts" />
var machine = new VendingMachine();
machine.size = 6;
ko.applyBindings(machine);
//# sourceMappingURL=app.js.map