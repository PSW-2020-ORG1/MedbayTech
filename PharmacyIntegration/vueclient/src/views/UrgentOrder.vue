<template>
    <div id="urgent-order-main">
        <div v-for="(request, index) in allRequests" :key="index">
            <v-card id="urgent-order-card">
                <v-card-title class="primary secondary--text">Urgent procurement</v-card-title>
                <v-card-subtitle class="primary secondary--text">Due date: 02.01.2021.</v-card-subtitle>
                <v-card-text>
                    <p class="display-1 text--primary">
                        {{request.medicationName}} {{request.medicationDosage}}
                    </p>
                    <p class="display-1 text--primary">
                        Quantity: {{request.medicationQuantity}}
                    </p>
                    <v-form v-model="valid[index]">
                        <v-combobox v-model="choosenPharmacy[index]"
                                    :items="allPharmacies"
                                    label="Choose pharmacy"
                                    :rules="pharmacyRule"
                                    clearable>
                        </v-combobox>
                    </v-form>
                        <p v-if="status.requestIndex !== index || status.message === '' " style="color:white">.</p>
                        <p v-else-if="status.message === 'We have the desired medication!'" style="color:forestgreen">{{status.message}}</p>
                        <p v-else style="color:red">{{status.message}}</p>
                </v-card-text>
                <v-card-actions>
                    <v-btn text
                           class="white accent--text"
                           @click="checkForMedication(request.medicationName, index)"
                           :disabled="!valid[index]">
                        Ask pharmacy
                    </v-btn>
                    <v-spacer></v-spacer>
                    <v-btn text
                           class="white accent--text"
                           @click="sendRequest(request)"
                           :disabled="!valid[index]">
                        Send request
                    </v-btn>
                </v-card-actions>
            </v-card>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            allRequests: [],
            allPharmacies: [],
            status: { requestIndex: "", message: "" },
            pharmacyRule: [
                v => !!v || "Phamracy is required",
            ],
            choosenPharmacy: [],
            valid: [],



        }
    },

    methods: {
        getAllRequests: function () {
            this.allRequests.push({ medicationName: "Brufen", medicationDosage: "100mg", medicationQuantity: 5 });
            this.allRequests.push({ medicationName: "Andol", medicationDosage: "200mg", medicationQuantity: 2 });
            this.allRequests.push({ medicationName: "Kafetin", medicationDosage: "300mg", medicationQuantity: 3 });
            this.allRequests.push({ medicationName: "Penicilin", medicationDosage: "400mg", medicationQuantity: 1 });
        },
        getAllPharmacies: function () {
            this.allPharmacies.push("Jankovic");
            this.allPharmacies.push("Benu");
            this.allPharmacies.push("Zegin");
            this.allPharmacies.push("Schnabel");
            this.valid[0] = false;
            this.valid[1] = false;
            this.valid[2] = false;
        },
        checkForMedication: function (medication, index) {
            this.axios.get("http://schnabel.herokuapp.com/pswapi/drugs/name/" + medication)
                .then(response => {
                    this.status.requestIndex = index;
                    this.status.message = response.data;

                    console.log(this.status.message);
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        sendRequest: function (request) {
            this.axios.post("http://localhost:50202/api/Prescription/", request)
                .then(response => {
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response);
                });
        },

    },
        mounted() {
            this.getAllRequests();
            this.getAllPharmacies();
    }
}
</script>

<style scoped>
    #urgent-order-main {
        display: grid;
        grid-template-columns: 1fr 1fr;
        place-items: center;
    }

    #urgent-order-card {
        margin-bottom: 10%;
    }
</style>
