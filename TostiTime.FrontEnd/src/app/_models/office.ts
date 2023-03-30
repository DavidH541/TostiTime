import { Iron } from "./iron";
import { Person } from "./person";

export interface Office {
    id: number;
    country: string;
    city: string;
    cityCode: string;
    address: string;
    postalCode: string;
    numberOfIrons: number;
    irons: Iron[];
    persons: Person[];
}