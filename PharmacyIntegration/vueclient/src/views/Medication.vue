
<template>
    <div id="app">
        <v-app id="inspire">
            <v-row>
                <v-col cols="12" sm="3" md="4" v-for="(something, index) in perscriptions" :key="index">
                    <v-card class="mx-auto"
                            max-width="344">
                        <v-card-text>
                            <div>11.12.2020.</div>
                            <p class="display-1 text--primary">
                                Patient's Full Name
                            </p>
                            <p>Doctor's full name</p>
                            <v-divider style="min-width:100%"></v-divider>
                            <v-card-title><strong>Medication:</strong><br/> -Aspirin 100mg <br/>-Intake: 2 time per day</v-card-title>
                            <div v-if="status[index] === '' "><p style="color:white">.</p></div>
                            <div v-else ><p style="color:forestgreen">{{status[index]}}</p></div>
                        </v-card-text>
                        <v-card-actions>
                            <v-btn text
                                   color="teal accent-4"
                                   @click="checkForMedication(index)">
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
            perscriptions: []
        }
    },

    methods: {
        checkForMedication: function (medication) {
            this.axios.get("http://localhost:50202/api/Medication/check/" + medication)
                .then(response => {
                    this.status = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
            
            
        },
        getAllPerscriptions: function () {
            /*this.axios.get("http://localhost:50202/api/Perscription")
                .then(response => {
                    this.perscription = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })*/
            this.status.push("");
            this.status.push("");
            this.status.push("");
            this.status.push("");
            this.status.push("");
            this.status.push("");
            this.status.push("");
            this.perscriptions.push(1);
            this.perscriptions.push(2);
            this.perscriptions.push(3);
            this.perscriptions.push(4);
            this.perscriptions.push(5);
            this.perscriptions.push(6);
            this.perscriptions.push(7);
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