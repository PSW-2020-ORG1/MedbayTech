<template>
    <div id="mur-main">
        <v-card id="medications" :loading="loadingMedicationUsages ? 'accent' : 'null'">
            <v-card-title class="primary secondary--text">Medication usages</v-card-title>
            <v-card-text>
                <div id="medication-usage-table">
                    <v-data-table :headers="headers_consumption"
                                :items="medicationUsages">
                        <template v-slot:item="row">
                            <tr>
                                <td>{{row.item.medication.med}}</td>
                                <td>{{row.item.usage}}</td>
                                <td>{{row.item.date}}</td>
                            </tr>
                        </template>
                    </v-data-table>
                </div>
            </v-card-text>
        </v-card>

        <v-card id="reports" :loading="loadingUsageReports ? 'accent' : 'null'">
            <v-card-title class="primary secondary--text">Medication usage reports</v-card-title>
            <v-card-text id="reports-content">
                <div id="calendar">
                    <v-date-picker v-model="dateRange"
                                range>
                    </v-date-picker>
                    <v-btn color="accent" @click="generateReport" :disabled="!dateRange[0] || !dateRange[1]">Generate</v-btn>
                </div>
                <v-data-table :headers="headers"
                                :items="reports">
                    <template v-slot:item="row">
                        <tr>
                            <td>{{row.item.id}}</td>
                            <td>{{row.item.from}}</td>
                            <td>{{row.item.until}}</td>
                            <td>
                                <v-btn elevation="0" class="white red--text" @click="deleteReport">
                                    <i class="fa fa-trash" aria-hidden="true"></i>
                                </v-btn>
                            </td>
                        </tr>
                    </template>
                </v-data-table>
            </v-card-text>
        </v-card>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                headers_consumption: [
                    { text: "Medication" },
                    { text: "Consumption" },
                    { text: "Date" },
                ],
                dateRange: "",
                headers: [
                    { text: "Id", value: "id", },
                    { text: "From" },
                    { text: "Until" },
					{ text: "Remove" },
                ],
                reports: [
                ],
                medicationUsages: [],
                medications: [],
                selectedReport: "",
                loadingMedicationUsages: false,
                loadingUsageReports: false,
            }
        },

        methods: {
            generateReport: function () {
                // NOTE(Jovan): Sanity check
                this.loadingUsageReports = true;
                if (!this.dateRange[0] || !this.dateRange[1]) return;
                let period = {
                    startTime: this.dateRange[0],
                    endTime: this.dateRange[1],
                };
                this.axios.post("http://localhost:50202/api/MedicationUsageReport", period)
                    .then(response => {
                        this.reports.push(response.data);
                        console.log(response.data);
                    })
                    .catch(response => {
                        console.log(response.data);
                    })
                    .finally(function() {
                        this.loadingUsageReports = false;
                    });
            },

            getAllMedicationUsages: function () {
                this.loadingMedicationUsages = true;
                this.axios.get("http://localhost:50202/api/MedicationUsage")
                    .then(response => {
                        console.log(response.data);
                        this.medicationUsages = response.data;
                    })
                    .catch(response => {
                        console.log(response.data);
                    })
                    .finally(function() {
                        this.loadingMedicationUsages = false;
                    })
            },

            getAllMedications: function () {
                this.axios.get("http://localhost:50202/api/Medication")
                    .then(response => {
                        console.log(response.data)
                        this.medications = response.data;
                    })
                    .catch(response => {
                        console.log(response.data);
                    });
            },

            getNameById: function () {
                this.medicationUsages.forEach(mu => {
                    mu.medication = this.medications.forEach(m => {
                        if (m.id == mu.medicationId)
                            return m;
                    });

                });

            },
        },

        mounted() {
            this.getAllMedicationUsages();
            this.getAllMedications();
        },
    }
</script>

<style scoped>
    #mur-main {
        display: grid;
        grid-template-columns: auto;
        place-items: center;
        min-height: 100%;
    }
    
    #calendar {
        display: flex;
        flex-direction: column;
    }

    #reports-content {
        display: grid;
        grid-template-columns: auto 1fr;
        padding-left: 0;
    }
</style>
