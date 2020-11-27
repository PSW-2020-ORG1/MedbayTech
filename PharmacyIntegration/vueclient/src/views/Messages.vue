
<template>
    <div>
        <main-navigation></main-navigation>
        <div id="header">
            <h1>Messages</h1>
        </div>
        <div class="container">
            <button id="get-message-button" v-on:click="getMessage()">Get new message:</button>
            <div v-if="messages.length > 0">
                <ul>
                    <li v-for="msg of messages" :key="msg.id">
                        {{msg.content}}
                        <!--
                        <button v-if="msg.Approve === true" id="approve-button" v-on:click="changeMessageStatus()" title="Make visible for everyone">Approve</button>
                        <button v-else id="approve-button" v-on:click="changeMessageStatus()" title="Hidde for everyone">Disapprove</button>
                        -->
                    </li>
                </ul>
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
        }
    },

    methods: {
        getMessage: function () {
            this.axios.get("http://localhost:50202/api/pharmacyNotification")
                .then(response => {
                    console.log(response.data);
                    this.newMessage = JSON.parse(response.data.value);
                    this.messages.push(this.newMessage)
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        changeMessageStatus: function () {

        }
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

    #get-message-button, #approve-button {
        margin: 4px;
        padding: 3px;
        float: none;
        border: 0px;
        background-color: #ff6a00;
        color: #fff;
        border-radius: 5px;
        box-shadow: 0 4px 8px 0 rgba(0,0,0, 0.38);
    }
        #get-message-button:hover {
            border: 1px solid #ff6a00;
            background-color: #fff;
            color: #ff6a00;
        }

</style>