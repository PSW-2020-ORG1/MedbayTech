
<template>
    <div>
        <main-navigation></main-navigation>
        <div id="header">
            <h1>All Messages:</h1>
        </div>
        <div class="container">
            <ul>
                <li>
                    {{messages[0].Text}}
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            messages: []
        }
    },

    methods: {
        getMessages: function() {
            this.axios.get("http://localhost:50202/api/message")
                .then(response => {
                    console.log(response.data);
                    this.messages = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
        }
    },

        mounted() {
            this.getMessages();
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