
<template>
    <div id="active-tenders-main">
       <transition name="bounce">
            <v-card v-if="show" elevation="1">
                <v-card-title id="active-tenders-content" class="primary secondary--text">
                    Active Tenders
                    <a href="http://localhost:50202/api/rss">
                    <v-btn class="deep-orange white--text" dark >
                        <v-icon left>
                            mdi-rss
                        </v-icon>
                       Get RSS Link
                   </v-btn>
                   </a>
                </v-card-title>
                <v-card-text id="active-tenders-card">
                    <div id="active-tenders-table">
                        <v-text-field v-model="search"
                                        label="Search tenders"
                                        hide-details />
                        <v-data-table :headers="tendersHeaders"
                                        :items="tenders"
                                        :search="search">
                            <template v-slot:item="row">
                                <tr >
                                    <td>Tender:{{row.item.id}}</td>
                                    <td>{{row.item.startDate.substring(0, 10)}}</td>
                                    <td>{{row.item.endDate.substring(0, 10)}}</td>
                                    <td>{{row.item.tenderDescription}}</td>
                                    <td><v-btn class="deep-orange white--text" @click="showOfferForm(row.item)">
                                        Offer
                                        </v-btn>
                                    </td>
                                </tr>
                            </template>
                        </v-data-table>
                    </div>
                </v-card-text>
            </v-card>
        </transition>
        <transition  name="bounce">
             <v-card v-if="!show" id="active-tenders-table" :loading="loadingMessages ? 'accent' : 'null'">
                <v-card-title id="active-tenders-content" class="primary secondary--text">
                    Tender: {{tenderDetails.id}}
                    <v-btn class="deep-orange white--text" dark @click="show = !show">
                        <v-icon left>
                            mdi-arrow-left-bold
                        </v-icon>
                       Back
                   </v-btn>
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
                    <v-form id="active-tenders-add " v-model="valid">
                        <v-text-field v-model="name"
                                        label="Pharmacy Name"
                                        :rules="nameRule"
                                        hide-details />
                        <v-text-field v-model="email"
                                        label="Pharmacy email"
                                        :rules="emailRule"
                                        hide-details />
                        <v-text-field v-model="offer"
                                        label="Your offer"
                                        :rules="offerRule"
                                        hide-details />
                        <v-btn id="active-tenders-btn" :disabled="!valid" elevation="2" @click="makeOffer" class="deep-orange white--text">
                            Make offer
                        </v-btn>
                    </v-form>
                </v-card-text>
            </v-card>   
        </transition>
    </div>
</template>

<script>
export default {
    data() {
        return {
             tendersHeaders: [
				{ text: "Id", value: "id"}, 
				{ text: "Start date"},
                { text: "End date" },
                { text: "Description" },
				{ text: "Offer" },
            ],
            name: "",
            nameRule: [
                v => !!v || "Phamracy name is required",
            ],
            email: "",
            emailRule: [
                v => !!v || "Email is required",
            ],
            offer: "",
            offerRule: [
                v => !!v || "Offer is required",
            ],
            show: true,
            valid: false,
            search: "",
            tenders: [],
            tenderDetails: "",
            medications: [],

        }
    },
    methods: {
        getAllActiveTenders: function(){
            let t = [];
            this.axios.get("http://localhost:50202/api/Tender/")
                .then(response => {
                    t = response.data;
                    for (let i = 0; i < t.length; ++i) {
                        if(t[i].tenderStatus == 0){
                            this.tenders.push(t[i]);
                        }
                    }
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response);
                });
        },

        showOfferForm: function(tender){
            this.tenderDetails = tender;
            this.getMedicationsForTender(tender.id);
            this.show = !this.show;
        },

        getMedicationsForTender: function(id){
            this.axios.get("http://localhost:50202/api/Tender/med/" + id)
                .then(response => {
                    this.medications = response.data;
                })
                .catch(response => {
                    console.log(response.data);
                })
        },

        makeOffer: function(){
            let tenderOffer = {id: 0, tenderId : this.tenderDetails.id, pharmacy : this.name, pharmacyEMail: this.email, tenderOfferPrice: this.offer}
            this.axios.post("http://localhost:50202/api/tenderOffer/makeOffer", tenderOffer)
                .then(response => {
                    console.log(response.data);
                    this.show = !this.show;
                })
                .catch(response => {
                    console.log(response.data);
                })
        },

        rss: function () {
            this.axios.get("http://localhost:50202/api/rss")
                .then(response => {
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response.data);
                })
        }
        
    },
    mounted() {
        this.getAllActiveTenders();

    }
}
</script>

<style scoped>
    
   #active-tenders-content {
		display: grid;
		grid-template-columns: 1fr auto;
	}

	#active-tenders-main {
		display: grid;
		place-items: center;
		height: 100%;
	}

	#active-tenders-card {
		display: grid;
		grid-template-columns: auto 1fr;
	}

	#active-tenders-table {
		margin-top: 5%;
		display: flex;
		flex-direction: column;
		justify-content: space-between;
	}

    #tender-add-new-btn{
        margin: 0;
        margin-top: -6%;
    }

    #active-tenders-add {
		display: flex;
		flex-direction: column;
		justify-content: space-between;
	}
    
    #active-tenders-btn{
        margin: 0 auto;
        min-width: 100%;
        margin-top: 3%;
    }

     .bounce-enter-active {
        animation: bounce-in .5s;
    }

    @keyframes bounce-in {
        0% {
            transform: scale(0);
        }

        50% {
            transform: scale(1.5);
        }

        100% {
            transform: scale(1);
        }
    }
</style>