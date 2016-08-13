abstract class Coin {
    constructor(public value: number) {
        this.value = value;
    }
    abstract getImageUrl(): string;
}


class Quarter extends Coin {
   constructor() {
       super(.25);
   }
    set Value(newValue: number) {
        this.value = newValue;
    }
    getImageUrl (): string {
        return "img/Quarter.png";
    }
}

class Dime extends Coin {
   constructor() {
       super(.25);
   }
    set Value(newValue: number) {
        this.value = newValue;
    }
    getImageUrl (): string {
        return "img/Dime.png";
    }
}

class Half extends Coin {
   constructor() {
       super(.25);
   }
    set Value(newValue: number) {
        this.value = newValue;
    }
    getImageUrl (): string {
        return "img/Half.png";
    }
}

class Dollar extends Coin {
   constructor() {
       super(.25);
   }
    set Value(newValue: number) {
        this.value = newValue;
    }
    getImageUrl (): string {
        return "img/Dollar.png";
    }
}
var coin = new Quarter();
var value = coin.Value;
coin.Value = 0.25;