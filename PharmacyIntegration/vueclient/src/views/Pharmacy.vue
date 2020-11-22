<template>
    <div id="ph-main">
        <v-card elevation="2">
            <v-card-title><v-progress-circular v-if ="!pharmacy.id"></v-progress-circular>{{pharmacy.id}}</v-card-title>
            <v-card-text>Greetings from <v-progress-circular v-if="!pharmacy.id"></v-progress-circular>{{pharmacy.id}} to <v-progress-circular v-if="!dummyData"></v-progress-circular>{{dummyData}}</v-card-text>
        </v-card>
    </div>
</template>

<script>
export default {
    data() {
        return {
            pharmacy: "",
            dummyData: "",
        }
    },

    methods: {
        getPharmacy: function() {
            this.axios.get("http://localhost:50202/api/Pharmacy/" + this.$route.params.id)
                .then(response => {
                    console.log(response.data);
                    this.pharmacy = response.data;
                    this.getDummy();
                })
                .catch(response => {
                    console.log(response.data);
                })
        },

        getDummy: function () {
            this.axios.get(this.pharmacy.apiEndpoint + this.pharmacy.apiKey)
                .then(response => {
                    this.dummyData = response.data;
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response);
                });
        }
    },

        mounted() {
            this.getPharmacy();
    },
}
</script>

<style scoped>
    #ph-main {
        width: 40vw;
        margin: 0 auto;
        margin-top: 10vh;
    }
</style>