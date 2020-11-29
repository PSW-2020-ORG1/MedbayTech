<template>
    <div id="main-div">
        <main-navigation id="nav"></main-navigation>
        <div id="content">
            <v-form id="generateReport" v-model="valid">
            <v-card>
                <v-title>Generating medication usage report</v-title>
                    <v-text-field
                                  label="Start date"
                                  persistent-hint
                                  prepend-icon="mdi-calendar"
                                  v-bind="attrs"
                                  @blur="date = parseDate(dateFormatted)"
                                  v-on="on">

                    </v-text-field>
                    <v-date-picker v-model="startDate"
                               no-title
                               @input="menu1 = false">
                    </v-date-picker>
                    <v-text-field
                                  label="End date"
                                  persistent-hint
                                  prepend-icon="mdi-calendar"
                                  v-bind="attrs"
                                  @blur="date = parseDate(dateFormatted)"
                                  v-on="on">

                    </v-text-field>
                    <v-date-picker v-model="endDate"
                               no-title
                               @input="menu2 = false">
                    </v-date-picker>
                    <v-btn elevation="2" @click="generate" class="deep-orange white--text">
                        Generate
                    </v-btn>
            </v-card>
            </v-form>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                startDate: [],
                endDate: [],
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

</style>
