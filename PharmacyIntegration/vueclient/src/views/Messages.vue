
<template>
    <div id="win">
        <div id="msg-table">
            <v-btn icon color=accent elevation="0" @click="getNewMessage"><i class="fa fa-refresh"></i></v-btn>
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
                            <v-btn elevation="0" class="red white--text" v-on:click="deleteMessage(row.item)">
                            <i class="fa fa-trash" aria-hidden="true"></i>
                            </v-btn>
                        </td>
                        <td>{{row.item.pharmacyId}}</td>
                    </tr>
                </template>
            </v-data-table>
        </div>

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
            messages: [{id:"1", content: "Test message", approved:false}],
            newMessage: "",
            status: "",
            search: [],
        }
    },

    methods: {
        getNewMessage: function () {
            this.axios.get("http://localhost:50202/api/PharmacyNotification/id")
                .then(response => {
                    console.log(this.newMessage)
                    this.newMessage = response.data;
                    this.messages.push(this.newMessage)
                })
                .catch(response => {
                    console.log(response.data);
                })
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