

<template>
    <div id="urg-request-main">
        <transition name="bounce">
            <v-card v-if="show" elevation="1">
                <v-card-title id="urg-request-content" class="primary secondary--text">
                    Create urgent medication request
                </v-card-title>
                <v-card-text id="urg-request-card">
                    <v-form id="urg-request-create" v-model="valid">
                        <v-combobox v-model="requiredMedication"
                                    :items="allMedication"
                                    label="Required Medication"
                                    :rules="reqMedicationRule">
                            <template v-slot:append-outer>
                                <v-btn id="urg-request-btn"
                                       elevation="2"
                                       @click="show = !show" class="deep-orange white--text">
                                    Add new
                                </v-btn>
                            </template>
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
        </transition>
        <transition name="bounce">
            <v-card v-if="!show" elevation="1">
                <v-card-title id="urg-request-content" class="primary secondary--text">
                    Add new medication
                </v-card-title>
                <v-card-text id="urg-request-card">
                    <v-form id="urg-request-create" v-model="validAdd">
                        <v-text-field v-model="medName"
                                      label="Medication name"
                                      :rules="medNameRule"
                                      hide-details />
                        <v-text-field v-model="medDosage"
                                      label="Medication dosage"
                                      :rules="medDosageRule"
                                      hide-details />
                    </v-form>
                </v-card-text>
                <v-card-actions>
                    <v-btn id="urg-request-create-btn" 
                           :disabled="!validAdd" 
                           elevation="2" 
                           @click="addNewMedication" 
                           class="deep-orange white--text">
                        Add
                    </v-btn>
                    <v-spacer></v-spacer>
                    <v-btn text
                           id="urg-request-create-btn"
                           class="deep-orange white--text"
                           @click="show = !show">
                        Cancel
                    </v-btn>
                </v-card-actions>
            </v-card>
        </transition>
    </div>
</template>

<script>
export default {
    data() {
        return {
            allMedication: [],
            valid: false,
            quantityRule: [
                v => !!v || "Quantity is required",
            ],
            medNameRule: [
                v => !!v || "Name is required",
            ],
            medDosageRule: [
                v => !!v || "Dosage is required",
            ],
            reqMedicationRule: [
                v => !!v || "Medication is required",
            ],
            requiredMedication: "",
            medicationQuantity: "",
            show: true,
            validAdd: false,
            medName: "",
            medDosage: "",

        }
    },

    methods: {
        getAllMedications: function () {
            var medication = []

            medication.forEach(element => this.allMedication.push(element.name + " " + element.dosage));

            // TODO(Jovan): Use envvar?
            this.axios.get("http://localhost:56764/api/medication/all")
               .then(response => {
                   var medication = response.data;
                   medication.forEach(element => this.allMedication.push(element.med + " " + element.dosage));
                   console.log(response.data);
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        createRequest: function () {
            let name = this.requiredMedication.split(" ")[0];
            let dosage = this.requiredMedication.split(" ")[1];
            let urgentProcurement = { medicationName: name, medicationDosage: dosage, medicationQuantity: this.medicationQuantity };
            this.axios.post("http://localhost:50202/api/Procurement/", urgentProcurement)
                .then(response => {
                    console.log(response.data);
                    this.$toast.success("Urgent request successfully created!");
                    this.notify();
                    this.$router.push("/dean/urgentOrder");
                })
                .catch(response => {
                    this.$toast.error("Urgent request creation failed!");
                    console.log(response);
                });
        },
        addNewMedication: function () {
            // TODO(Jovan): Add choice for med category
            let newMed = { med: this.medName, dosage: this.medDosage, medicationCategoryId: 1 };
            this.axios.post("http://localhost:56764/api/medication", newMed)
                .then(response => {
                    console.log(response.data);
                    this.show = true;
                    this.getAllMedications();
                    this.$toast.success("New medication successfully added!");
                })
                .catch(response => {
                    this.$toast.error("Adding new medication failed!");
                    console.log(response);
                });
        },

        notify: function() {
            this.axios.get("http://localhost:56764/api/Procurement/notify")
                .then(response => {
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response.data);
                })

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

    #urg-request-btn {
        margin: 0;
        margin-top: -6%;
    }

    .bounce-enter-active {
        animation: bounce-in .5s;
    }

    @keyframes bounce-in {
        0% {
            transform: scale(0);
        }

        50% {
            transform: scale(1.5);
        }

        100% {
            transform: scale(1);
        }
    }
</style>