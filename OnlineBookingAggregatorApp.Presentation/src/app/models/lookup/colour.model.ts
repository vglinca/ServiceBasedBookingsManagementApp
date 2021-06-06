import {BaseLookupModel} from './base-lookup.model';

export class ColourModel extends BaseLookupModel {
    public primary: string;
    public secondary: string;
    constructor(id: number, name: string, primary: string, secondary: string) {
        super(id, name);
        this.primary = primary;
        this.secondary = secondary;
    }
}
