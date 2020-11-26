import { NumberValueAccessor } from '@angular/forms';

export class AppointmentSurvey{

    public Id : number;
    public Period : unknown;
    public TypeOfAppointment : string;
    public ShortDescription : string;
    public Urgent : boolean;
    public Deleted : boolean;
    public Finished : boolean;
    public RoomId : number;
    public MedicalRecordId : number;
    public DoctorId : string;
    public WeeklyAppointmentReportId : number;


    constructor(id :number, doctorId : string){
        this.Id = id;
        this.DoctorId = doctorId;
    }

}