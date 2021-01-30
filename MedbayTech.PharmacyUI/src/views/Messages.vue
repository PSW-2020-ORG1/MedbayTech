
<template>
    <div id="msg-main">
        <v-card id="msg-table" :loading="loadingMessages ? 'accent' : 'null'">
            <v-card-title id="msg-title" class="primary secondary--text">
                Pharmacy messages
                <v-btn icon color=accent elevation="0" @click="getNewMessage"><i class="fa fa-refresh"></i></v-btn>
            </v-card-title>
            <v-card-text>
                <v-text-field v-model="search"
                                label="Search messages"
                                hide-details />
                <v-data-table :headers="headers"
                                :items="messages"
                                :search="search">
                    <template v-slot:item="row">
                        <tr>
                            <td>{{row.item.content}}</td>
                            <td v-if="row.item.approved"><v-btn class="white red--text" elevation="0" v-on:click="changeMessageStatus(row.item)">Disapprove</v-btn></td>
                            <td v-else><v-btn class="white green--text" elevation="0" v-on:click="changeMessageStatus(row.item)">Approve</v-btn></td>
                            <td>
                                <v-btn elevation="0" class="white red--text" v-on:click="deleteMessage(row.item)">
                                <i class="fa fa-trash" aria-hidden="true"></i>
                                </v-btn>
                            </td>
                            <td>{{row.item.pharmacyId}}</td>
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
            headers: [
					{ text: "Message"},
					{ text: "Change status" },
					{ text: "Delete" },
					{ text: "Pharmacy", value: "pharmacyId" },
				],
            messages: [],
            newMessage: "",
            status: "",
            search: [],
            loadingMessages: false,
        }
    },

    methods: {
        getNewMessage: function () {
            this.loadingMessages = true;
            this.axios.get("http://localhost:50202/api/PharmacyNotification/id")
                .then(response => {
                    console.log(this.newMessage)
                    this.newMessage = response.data;
                    this.messages.push(this.newMessage)
                })
                .catch(response => {
                    console.log(response.data);
                })
                .finally(function(){
                    this.loadingMessages = false;
                });
        },
        getAllMessages: function () {
            this.axios.get("http://localhost:50202/api/pharmacyNotification")
                .then(response => {
                    console.log(response.data);
                    this.messages = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        changeMessageStatus: function (msg) {
            msg.approved = !msg.approved;
            this.axios.post("http://localhost:50202/api/pharmacyNotification/", msg)
                .then(response => {
                    this.status = "Changed!";
                    this.getAllMessages();
                    console.log(response);
                })
                .catch(response => {
                    this.status = "Failed!";
                    console.log(response);
                });
        },
        deleteMessage: function (msg) {
            this.status = "";
            this.axios.delete("http://localhost:50202/api/PharmacyNotification?id=" + msg.id)
                .then(response => {
                    this.status = "Deleted";
                    this.getAllMessages();
                    console.log(response);
                })
                .catch(response => {
                    this.status = "Failed deletion";
                    console.log(response);
                });
        }
    },
        mounted() {
            this.getAllMessages();
    }
}
</script>

<style scoped>
    #msg-main {
        display: grid;
        place-items: center;
        height: 100%;
    }

    #msg-table {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
    }

    #msg-title {
        display: grid;
        grid-template-columns: 1fr auto;
    }
   
</style>