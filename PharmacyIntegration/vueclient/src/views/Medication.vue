
<template>
    <div id="win">
        <div id="msg-table">
            <v-text-field v-model="search"
                            label="Check for medication"
                            hide-details />
            <v-btn class="blue white--text" elevation="0" v-on:click="checkForMedication(search)">Check</v-btn>
        </div>
        <div v-if="status !== '' ">
            <h1>Response: {{status}} </h1>
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
            this.axios.get("http://localhost:50202/api/MedicationCheck/" + this.search)
                .then(response => {
                    console.log(this.newMessage)
                    this.newMessage = response.data;
                    this.messages.push(this.newMessage)
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
    },

}
</script>

<style scoped>
    #win {
        height: 100%;
    }
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

    #msg-table {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        max-width: 70%;
        margin: 0 auto;
    }

    .buttons {
        margin-left: auto;
        margin-right: auto;
        margin: 4px;
        padding: 3px;
        float: none;
        border: 1px solid transparent;
        background-color: #ff6a00;
        color: #fff;
        border-radius: 5px;
        box-shadow: 0 4px 8px 0 rgba(0,0,0, 0.38);
    }
    .buttons:hover {
        border: 1px solid #ff6a00;
        background-color: #fff;
        color: #ff6a00;
    }
   
</style>