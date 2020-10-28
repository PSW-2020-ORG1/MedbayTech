using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Repository;
using Repository.MedicationRepository;
using Controller;
using Controller.MedicationController;
using Service;
using Service.MedicationService;
using Model;
using Model.Medications;
using Model.Users;
using Repository.MedicalRecordRepository;
using Model.MedicalRecord;
using Repository.UserRepository;
using Controller.UserController;
using Service.UserService;
using Repository.GeneralRepository;
using Model.Rooms;
using Repository.RoomRepository;
using Repository.ExaminationRepository;
using Model.ExaminationSurgery;
using Repository.ScheduleRepository;
using Model.Schedule;
using Repository.ReportRepository;
using Model.Reports;
using Service.MedicalRecordService;
using Service.GeneralService;
using Service.RoomService;
using Service.ExaminationService;
using Service.ScheduleService;
using Service.ReportService;
using Controller.MedicalRecordController;
using Controller.ExaminationController;
using Controller.GeneralController;
using Controller.RoomController;
using Controller.ScheduleController;
using Controller.ReportController;
using SimsProjekat.Service.RoomService;
using SimsProjekat.Controller.RoomController;
using SimsProjekat.View;
using SimsProjekat.Controller.ScheduleController;
using SimsProjekat.Repository.ScheduleRepository;

namespace SimsProjekat
{
    public class Application
    {
        private const string MEDICATION_FILE = "../../../Repository/Data/medications.json";
        private const string VALIDATION_FILE = "../../../Repository/Data/validations.json";
        private const string ALLERGEN_FILE = "../../../Repository/Data/allergens.json";
        private const string CATEGORY_FILE = "../../../Repository/Data/medicationcategories.json";
        private const string SYMPTOMS_FILE = "../../../Repository/Data/symptoms.json";
        private const string INGREDIENTS_FILE = "../../../Repository/Data/medicationingredients.json";
        private const string SPECIALIZATION_FILE = "../../../Repository/Data/specializations.json";
        private const string USER_FILE = "../../../Repository/Data/users.json";
        private const string CITY_FILE = "../../../Repository/Data/cities.json";
        private const string ADDRESS_FILE = "../../../Repository/Data/addresses.json";
        private const string STATE_FILE = "../../../Repository/Data/states.json";
        private const string INSURANCE_FILE = "../../../Repository/Data/insurances.json";
        private const string DEPARTMENT_FILE = "../../../Repository/Data/departments.json";
        private const string ROOM_FILE = "../../../Repository/Data/rooms.json";
        private const string RENOVATION_FILE = "../../../Repository/Data/renovations.json";
        private const string BED_FILE = "../../../Repository/Data/beds.json";
        private const string HOSPITAL_FILE = "../../../Repository/Data/hospitals.json";
        private const string EQUIPMENT_TYPE_FILE = "../../../Repository/Data/equipmenttype.json";
        private const string EQUIPMENT_FILE = "../../../Repository/Data/equipments.json";
        private const string RECORD_FILE = "../../../Repository/Data/records.json";
        private const string DIAGNOSIS_FILE = "../../../Repository/Data/diagnosis.json";
        private const string TREATMENTS_FILE = "../../../Repository/Data/treatments.json";
        private const string EXAMINATION_SURGERY_FILE = "../../../Repository/Data/examinations.json";
        private const string EMERGENCY_REQUEST_FILE = "../../../Repository/Data/requests.json";
        private const string VACCINES_FILE = "../../../Repository/Data/vaccines.json";
        private const string ARTICLE_FILE = "../../../Repository/Data/articles.json";
        private const string NOTIFICATION_FILE = "../../../Repository/Data/notifications.json";
        private const string QUESTIONS_FILE = "../../../Repository/Data/questions.json";
        private const string DOCTOR_REVIEWS_FILE = "../../../Repository/Data/doctorreviews.json";
        private const string FEEDBACK_FILE = "../../../Repository/Data/feedbacks.json";
        private const string SURVEY_FILE = "../../../Repository/Data/surveys.json";
        private const string APPOINTMENTS_FILE = "../../../Repository/Data/appointments.json";
        private const string WORK_DAY_FILE = "../../../Repository/Data/workdays.json";
        private const string VACATION_REQUEST_FILE = "../../../Repository/Data/vacationrequests.json";
        private const string REPORTS_FILE = "../../../Repository/Data/reports.json";
        private const string LAB_TEST_TYPE_FILE = "../../../Repository/Data/labtypes.json";

        private const int UNDERAGE_RESTRICTION = 18;
        private const int APPOINTMENT_LENGTH_IN_MINUTES = 30;
        private const int MAX_HOURS_PER_WEEK = 60;
        private const int RENOVATION_DAYS_RESTRICTION = 15;
        private const int VALID_HOURS_FOR_SCHEDULING = 24;
        private const int START_WORKING_HOURS = 9;
        private const int END_WORKING_HOURS = 20;
        private const int SURGERY_LENGTH_IN_MINUTES = 150;
        private const int NUMBER_OF_ALLOWED_VACAY_REQUESTS = 2;
        public Application()
        {
            var medicationRepository = new MedicationRepository(new Stream<Medication>(MEDICATION_FILE));
            var diagnosisRepository = new DiagnosisRepository(new Stream<Diagnosis>(DIAGNOSIS_FILE));
            var allergenRepository = new AllergensRepository(new Stream<Allergens>(ALLERGEN_FILE));
            var categoryRepository = new MedicationCategoryRepository(new Stream<MedicationCategory>(CATEGORY_FILE));
            var symptomsRepository = new SymptomsRepository(new Stream<Symptoms>(SYMPTOMS_FILE));
            var ingredientsRepository = new MedicationIngredientRepository(new Stream<MedicationIngredient>(INGREDIENTS_FILE));
            var specializationRepository = new SpecializationRepository(new Stream<Specialization>(SPECIALIZATION_FILE));
            var cityRepository = new CityRepository(new Stream<City>(CITY_FILE));
            var addressRepository = new AddressRepository(new Stream<Address>(ADDRESS_FILE), cityRepository);
            var stateRepository = new StateRepository(new Stream<State>(STATE_FILE));
            var hospitalRepository = new HospitalRepository(new Stream<Hospital>(HOSPITAL_FILE));
            var departmentRepository = new DepartmentRepository(hospitalRepository, new Stream<Department>(DEPARTMENT_FILE));
            var roomRepository = new RoomRepository(departmentRepository, new Stream<Room>(ROOM_FILE));
            var userRepository = new UserRepository(new Stream<RegisteredUser>(USER_FILE), cityRepository, addressRepository, departmentRepository, roomRepository);
            var renovationRepository = new RenovationRepository(roomRepository, new Stream<Renovation>(RENOVATION_FILE));
            var medicalRecordRepository = new MedicalRecordRepository(new Stream<MedicalRecord>(RECORD_FILE), diagnosisRepository, medicationRepository, userRepository);
            var bedRepository = new BedRepository(roomRepository, medicalRecordRepository, new Stream<Bed>(BED_FILE));
            var equipmentTypeRepository = new EquipmentTypeRepository(new Stream<EquipmentType>(EQUIPMENT_TYPE_FILE));
            var equipmentRepository = new HospitalEquipmentRepository(new Stream<HospitalEquipment>(EQUIPMENT_FILE));
            var treatmentsRepository = new TreatmentRepository(medicationRepository, departmentRepository, new Stream<Treatment>(TREATMENTS_FILE));
            var examinationSurgeryRepository = new ExaminationSurgeryRepository(treatmentsRepository, medicalRecordRepository, userRepository, new Stream<ExaminationSurgery>(EXAMINATION_SURGERY_FILE));
            var emergencyRequestRepository = new EmergencyRequestRepository(medicalRecordRepository, new Stream<EmergencyRequest>(EMERGENCY_REQUEST_FILE));
            var vaccinesRepository = new VaccinesRepository(new Stream<Vaccines>(VACCINES_FILE));
            var notificationRepository = new NotificationRepository(userRepository, new Stream<Notification>(NOTIFICATION_FILE));
            var articleRepository = new ArticleRepository(userRepository, new Stream<Article>(ARTICLE_FILE));
            var questionRepository = new QuestionRepository(userRepository, new Stream<Question>(QUESTIONS_FILE));
            var doctorReviewsRepository = new DoctorReviewRepository(userRepository, new Stream<DoctorReview>(DOCTOR_REVIEWS_FILE));
            var feedbackRepository = new FeedbackRepository(userRepository, new Stream<Feedback>(FEEDBACK_FILE));
            var surveyRepository = new SurveyRepository(userRepository, new Stream<Survey>(SURVEY_FILE));
            var appointmentsRepository = new AppointmentRepository(userRepository, medicalRecordRepository, roomRepository, new Stream<Appointment>(APPOINTMENTS_FILE));
            var workDayRepository = new WorkDayRepository(userRepository, new Stream<WorkDay>(WORK_DAY_FILE));
            var vacationRequestRepository = new VacationRequestRepository(userRepository, new Stream<VacationRequest>(VACATION_REQUEST_FILE));
            var reportsRepository = new ReportRepository(new Stream<Report>(REPORTS_FILE));
            var labTestTypeRepository = new LabTestTypeRepository(new Stream<LabTestType>(LAB_TEST_TYPE_FILE));
            var validationMedicationRepository = new ValidationMedicationRepository(new Stream<ValidationMed>(VALIDATION_FILE), userRepository, medicationRepository);

            var equipmentTypeService = new EquipmentTypeService(equipmentTypeRepository);
            var medicationService = new MedicationService(medicationRepository, validationMedicationRepository);
            var diagnosisService = new DiagnosisService(diagnosisRepository);
            var allergenService = new AllergensService(allergenRepository);
            var categoryService = new MedicationCategoryService(categoryRepository);
            var symptomsService = new SymptomsService(symptomsRepository);
            var ingredientsService = new MedicationIngredientService(ingredientsRepository);
            var specializationService = new SpecializationService(specializationRepository);
            var cityService = new CityService(cityRepository);
            var stateService = new StateService(stateRepository);
            var addressService = new AddressService(addressRepository);
            var notificationService = new NotificationService(notificationRepository, userRepository, medicalRecordRepository);
            var validationMedicationService = new ValidationMedicationService(validationMedicationRepository, notificationService);
            var hospitalService = new HospitalService(hospitalRepository);
            var departmentService = new DepartmentService(departmentRepository);
            var bedService = new BedService(bedRepository);
            var medicalRecordService = new MedicalRecordService(medicalRecordRepository);
            var treatmentService = new TreatmentService(treatmentsRepository, notificationService);
            var examiantionSurgeryService = new ExaminationSurgeryService(examinationSurgeryRepository);
            var emergencyRequestService = new EmergencyRequestService(emergencyRequestRepository, notificationService);
            var vaccinesService = new VaccinesService(vaccinesRepository);
            var articleService = new ArticleService(articleRepository);
            var questionService = new QuestionService(questionRepository, notificationService);
            var doctorsReviewService = new DoctorReviewService(doctorReviewsRepository);
            var feedbackService = new FeedbackService(feedbackRepository);
            var surveyService = new SurveyService(surveyRepository);
            var userService = new UserService(userRepository, medicalRecordService);
            var workDayService = new WorkDayService(workDayRepository, MAX_HOURS_PER_WEEK);
            var appointmentService = new AppointmentService(appointmentsRepository, workDayService, notificationService, VALID_HOURS_FOR_SCHEDULING, APPOINTMENT_LENGTH_IN_MINUTES,
                SURGERY_LENGTH_IN_MINUTES, START_WORKING_HOURS, END_WORKING_HOURS);
            var vacationRequestService = new VacationRequestService(vacationRequestRepository, notificationService, NUMBER_OF_ALLOWED_VACAY_REQUESTS);
            var reportsService = new ReportService(reportsRepository, treatmentsRepository, medicationRepository, examinationSurgeryRepository, roomRepository);
            var labTestTypeService = new LabTestTypeService(labTestTypeRepository);
            var roomService = new RoomService(roomRepository, appointmentsRepository);
            var hospitalEquipmentService = new HospitalEquipmentService(equipmentRepository);
            var renovationService = new RenovationService(renovationRepository, roomService, appointmentsRepository, hospitalEquipmentService, notificationService, RENOVATION_DAYS_RESTRICTION, RENOVATION_DAYS_RESTRICTION);
            var availableAppointmentService = new AvailableAppointmentService(appointmentsRepository, workDayService, VALID_HOURS_FOR_SCHEDULING,
                APPOINTMENT_LENGTH_IN_MINUTES, SURGERY_LENGTH_IN_MINUTES, START_WORKING_HOURS, END_WORKING_HOURS);

            equipmentTypeController = new EquipmentTypeController(equipmentTypeService);
            medicationController = new MedicationController(medicationService);
            userController = new UserController(userService);
            diagnosisController = new DiagnosisController(diagnosisService);
            symptomsController = new SymptomsController(symptomsService);
            categoryController = new MedicationCategoryController(categoryService);
            allergensController = new AllergensController(allergenService);
            vaccinesController = new VaccinesController(vaccinesService);
            labTestTypeController = new LabTestTypeController(labTestTypeService);
            medicationIngredientController = new MedicationIngredientController(ingredientsService);
            cityController = new CityController(cityService);
            specializationController = new SpecializationController(specializationService);
            addressController = new AddressController(addressService);
            stateController = new StateController(stateService);
            departmentController = new DepartmentController(departmentService);
            hospitalController = new HospitalController(hospitalService);
            roomController = new RoomController(roomService);
            renovationController = new RenovationController(renovationService);
            hospitalEquipmentController = new HospitalEquipmentController(hospitalEquipmentService);
            medicalRecordController = new MedicalRecordController(medicalRecordService);
            treatmentController = new TreatmentController(treatmentService);
            examinationSurgeryController = new ExaminationSurgeryController(examiantionSurgeryService);
            articleController = new ArticleController(articleService);
            questionController = new QuestionController(questionService);
            doctorReviewController = new DoctorReviewController(doctorsReviewService);
            surveyController = new SurveyController(surveyService);
            feedbackController = new FeedbackController(feedbackService);
            workDayController = new WorkDayController(workDayService);
            reportController = new ReportController(reportsService);
            validationMedicationController = new ValidationMedicationController(validationMedicationService);
            vacationRequestController = new VacationRequestController(vacationRequestService);
            bedController = new BedController(bedService);
            emergencyRequestController = new EmergencyRequestController(emergencyRequestService);
            appointmentController = new AppointmentController(appointmentService);
            notificationController = new NotificationController(notificationService);
            availableAppointmentController = new AvailableAppointmentController(availableAppointmentService);

            validations = new Validations(UNDERAGE_RESTRICTION);
        }

        public Validations validations { get; set; }
        public MedicationController medicationController { get; set; }
        public UserController userController { get; set; }
        public DiagnosisController diagnosisController { get; set; }
        public SymptomsController symptomsController { get; set; }
        public MedicationCategoryController categoryController { get; set; }
        public AllergensController allergensController { get; set; }
        public VaccinesController vaccinesController { get; set; }
        public LabTestTypeController labTestTypeController { get; set; }
        public MedicationIngredientController medicationIngredientController { get; set; }
        public SpecializationController specializationController { get; set; }
        public CityController cityController { get; set; }
        public NotificationController notificationController { get; set; }
        public StateController stateController { get; set; }
        public AddressController addressController { get; set; }
        public HospitalController hospitalController { get; set; }
        public DepartmentController departmentController { get; set; }
        public RoomController roomController { get; set; }
        public BedController bedController { get; set; }
        public RenovationController renovationController { get; set; }
        public HospitalEquipmentController hospitalEquipmentController { get; set; }
        public MedicalRecordController medicalRecordController { get; set; }
        public TreatmentController treatmentController { get; set; }
        public ExaminationSurgeryController examinationSurgeryController { get; set; }
        public EmergencyRequestController emergencyRequestController { get; set; }
        public ArticleController articleController { get; set; }
        public QuestionController questionController { get; set; }
        public FeedbackController feedbackController { get; set; }
        public SurveyController surveyController { get; set; }
        public DoctorReviewController doctorReviewController { get; set; }
        public AppointmentController appointmentController { get; set; }
        public WorkDayController workDayController { get; set; }
        public VacationRequestController vacationRequestController { get; set; }
        public ReportController reportController { get; set; }
        public ValidationMedicationController validationMedicationController { get; set; }
        public EquipmentTypeController equipmentTypeController { get; set; }

        public AvailableAppointmentController availableAppointmentController { get; set; }

    }
}
