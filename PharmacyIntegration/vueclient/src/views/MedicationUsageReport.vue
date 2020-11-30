<template>
    <div id="main-div">
        <v-card id="medications">
            <div id="medication-usage-table" class="usage-card">
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
        </v-card>
        <br/>
        <v-card id="reports" class="usage-card">
            <v-data-table :headers="headers"
                            :items="reports">
                <template v-slot:item="row">
                    <tr>
                        <td>{{row.item.id}}</td>
                        <td>{{row.item.from}}</td>
                        <td>{{row.item.until}}</td>
                        <td>
                            <v-btn class="white black--text" @click="selectedReport = row.item">Show</v-btn>
                        </td>
                        <td>
                            <v-btn elevation="0" class="white red--text" @click="deleteReport">
                                <i class="fa fa-trash" aria-hidden="true"></i>
                            </v-btn>
                        </td>
                    </tr>
                </template>
            </v-data-table>
        </v-card>
        <br/>
        <v-card id="calendar" class="usage-card">
            <v-date-picker v-model="dateRange"
                            range>
            </v-date-picker>
            <v-btn color="accent" @click="generateReport" :disabled="!dateRange[0] || !dateRange[1]">Generate</v-btn>
        </v-card>
        <v-card>
            <v-card-title>Usage report</v-card-title>
            <v-card-subtitle>Report from: {{selectedReport.from}} - {{selectedReport.until}}</v-card-subtitle>
            <v-card-text>
            <b v-if="!selectedReport">None selected</b>
            <ul v-else>
                <li v-for="report in selectedReport.usages" :key="report.usage">{{report.usage.medicationId}} {{report.usage.date}}</li>
            </ul>
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
            }
        },

        methods: {
            generateReport: function () {
                // NOTE(Jovan): Sanity check
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
                    });
            },

            getAllMedicationUsages: function () {
                this.axios.get("http://localhost:50202/api/MedicationUsage")
                    .then(response => {
                        console.log(response.data);
                        this.medicationUsages = response.data;
                    })
                    .catch(response => {
                        console.log(response.data);
                    });
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
    #main-div {
        display: flex;
        justify-content: space-around;
        flex-direction: row;
        flex-wrap: wrap;
    }
    .usage-card:nth-child(2n) {
        flex-basis: 100%;
    }
    #calendar {
        display: flex;
        flex-direction: column;
    }
</style>
