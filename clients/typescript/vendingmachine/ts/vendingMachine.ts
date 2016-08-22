import { IProduct, Initial } from './product';
import getVendingProduct from './productFactory';
import * as Coins from './coin'

export enum VendingMachineSize {
    small = 6,
    medium = 9,
    large = 12
}

class Cell {
    constructor (public product: IProduct) {

    }
    stock = ko.observable<number>(3);
    sold = ko.observable<boolean>(false);
}

export class VendingMachine {
    private paid = ko.observable(0);
    selectedCell = ko.observable(new Cell(new Initial()));
    cells = ko.observableArray([]);
    acceptedCoins: Array<Coins.Coin> = [new Coins.Dime(), new Coins.Quarter(), new Coins.Half(), new Coins.Dollar()];
    canPay = ko.pureComputed(() => this.paid() -
        this.selectedCell().product.price >= 0);

    set size(givenSize: VendingMachineSize) {
        this.cells([]);
        
        for (let index = 0; index < givenSize; index++) {
            let product = getVendingProduct();
            this.cells.push(new Cell(product));
        }
    }

    select = (cell: Cell): void => {
        cell.sold(false);
        this.selectedCell(cell);
    }

    acceptCoin = (coin: Coins.Quarter): void => {
        let oldTotal = this.paid();
        this.paid(oldTotal + coin.value);
    }

    pay = (): void => {
        if (this.selectedCell().stock() < 1) {
            alert("I'm sorry, we're out of them!");
            return;
        }
        let currentPaid = this.paid();
        this.paid(Math.round(((currentPaid -
            this.selectedCell().product.price) * 100)) / 100);
        let currentStock = this.selectedCell().stock();
        this.selectedCell().stock(currentStock - 1);
        this.selectedCell().sold(true);
    }
}