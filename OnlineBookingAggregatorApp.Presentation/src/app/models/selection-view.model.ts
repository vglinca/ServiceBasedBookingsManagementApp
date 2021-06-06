export class SelectionViewModel {
    id: number;
    name: string;

    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
    }
}

export class SelectionModel<T>{
    id: T;
    name: string;
    constructor(id: T, name: string) {
        this.id = id;
        this.name = name;
    }
}
