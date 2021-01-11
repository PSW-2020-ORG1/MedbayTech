
<template>
    <div id="active-tenders-main">
       <transition name="bounce">
            <v-card v-if="show" elevation="1">
                <v-card-title id="active-tenders-content" class="primary secondary--text">
                    Active Tenders
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
                                    <td><v-btn class="deep-orange white--text" @click="makeOffer(row.item)">
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
                    <v-btn color="red" dark @click="show = !show">
                       Close
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
                        <v-btn id="active-tenders-btn" :disabled="!valid" elevation="2" @click="add" class="deep-orange white--text">
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
            this.tenders.push({id: "123", startDate: "12.01.2021", endDate: "12.01.2021"});
            // this.axios.get("http://localhost:50202/api/Tender/")
            //     .then(response => {
            //         this.tenders = response.data;
            //         console.log(response.data);
            //     })
            //     .catch(response => {
            //         console.log(response);
            //     });
        },
        makeOffer: function(tender){
            this.tenderDetails = tender;
            this.getMedicationsForTender(tender.id);
            this.show = !this.show;
        },
        getMedicationsForTender: function(id){
            console.log(id);
            this.medications.push({medicationName: "Brufen", medicationDosage: "100mg", medicationQuantity: 100});
            this.medications.push({medicationName: "Aspirin", medicationDosage: "500mg", medicationQuantity: 200});
            this.medications.push({medicationName: "Kafetin", medicationDosage: "200mg", medicationQuantity: 500});
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