<template>
    <div id="main-div">
        <main-navigation></main-navigation>
        <div id="header">
            <h1>Generating medication usage report</h1>
        </div>
        <div class="content">
            <v-form id="generateReport" v-model="valid">
                <v-card-text>Start date</v-card-text> 
                <input type="date" v-model="startDate" />
                <v-card-text>End date</v-card-text>
                <input type="date" v-model="endDate" />
                <v-btn elevation="2" @click="generate" class="deep-orange white--text">
                    Generate
                </v-btn>
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

</script>

<style scoped>

</style>
