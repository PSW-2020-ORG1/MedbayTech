
<template>
    <div id="med-main">
                <div v-for="(prescription, index) in prescriptions" :key="index">
                    <v-card >
                        <v-card-title class="primary secondary--text">Prescription</v-card-title>
                        <v-card-subtitle class="primary secondary--text">{{prescription.date}}</v-card-subtitle>
                        <v-card-text>
                            <p class="display-1 text--primary">
                                {{prescription.patientName}} {{prescription.patientSurname}}
                            </p>
                            <p>{{prescription.doctorName}} {{prescription.doctorSurname}}</p>
                            <v-divider style="min-width:100%"></v-divider>
                            <v-card-title><strong>Medication:</strong> </v-card-title>
                            <v-card-title>-{{prescription.medicationName}} {{prescription.medicationDosage}}</v-card-title>
                            <v-card-title>-Hourly Intake: {{prescription.medicationHourlyIntake}}</v-card-title>
                            <v-combobox v-model="pharmacy[index]"
                                    :items="availablePharamacies[index]"
                                    :rules="pharmacyRule"
                                    label="Pharmacies with the medication.">
                                    
                            </v-combobox>
                            <p v-if="status.prescriptionIndex !== index || status.message === '' " style="color:white">.</p>
                            <p v-else-if="status.message === 'We have the desired medication!'" style="color:forestgreen">{{status.message}}</p>
                            <p v-else style="color:red">{{status.message}}</p>
                        </v-card-text>
                        <v-card-actions>
                            <v-btn text
                                    class="white accent--text"
                                    @click="getPharmacies(prescription.medicationName, index)">
                                Ask pharmacies
                            </v-btn>
                            <v-spacer></v-spacer>
                            <v-btn text
                                    class="white accent--text"
                                   @click="sendPrescription(prescription, index)"
                                   :disabled="!pharmacy[index]">
                                Send to pharmacy
                            </v-btn>
                        </v-card-actions>
                    </v-card>

                    <v-dialog v-model="showModal" width="800" height="800" hide-overlay>
                        <v-card>
                            <v-card-text>
                                <h3>Prescription QR Code</h3>
                                <img :src="qrLink" alt="Not found!" width="400" height="400" />
                                <v-btn color="primary" text @click="showModal=false">Close</v-btn>
                            </v-card-text>
                        </v-card>
                    </v-dialog>
                </div>
    </div>
</template>

<script>
    
export default {
    data() {
        return {
            pharmacyRule: [
                v => !!v || "First ask the pharmacies or chose one.",
            ],
            reveal: false,
            status: {prescriptionIndex: "", message: ""},
            prescriptions: [],
            showModal: false,
            qrLink: {},  //require("../../../GeneratedPrescription/qrcode.png"),
            qrLinkPath: "",
            pharmacy: [],
            availablePharamacies: [],
            pharmacies: [],
            comboEnabled: [],
            allPharamacies: [],
            
        }
    },

    methods: {
        getPharmacies: function(medication, index){
            this.axios.get("http://localhost:50202/api/Pharmacy/available/" + medication)
                .then(response => {
                    this.availablePharamacies[index] = response.data;
                    console.log(this.availablePharamacies);
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        getAllPerscriptions: function () {
            this.axios.get("http://localhost:50202/api/Prescription")
                .then(response => {
                    this.prescriptions = response.data;
                    for (var i = 0; i < this.prescriptions.length; i++) {
                        this.comboEnabled[i] = true;
                        this.availablePharamacies[i] = [];
                        this.pharmacy[i] = "";
                    }
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        getQrCode: function () {
            this.axios.get("http://localhost:50202/api/Prescription/qrcode")
                .then(response => {
                    this.qrLinkPath = "../../../" + response.data;
                    console.log(this.qrLinkPath);
                    this.qrLinkPath = this.qrLinkPath.replace("\\", "/");
                    console.log(this.qrLinkPath);
                    this.qrLink = this.qrLinkPath;
                    //this.qrLink = require("../../../GeneratedPrescription/qrcode.png");
                    console.log(this.qrLinkPath);
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        sendPrescription: function (prescription, index) {
            prescription.pharmacy = this.pharmacy[index];
            this.axios.post("http://localhost:50202/api/Prescription/", prescription)
                .then(response => {
                    
                    console.log(response.data);

                    this.showModal = false;
                    this.notify();
                })
                .catch(response => {
                    console.log(response);
                });
        },

        notify: function() {
            this.axios.get("http://localhost:56764/api/Prescription/notify")
                .then(response => {
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response.data);
                })

        }
    },
    mounted() {
        this.getAllPerscriptions();
    }

}
</script>

<style scoped>
    #med-main {
        display:grid;
        grid-template-columns:1fr 1fr;
        place-items: center;

    }
</style>