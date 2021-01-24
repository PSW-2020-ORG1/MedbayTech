<template>
    <div id="ph-main">
        <v-card id="files-table" elevation="2">
            <v-card-title class="primary secondary--text">Pharmacy files</v-card-title>
            <v-card-text>
                <v-data-table :headers="filesHeaders"
                              :items="files">
                    <template v-slot:item="row">
                        <tr>
                            <td>{{row.item}}</td>
                            <td>
                                <v-btn class="white accent--text" elevation="0" @click="sendFile(row.item)">
                                    Send file
                                </v-btn>
                            </td>
                        </tr>
                    </template>
                </v-data-table>
            </v-card-text>
        </v-card>
        <v-card id="drugs-table" elevation="2">
            <v-card-title class="primary secondary--text">Available drugs</v-card-title>
            <v-card-text>
                <v-text-field v-model="search"
                              label="Search drugs"
                              hide-details />
                <v-data-table :headers="drugHeaders"
                              :items="drugs"
                              :search="search">
                    <template v-slot:item="row">
                        <tr>
                            <td>{{row.item.name}}</td>
                            <td>
                                <v-btn class="white accent--text" elevation="0" @click="getSpecification(row.item)">
                                    Specification
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
            search: [],
            pharmacy: "",
            dummyData: "",
            files: [],
			filesHeaders: [
                { text: "File"},
                { text: "Send file" },
            ],
            drugHeaders: [
                { text: "Name", value: "name" },
            ],
            drugs: [],
        }
    },

    methods: {

        getSpecification: function(drug) {
            if (!this.pharmacy) return;
            this.axios.get(this.pharmacy.apiEndpoint + "drugs/" + drug.id)
                .then(response => {
                    let drug = response.data;
                    console.log(drug);
                    this.axios.post("http://localhost:50202/api/drugspecification", drug)
                        .then(response => {
                            console.log(response);
                        })
                        .then(response => {
                            console.log(response);
                        });
                })
                .catch(response => {
                    console.log(response.data);
                })
                .finally(() => {
                    console.log("Finally");
                }); 
        },

        getDrugs: function() {
            if (!this.pharmacy) return;
            this.axios.get(this.pharmacy.apiEndpoint + "drugs")
                .then(response => {
                    this.drugs = response.data;
                    console.log(response);
                })
                .catch(response => {
                    console.log(response);
                });
        },

        sendFile: function(filename) {
            let notification = {
                endpoint: "",
                message: "",
                filename: filename
            };
            this.axios.post("http://localhost:50202/api/reportnotification", notification)
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
                    this.getDrugs();
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