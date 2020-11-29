<template>
    <div id="main-div">
        <v-card id="medications">
            <div id="medication-usage-table">
                <v-data-table :headers="headers_consumption"
                              :items="medications">
                    <template v-slot:item="row">
                        <tr>
                            <td>{{row.item.usage}}</td>
                            <td>{{row.item}}</td>
                        </tr>
                    </template>
                </v-data-table>
            </div>
        </v-card>
        <br/>
        <div id="calendar">
            <v-date-picker v-model="dateRange"
                            range
                            :min="(new Date).toISOString().slice(0, 10)">
            </v-date-picker>
        </div>
        <v-card id="reports">
            <v-data-table :headers="headers"
                            :items="reports">
                <template v-slot:item="row">
                    <tr>
                        <td>{{row.item.id}}</td>
                        <td>
                            <v-btn elevation="0" class="red white--text">
                                <i class="fa fa-trash" aria-hidden="true"></i>
                            </v-btn>
                        </td>
                    </tr>
                </template>
            </v-data-table>
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
                ],
                dateRange: "",
                headers: [
					{ text: "Id", value: "id", },
					{ text: "Remove" },
                ],
                reports: [
                    { id: "1" }
                ],
                medications: [],
            }
        },

        methods: {
            generate: function () {

            },
            getAllMedications: function () {
                this.axios.get("http://localhost:50202/api/MedicationUsage")
                    .then(response => {
                        console.log(response.data);
                        this.medications = response.data;
                    })
                    .catch(response => {
                        console.log(response.data);
                    })
            },
        },

        mounted() {

        },
    }

</script>

<style scoped>
    #main-div {
        display: flex;
        flex-direction: row;
    }
</style>
