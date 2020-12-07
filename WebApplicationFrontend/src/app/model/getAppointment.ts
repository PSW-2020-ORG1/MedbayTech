export class GetAppointment{
    public id : number;
    public start : Date;
    public end : Date;
    public typeOfAppointment : string;
    public finished : boolean;
    public canceledByPatient : boolean;
    public roomNumber : number;
    public roomType : string;
    public doctorId : string;
    public name: string;
    public surname : string;

    constructor(id : number, start : Date, end : Date, typeOfAppointment : string, finished : boolean, canceledByPatient : boolean, roomNumber : number,
                roomType: string, doctorId : string, name : string, surname : string)
    {
        this.id = id;
        this.start = start;
        this.end = end;
        this.typeOfAppointment = typeOfAppointment;
        this.finished = finished;
        this.canceledByPatient = canceledByPatient;
        this.roomNumber = roomNumber;
        this.roomType = roomType;
        this.doctorId = doctorId;
        this.name = name;
        this.surname = surname;
    }
}