
<template>
    <div id="win">
        <main-navigation id="nav"></main-navigation>
        <div id="header">
            <h1>Messages:</h1>
        </div>
        <div class="container">
            <div v-if="messages.length > 0">
                <table>
                    <tr v-for="msg of messages" :key="msg.id">
                        <td>{{msg.content}}</td>
                        <td>
                            <button v-if="msg.approved === false" class="buttons" v-on:click="changeMessageStatus(msg)" title="Make visible for everyone">Approve</button>
                            <button v-else class="buttons" v-on:click="changeMessageStatus(msg)" title="Hidde for everyone">Disapprove</button>
                        </td>
                        <td><button class="buttons" v-on:click="deleteMessage(msg)" title="Delete this notification">Delete</button></td>
                    </tr>
                </table>
            </div>
            <div style="width:100%;text-align:center;">
                <button class="buttons" v-on:click="getNewMessage()">Get new message</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            messages: [],
            newMessage: "",
            status: ""
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
            if (msg.approved === false) {
                msg.approved = true;
            } else {
                msg.approved = false;
            }
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
    #nav {
        z-index: 5;
    }
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

    .content {
        display: flex;
        flex-direction: row;
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
    table {
        margin-left: auto;
        margin-right: auto;
        margin-bottom: -15px;
        border: 1px solid rgb(0, 0, 0);
        border-radius: 5px;
        padding: 10px;
        padding-bottom: 20px;
        box-shadow: 0 4px 8px 0 rgba(0,0,0, 0.38);
        
    }
    td {
        text-align:center;
    }
   
</style>