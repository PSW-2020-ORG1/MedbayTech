

<template>
    <div id="urg-request-main">
        <v-card elevation="1">
            <v-card-title id="urg-request-content" class="primary secondary--text">
                Create urgent medication request
            </v-card-title>
            <v-card-text id="urg-request-card">
                <v-form id="urg-request-create" v-model="valid">
                    <v-combobox v-model="requestedMedication"
                                :items="allMedication"
                                label="Requared Medication"
                                :rules="reqMedicationRule"
                                clearable>
                    </v-combobox>
                    <v-text-field v-model="medicationQuantity"
                                  label="Quantity"
                                  :rules="quantityRule"
                                  hide-details />
                    <v-btn id="urg-request-create-btn" :disabled="!valid" elevation="2" @click="createRequest" class="deep-orange white--text">
                        Create
                    </v-btn>
                </v-form>
            </v-card-text>
        </v-card>
    </div>
</template>

<script>
export default {
    data() {
        return {
            allMedication: [],
            valid: false,
            quantityRule: [
                v => !!v || "Quntity is required",
            ],
            reqMedicationRule: [
                v => !!v || "Medication is required",
            ],
            requestedMedication: "",
            medicationQuantity: "",

        }
    },

    methods: {
        getAllMedications: function () {
            var medication = []

            medication.forEach(element => this.allMedication.push(element.name + " " + element.dosage));

           this.axios.get("http://localhost:50202/api/Medication")
               .then(response => {
                   var medication = response.data;
                   medication.forEach(element => this.allMedication.push(element.med));
                   console.log(response.data);
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        createRequest: function () {
            let name = this.requestedMedication.split(" ")[0];
            let dosage = this.requestedMedication.split(" ")[1];
            let urgnetProcurement = { medicationName: name, medicationDosage: dosage, medicationQuantity: this.medicationQuantity };
            this.axios.post("http://localhost:50202/api/Procurement/", urgnetProcurement)
                .then(response => {
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response);
                });
        }

    },
        mounted() {
            this.getAllMedications();
    }
}
</script>

<style scoped>
    #urg-request-content {
        display: grid;
        grid-template-columns: 1fr auto;
    }

    #urg-request-main {
        display: grid;
        place-items: center;
        height: 100%;
    }

    #urg-request-card {
        display: grid;
        grid-template-columns: auto 1fr;
    }

    #urg-request-create {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
    }
    #urg-request-create-btn {
        margin-top: 10%;
    }
</style>