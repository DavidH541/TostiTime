import { Injectable } from "@angular/core";
import { Reservation } from "../_models/reservation";

@Injectable()
export class OccupationService {
    isOccupied(lastReservation: Reservation): boolean {
        if (lastReservation?.occupiedUntil !== undefined) {
            const occupiedUntilString = lastReservation.occupiedUntil.toString();
            const _occupiedUntil = new Date(occupiedUntilString);
            return _occupiedUntil.getFullYear() === 9999;
        }
        return false;
    }

    calculateTimeSinceOccupation(occupiedSince: Date): [number, number] {
        const differenceInSeconds = (new Date().getTime() - occupiedSince.getTime() + occupiedSince.getTimezoneOffset() * 60 * 1000) / 1000;
        const minutesSince = Math.floor(Math.abs(differenceInSeconds) / 60);
        const secondsSince = Math.floor(Math.abs(differenceInSeconds) % 60);
        return [minutesSince, secondsSince];
    }
}