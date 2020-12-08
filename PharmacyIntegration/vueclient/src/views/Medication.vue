
<template>
    <div>
        <div id="search">
            <v-row>
                    <v-text-field id="type-search" v-model="search"
                                    :append-outer-icon="'mdi-send'"
                                    label="Check for medication"
                                    filled
                                    clearable
                                    @click:append-outer="checkForMedication(search)"
                                    @keyup.enter="checkForMedication(search)">
                    </v-text-field>
            </v-row>
        </div>
        <div v-if="status !== '' ">
            <h6>Response: {{status}} </h6>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            search: "",
            status: ""
        }
    },

    methods: {
        checkForMedication: function () {
            this.axios.get("http://localhost:50202/api/Medication/check/" + this.search)
                .then(response => {
                    this.status = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
    },
    watch: {
        search: function () {
            this.status = '';
        }
    }

}
</script>

<style scoped>
    h6 {
        font-size: 2rem;
        text-align: center;
        color: #3e3e3e;
        max-width: 100%;
    }
    #search {
        max-width:50%;
        margin: 0 auto;
    }
</style>