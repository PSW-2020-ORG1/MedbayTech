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
                                    :items="avaliablePharmacies[index]"
                                    label="Choose pharmacy"
                                    :rules="pharmacyRule"
                                    clearable>
                        </v-combobox>
                    </v-form>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn text
                           id="urgent-order-btn"
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
            pharmacyRule: [
                v => !!v || "Phamracy is required",
            ],
            choosenPharmacy: [],
            valid: [],
            avaliablePharmacies: [],



        }
    },

    methods: {
        getAllRequests: function () {
            this.axios.get("http://localhost:50202/api/Procurement/")
                .then(response => {
                    this.allRequests = response.data;
                    console.log(this.allRequests.lenght);
                    for (var i = 0; i < this.allRequests.length; i++) {
                        this.choosenPharmacy.push("");
                        this.checkForMedication(this.allRequests[i].medicationName);
                    }
                })
                .catch(response => {
                    console.log(response);
                })
        },
        getAllPharmacies: function () {
            this.axios.get("http://localhost:50202/api/pharmacy")
                .then(response => {
                    this.allPharmacies = response.data;
                    this.allPharmacies.push({ id: "Schnabel", apiKey: "1234254", apiEndpoint: "http://schnabel.herokuapp.com/pswapi/drugs/name/", RecieveNotificationFrom: true });
                    for (var i = 0; i < this.allPharmacies.length; i++) {
                        this.valid.push("");
                    }
                })
                .catch(response => {
                    console.log(response);
                })
        },
        checkForMedication: function (medication) {
            this.axios.get("http://schnabel.herokuapp.com/pswapi/drugs/name/" + medication)
                .then(response => {
                    var pharmacies = [];
                    if (response.data === 'We have the desired medication!') {
                        pharmacies.push("Schnabel");
                    }
                    this.avaliablePharmacies.push(pharmacies);
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        sendRequest: function (request) {
            console.log(request);
           /* this.axios.post("http://localhost:50202/api/Prescription/", request)
                .then(response => {
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response);
                });*/
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

    #urgent-order-btn {
        min-width: 100%;
    }
</style>
