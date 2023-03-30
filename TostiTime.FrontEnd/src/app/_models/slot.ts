import { Reservation } from "./reservation";

export interface Slot {
    id: number;
    slotName: string;    
    lastReservation: Reservation;
}