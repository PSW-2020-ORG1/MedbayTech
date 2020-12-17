<template>
    <div id="dean-main">
        <sidebar title="Dean panel" user="">
            <li><router-link to="/dean/">Messages</router-link></li>
            <li><router-link to="/dean/pharmacies">Pharmacies</router-link></li> <!-- TODO(Jovan): Add /:id -->
            <li><router-link to="/dean/medication_usage_report">Medication usage report</router-link></li>
            <li><router-link to="/dean/medication">Medication</router-link></li>
        </sidebar>
        <div id="main-content">
            <router-view />
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                title: "Dean panel",
            }
        }
    }
</script>

<style scoped>
    #dean-main {
        display: grid;
        grid-template-columns: minmax(150px, 15vw) 1fr;
    }

    #main-content {
        min-height: 100vh;
        background-color: #fafafa;
    }
</style>