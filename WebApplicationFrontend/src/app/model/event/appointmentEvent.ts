import { AppointmentEventType } from './appointmentEventType';
export class AppointmentEvent {
    public appointmentEventType : AppointmentEventType;
    public eventIdentificator : string;

    constructor(appointmentEventType : AppointmentEventType, eventIdentificator : string) {
        this.appointmentEventType = appointmentEventType;
        this.eventIdentificator = eventIdentificator;
    }
}