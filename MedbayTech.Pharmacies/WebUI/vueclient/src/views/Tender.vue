<template>
    <div id="tender-main">
        <v-card id="tender-table" :loading="loadingMessages ? 'accent' : 'null'">
            <v-card-title id="tender-title" class="primary secondary--text">
                Tender: {{tender.id}}
                <v-btn icon color=accent elevation="0" @click="getNewMessage"><i class="fa fa-refresh"></i></v-btn>
            </v-card-title>
            <v-card-text>
                 <v-data-table :items="medications"
                                :hide-default-footer="true"
                                :hide-default-header="true">
                    <template v-slot:item="row">
                        <tr>
                            <td>{{row.item.medicationName}}</td>
                            <td>{{row.item.medicationDosage}}</td>
                            <td>x{{row.item.medicationQuantity}}</td>
                        </tr>
                    </template>
                </v-data-table>

                <v-data-table :headers="headers"
                                :items="tenderOffers">
                    <template v-slot:item="row">
                        <tr>
                            <td>{{row.item.pharmacy}}</td>
                            <td>{{row.item.pharmacyEMail}}</td>
                            <td>
                                <div v-for="offer in totalOffers" :key="offer.id">
                                    <div v-if="row.item.id == offer.id">
                                        {{offer.value}}$
                                    </div>
                                </div>

                                
                            </td>
                            <td ><v-btn class="white green--text" elevation="0" v-on:click="changeMessageStatus(row.item)">Accept</v-btn></td>
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
				{ text: "Pharmacy"}, 
				{ text: "Email"},
				{ text: "Offer" },
				{ text: "Accept" },
            ],
            tender: "",
            medications: [],
            tenderOffers: [],
            totalOffers: [],
        }
    },

    methods: {
        getTender: function(){
           this.axios.get("http://localhost:50202/api/Tender/" + this.$route.params.id)
                .then(response => {
                    this.tender = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        getColor: function(price){
            if(price < 150)
                return 'green';
            return 'red';
        },
        getTenderMedication: function () {
            this.axios.get("http://localhost:50202/api/Tender/med/" + this.$route.params.id)
                .then(response => {
                    this.medications = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        getTenderOffers: function () {
            this.axios.get("http://localhost:50202/api/tenderOffer/tender/" + this.$route.params.id)
                .then(response => {
                    this.tenderOffers = response.data;
                    this.getTotalPrice();
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
        getTotalPrice: function () {
            //this.tenderOffers.forEach(function (element) {
            for (let index = 0; index < this.tenderOffers.length; ++index) {
                this.axios.get("http://localhost:50202/api/TenderOffer/total/" + this.tenderOffers[index].id)
                    .then(response => {
                        console.log(this.tenderOffers[index].id);
                        this.totalOffers.push({ id: this.tenderOffers[index].id, value: response.data })
                    })
                    .catch(response => {
                        console.log(response.data);

                    })
            }
            console.log(this.totalOffers);
            console.log(this.tenderOffers);
        }


    },
    mounted() {
        this.getTender();
        this.getTenderMedication();
        this.getTenderOffers();
    },
}
</script>

<style scoped>
     #tender-main {
        display: grid;
        place-items: center;
        height: 100%;
    }

    #mtendersg-table {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
    }

    #tender-title {
        display: grid;
        grid-template-columns: 1fr auto;
    }
</style>