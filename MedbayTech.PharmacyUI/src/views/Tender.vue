<template>
    <div id="tender-main">
        <v-card id="tender-table">
            <v-card-title id="tender-title" class="primary secondary--text">
                Tender: {{tender.id}}
                <router-link to="/dean/tenders" v-slot="{href, navigate}">
						<v-btn :href="href" class="deep-orange white--text" dark @click="navigate">
                    <v-icon left>
                        mdi-arrow-left-bold
                    </v-icon>
                       Back
                   </v-btn>
				</router-link>
                
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
                              <v-chip
                                    :color="getColor(row.item.tenderOfferPrice)"
                                    dark
                                    >
                                        {{row.item.tenderOfferPrice}}$
                                </v-chip>
                            </td>
                            <td ><v-btn v-if="row.item.id === tender.winnerTenderOfferId" class="white green--text"  elevation="0" >Winner</v-btn>
                            <v-btn v-else class="white green--text" :disabled="tender.tenderStatus !== 1" elevation="0" v-on:click="declareWinner(row.item.id)">Accept</v-btn></td>
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
				{ text: "Accept", align: 'center' },
            ],
            tender: "",
            medications: [],
            tenderOffers: [],
            minPrice: "",
            maxPrice: "",
        }
    },

    methods: {
        getTender: function(){
           this.axios.get("http://localhost:49835/api/Tender/" + this.$route.params.id)
                .then(response => {
                    this.tender = response.data;
                    if(this.tender.tenderStatus == 1){
                        this.$toast.info("Dont forget to declare winner!");
                    }
                })
                .catch(response => {
                    console.log(response.data);
                })
        },

        getColor: function(price){
            if(price === this.minPrice)
                return 'green';
            else if(price === this.maxPrice)
                return 'red';
            else
                return 'orange';
        },

        getTenderMedication: function () {
            this.axios.get("http://localhost:49835/api/Tender/med/" + this.$route.params.id)
                .then(response => {
                    this.medications = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
        },

        getTenderOffers: function () {
            this.axios.get("http://localhost:49835/api/tenderOffer/tender/" + this.$route.params.id)
                .then(response => {
                    this.tenderOffers = response.data;
                    this.minMaxPrice();
                })
                .catch(response => {
                    console.log(response.data);
                })
        },

        minMaxPrice: function() {
            this.minPrice = this.tenderOffers[0].tenderOfferPrice;
            this.maxPrice = this.tenderOffers[0].tenderOfferPrice;
            for (let i = 0; i < this.tenderOffers.length; ++i) {
                if(this.tenderOffers[i].tenderOfferPrice < this.minPrice){
                    this.minPrice = this.tenderOffers[i].tenderOfferPrice;
                }
                if(this.tenderOffers[i].tenderOfferPrice > this.maxPrice){
                    this.maxPrice = this.tenderOffers[i].tenderOfferPrice;
                }
            }
        },

        declareWinner: function(tenderOfferId){
            this.tender.winnerTenderOfferId = tenderOfferId;
            this.tender.tenderStatus = 2;
            this.axios.post("http://localhost:49835/api/Tender/winner", this.tender)
                .then(response => {
                    console.log(response.data);
                    for (let i = 0; i < this.tender.tenderMedications.length; ++i){
                        this.updateMedication(this.tender.tenderMedications[i].medicationId, this.tender.tenderMedications[i].tenderMedicationQuantity)
                    }
                    this.getTender();
                    this.getTenderOffers();
                    this.$toast.success("Winner successfully declared!");
                })
                .catch(response => {
                    console.log(response.data);
                })
        },

        updateMedication: function (id, qu) {
            let med = "";
            // TODO(Jovan): Use envvar?
            this.axios.get("http://localhost:56764/api/medication/" + id)
                .then(response => {
                    med = response.data;
                    med.quantity = med.quantity + qu;
                    this.axios.post("http://localhost:56764/api/medication", med)
                        .then(response => {
                            console.log(response.data);
                        })
                        .catch(response => {
                            console.log(response.data);
                        })
                })
                .catch(response => {
                    console.log(response.data);
                })
        },
    

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