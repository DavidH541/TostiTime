import { Slot } from "./slot";

export interface Iron {
    id: number;
    name: string;
    numberOfSlots: number;
    slots: Slot[];
}