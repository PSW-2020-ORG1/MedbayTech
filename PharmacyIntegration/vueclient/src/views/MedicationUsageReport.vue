<template>
    <div id="main-div">
        <div id="calendar">
            <v-date-picker
                v-model="dateRange"
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
                dateRange: "",
				headers: [
					{ text: "Id", value: "id", },
					{ text: "Remove" },
                ],
                reports: [
                    { id: "1" }
                ],
            }
        },

        methods: {
            generate: function () {

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
