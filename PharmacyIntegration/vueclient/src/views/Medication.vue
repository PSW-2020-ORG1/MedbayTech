
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
                            <p v-if="status.prescriptionIndex !== index || status.message === '' " style="color:white">.</p>
                            <p v-else-if="status.message === 'We have the desired medication!'" style="color:forestgreen">{{status.message}}</p>
                            <p v-else style="color:red">{{status.message}}</p>
                        </v-card-text>
                        <v-card-actions>
                            <v-btn text
                                    class="white accent--text"
                                   @click="checkForMedication(prescription.medicationName, index)">
                                Ask pharmacy
                            </v-btn>
                            <v-spacer></v-spacer>
                            <v-btn text
                                    class="white accent--text"
                                   @click="sendPrescription(prescription)">
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
            reveal: false,
            status: {prescriptionIndex: "", message: ""},
            prescriptions: [],
            showModal: false,
            qrLink: {},  //require("../../../GeneratedPrescription/qrcode.png"),
            qrLinkPath: "",
            
        }
    },

    methods: {
        checkForMedication: function (medication, index) {
            // This is for gRPC
            //this.axios.get("http://localhost:50202/api/Medication/check/" + medication)
            this.axios.get("http://schnabel.herokuapp.com/pswapi/drugs/name/" + medication)
                .then(response => {
                    this.status.prescriptionIndex = index;
                    this.status.message = response.data;
                    

                    console.log(this.status.message);
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
        sendPrescription: function (prescription) {
            this.axios.post("http://localhost:50202/api/Prescription/", prescription)
                .then(response => {
                    //This is for sftp
                    /*this.axios.get("http://localhost:50202/api/Sftp")
                        .then(response => {
                            console.log(response.data);
                        })*/
                    console.log(response.data);

                    this.showModal = false;
                })
                .catch(response => {
                    console.log(response);
                });
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