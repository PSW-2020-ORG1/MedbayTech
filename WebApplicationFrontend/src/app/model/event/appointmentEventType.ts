export enum AppointmentEventType {
    Started,
    Created,
    Quit,
    FromStartedToSelectSpecialization,
    FromSelectSpecializationToStarted,
    FromSelectSpecializationToSelectDoctor,
    FromSelectDoctorToSelectSpecialization,
    FromSelectDoctorToSelectAppointment,
    FromSelectAppointmentToSelectDoctor
}