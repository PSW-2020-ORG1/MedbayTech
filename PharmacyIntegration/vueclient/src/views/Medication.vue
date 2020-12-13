
<template>
    <div id="app">
        <v-app id="inspire">
            <v-row>
                <v-col cols="12" sm="3" md="4" v-for="(prescription, index) in prescriptions" :key="index">
                    <v-card class="mx-auto"
                            max-width="344">
                        <v-card-text>
                            <div>{{prescription.date}}</div>
                            <p class="display-1 text--primary">
                                {{prescription.examinationSurgery.medicalRecord.patient.name}} {{prescription.examinationSurgery.medicalRecord.patient.surname}}
                            </p>
                            <p>{{prescription.examinationSurgery.doctor.name}} {{prescription.examinationSurgery.doctor.surname}}</p>
                            <v-divider style="min-width:100%"></v-divider>
                            <v-card-title><strong>Medication:</strong> </v-card-title>
                            <v-card-title>-{{prescription.medication.med}} {{prescription.medication.dosage}}</v-card-title>
                            <v-card-title>-Hourly Intake: {{prescription.hourlyIntake}}</v-card-title>
                            <div v-if="status[index] === '' "><p style="color:white">.</p></div>
                            <div v-else ><p style="color:forestgreen">{{status[index]}}</p></div>
                        </v-card-text>
                        <v-card-actions>
                            <v-btn text
                                   color="teal accent-4"
                                   @click="checkForMedication(prescription.medication.med, index)">
                                Ask pharmacy
                            </v-btn>
                            <v-spacer></v-spacer>
                            <v-btn text
                                   color="teal accent-4"
                                   @click="sendPrescription(index)">
                                Sent to pharmacy
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>
            </v-row>
        </v-app>
    </div>
</template>

<script>
export default {
    data() {
        return {
            reveal: false,
            status: [],
            prescriptions: []
        }
    },

    methods: {
        checkForMedication: function (medication, index) {
            this.axios.get("http://localhost:50202/api/Medication/check/" + medication)
                .then(response => {
                    this.status[index] = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
            
            
        },
        getAllPerscriptions: function () {
            this.axios.get("http://localhost:50202/api/Prescription")
                .then(response => {
                    this.prescriptions = response.data;
                    for (var i = 0; i < this.prescriptions.lenght; i++) {
                        status.push("");
                    }
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        sendPrescription: function (prescription) {
            console.log(prescription)
        }
    },
    mounted() {
        this.getAllPerscriptions();
    }

}
</script>

<style scoped>
</style>