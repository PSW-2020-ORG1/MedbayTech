﻿<template>
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
                if (!this.dateRange[0] || !this.dateRange[1]) return;
                let period = {
                    startTime: this.dateRange[0],
                    endTime: this.dateRange[1],
                };
                // TODO(Jovan): Use envvar?
                this.axios.post("http://localhost:56764/api/medicationusagereport", period)
                    .then(response => {
                        this.getAllReports();
                        console.log(response.data);
                    })
                    .catch(response => {
                        console.log(response.data);
                    });
            },

            getAllMedicationUsages: function () {
                this.loadingMedicationUsages = true;
                // TODO(Jovan): Use envvar?
                this.axios.get("http://localhost:56764/api/medicationusage")
                    .then(response => {
                        console.log(response.data);
                        this.medicationUsages = response.data;
                        this.loadingMedicationUsages = false;
                    })
                    .catch(response => {
                        console.log(response.data);
                        this.loadingMedicationUsages = false;
                    });
            },

            getAllMedications: function () {
                //this.axios.get("http://localhost:50202/api/Medication")
                // TODO(Jovan): Use envvar?
                this.axios.get("http://localhost:56764/api/medication/all")
                    .then(response => {
                        console.log(response.data)
                        this.medications = response.data;
                        this.medicationUsages.forEach(mu => {
                            console.log(mu);
                            let med = this.medications.find(m => m.id == mu.medicationId);
                            mu.medication = med;
                        });
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

            getAllReports: function() {
                this.loadingUsageReports = true;
                this.axios.get("http://localhost:56764/api/medicationusagereport")
                    .then(response => {
                        console.log(response);
                        this.reports = response.data;
                        this.loadingUsageReports = false;
                    })
            },
        },

        mounted() {
            this.getAllMedicationUsages();
            this.getAllReports();
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
