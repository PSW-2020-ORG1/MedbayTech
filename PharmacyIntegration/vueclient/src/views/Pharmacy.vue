<template>
    <div id="ph-main">
        <v-card elevation="2">
            <v-card-title><v-progress-circular v-if ="!pharmacy.id"></v-progress-circular>{{pharmacy.id}}</v-card-title>
            <v-card-text>Greetings from <v-progress-circular v-if="!pharmacy.id"></v-progress-circular>{{pharmacy.id}} to <v-progress-circular v-if="!dummyData"></v-progress-circular>{{dummyData}}</v-card-text>
        </v-card>
        <v-card id="files-table">
            <v-data-table :headers="headers"
                            :items="files">
                <template v-slot:item="row">
                    <tr>
                        <td>{{row.item}}</td>
                        <td>
                            <v-btn class="white black--text" elevation="0" @click="sendFile(row.item)">
                                Send file
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
            pharmacy: "",
            dummyData: "",
            files: [],
			headers: [
                { text: "File" },
                { text: "Send file" },
            ],
        }
    },

    methods: {

        sendFile: function(filename) {
            let file = {
                filename: filename,
                url: this.pharmacy.apiEndpoint.replace("pswapi", "pswupload"),
            };
            this.axios.post("http://localhost:50202/api/httpfilesharing", file)
                .then(response => {
                    console.log(response);
                })
                .catch(response => {
                    console.log(response);
                });
        },

        getFiles: function () {
            this.axios.get("http://localhost:50202/api/httpfilesharing")
                .then(response => {
                    this.files = response.data;
                    console.log(response);
                })
                .catch(response => {
                    console.log(response);
                });
        },

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
            this.getFiles();
    },
}
</script>

<style scoped>
    #ph-main {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        width: 40vw;
        margin: 0 auto;
        margin-top: 10vh;
    }
</style>