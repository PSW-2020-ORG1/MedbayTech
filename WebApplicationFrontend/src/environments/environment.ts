// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  baseUrl: 'http://localhost:53843',
  createdCount : 'getCreatedCount',
  backStepCount : 'getBackStepCount',
  quitCount : 'getCountOfQuit',
  succeedQuitRatio : 'getPercentSuccessfulAndQuit',
  event : 'saveEvent',
  fedback: 'approvedFeedback',
  allFeedback: 'allFeedback',
  updateFeedbackStatus: 'updateFeedbackStatus',
  createFeedback : 'createFeedback',
  survey: 'survey',
  allQuestions: 'allQuestions',
  createSurvey : 'createSurvey',
  prescription: 'prescription',
  report: 'examinationsurgery',
  allPrescriptions: 'allPrescriptions',
  allReports: 'allReports',
  registration : 'registration',
  patientRegistration : 'patientRegistration',
  authenticate: 'authenticate',
  doctor : 'doctor',
  searchDoctor : 'allDoctors',
  medicalRecord : 'medicalRecord',
  prescriptionSimpleSearch : 'prescription',
  reportSimpleSearch : 'report',
  patient: 'patient',
  updatePatientStatus: 'updatePatientStatus',
  maliciousPatients: 'maliciousPatients',
  allSurveyableAppointments : 'allSurveyableAppointments',
  allOtherAppointments : 'allOtherAppointments',
  allCancelableAppointments : 'allCancelableAppointments',
  cancelAppointment : 'cancelAppointment',
  allSpecializations : 'specialization',
  doctorsBySpecialization : "specialization",
  appointments : 'appointment',
  availableStrategy : 'availableStrategy',
  availableStandard : 'available',
  scheduleAppointment : 'schedule',
  averageNumberOfStepsForSuccessful: 'getAverageNumberOfStepsForSuccessful',
  averageSchedulingTime: 'averageSchedulingTime',
  getAverageTimeFromStartedToSpecialization: 'getAverageTimeFromStartedToSpecialization',
  getAverageTimeFromSpecializationToDoctor: 'getAverageTimeFromSpecializationToDoctor',
  getAverageTimeFromDoctorToSelectAppointment: 'getAverageTimeFromDoctorToSelectAppointment'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
