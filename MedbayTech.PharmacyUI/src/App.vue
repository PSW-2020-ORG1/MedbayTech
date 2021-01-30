<template>
    <v-app>
        <router-view></router-view>
    </v-app>
</template>

<script>
    export default {
        name: 'App'
    };
</script>

<style>
    html {
    }

    body {
        font-family: Poppins, sans-serif; /* 1 */
        margin: 0;
        padding: 0;
        min-height: 100vh;
    }
    .v-application {
        font-family: Poppins, sans-serif !important;
    }
    
    .v-application > .title {
    font-family: Poppins, sans-serif !important;
    }
</style>
