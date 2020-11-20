<template>
    <div id="ph-main">
        <main-navigation></main-navigation>
        <div id="header">
            <h1>{{pharmacy.id}}</h1>
        </div>
        <div class="container">
            {{dummyData}}
        </div>
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
                    console.log(response.data);
                });
        }
    },

        mounted() {
            this.getPharmacy();
    },
}
</script>

<style scoped>
    h1 {
        font-size: 3rem;
        text-align: center;
        color: #3e3e3e;
    }

    #header {
        margin-top: 10vh;
        width: 100%;
        height: 30vh;
    }

    .content {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        max-width: 70%;
        margin: 0 auto;
    }
</style>