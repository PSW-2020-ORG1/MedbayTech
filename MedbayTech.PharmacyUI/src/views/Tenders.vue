
<template>
    <div id="tenders-main">
        <transition name="bounce">
            <v-card v-if="show" elevation="1" :loading="loadingPharmacies ? 'accent' : 'null'">
                <v-card-title id="tenders-content" class="primary secondary--text">
                    Tenders
                </v-card-title>
                <v-card-text id="tenders-card">
                    <div id="tenders-table">
                        <v-text-field v-model="search"
                                        label="Search tenders"
                                        hide-details />
                        <v-data-table :headers="tendersHeaders"
                                        :items="tenders"
                                        :search="search">
                            <template v-slot:item="row">
                                <tr >
                                    <td><router-link :to="{name:'Tender', params: {id: row.item.id}}">Tender:{{row.item.id}}</router-link></td>
                                    <td>{{row.item.startDate.substring(0, 10)}}</td>
                                    <td>{{row.item.endDate.substring(0, 10)}}</td>
                                    <td>{{row.item.tenderDescription}}</td>
                                    <td v-if="row.item.tenderStatus == 0" style="color:forestgreen">Active</td>
                                    <td v-else-if="row.item.tenderStatus == 1" style="color:orange">Pending</td>
                                    <td v-else style="color:black">Finished</td>
                                </tr>
                            </template>
                        </v-data-table>
                    </div>
                </v-card-text>
                <v-card-actions>
                    <v-btn  id="tenders-btn"
                            elevation="2" 
                            @click="show = !show" 
                            class="deep-orange white--text">
                            Create new tender
                    </v-btn>  
                </v-card-actions>
            </v-card>
        </transition>
        <transition name="bounce">
           <v-card v-if="!show" elevation="1">
               <v-card-title id="tenders-content" class="primary secondary--text">
                   New Tender
                   <v-btn color="red" dark @click="show = !show">
                       Close
                   </v-btn>
               </v-card-title>
                <v-card-text id="tendesr-card">
                    <v-form id="tenders-add" v-model="valid">
                        <v-combobox v-model="med"
                                    :items="allMedication"
                                    
                                    return-object="true"
                                    label="Requared Medication"
                                    :rules="reqMedicationRule">
                            <template slot="selection" slot-scope="data" >
                                {{ data.item.name }} - {{ data.item.dosage }}
                            </template>
                            <template slot="item" slot-scope="data">
                                {{ data.item.name }} - {{ data.item.dosage }}
                            </template>
                        </v-combobox>
                        <v-text-field v-model="medicationQuantity"
                                      label="Quantity"
                                      :rules="quantityRule"
                                      hide-details />
                        <v-btn id="tenders-btn" :disabled="!valid" elevation="2" @click="add()" class="deep-orange white--text">
                            Add to tender
                        </v-btn>
                    </v-form>
                    <div id="tenders-table">
                        <v-data-table :headers="medicationHeaders"
                                        :items="requiredMedications">
                            <template v-slot:item="row">
                                <tr>
                                    <td>{{row.item.medicationName}}</td>
                                    <td>{{row.item.medicationDosage}}</td>
                                    <td>{{row.item.medicationQuantity}}</td>
                                    <td>
                                        <v-btn elevation="0" class="white red--text" v-on:click="deleteMedication(row.item.id)">
                                            <i class="fa fa-trash" aria-hidden="true"></i>
                                        </v-btn>
                                    </td>
                                </tr>
                            </template>
                        </v-data-table>
                    </div>
                <v-text-field v-model="tenderDescription"
                                      label="Description"
                                      hide-details />
                
                    <v-dialog
                        ref="dialog"
                        v-model="modal"
                        :return-value.sync="date"
                        persistent
                        width="290px"
                        >
                        <template v-slot:activator="{ on, attrs }">
                             <v-form id="tenders-add" v-model="validToCreate">
                                <v-text-field
                                    v-model="date"
                                    clearable
                                    hide-details
                                    :rules="dateRule"
                                    label="Select end date"
                                    prepend-icon="mdi-calendar"
                                    readonly
                                    v-bind="attrs"
                                    v-on="on"
                                ></v-text-field>
                             </v-form>
                        </template>
                        <v-date-picker
                            v-model="date"
                            scrollable
                            :min="new Date().toISOString().substr(0, 10)">
                            <v-spacer></v-spacer>
                                <v-btn
                                    text
                                    color="primary"
                                    @click="modal = false">
                                Cancel
                                </v-btn>
                                <v-btn
                                    text
                                    color="primary"
                                    @click="$refs.dialog.save(date)">
                                OK
                                </v-btn>
                        </v-date-picker>
                    </v-dialog>
                </v-card-text>
                <v-card-actions>
                    <v-btn id="tenders-btn" :disabled="!(requiredMedications.length != 0) || !validToCreate" elevation="2" @click="createTender" class="deep-orange white--text">
                            Create new Tender
                        </v-btn>
                </v-card-actions>
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
				{ text: "Status", value: "tenderStatus" },
            ],
            medicationHeaders: [
				{ text: "Medication name"}, 
				{ text: "Dosage"},
                { text: "Quantity" },
                { text: "Delete" },
            ],
            quantityRule: [
                v => !!v || "Quntity is required",
            ],
            reqMedicationRule: [
                v => !!v || "Medication is required",
            ],
            dateRule: [
                v => !!v || "Date is required",
            ],
            allMedication: [],
            requiredMedications: [],
            tenderDescription: "",
            medication: "",
            medicationQuantity: "",
            tenders: [],
            search: "",
            date: "",
            show: true,
            valid: true,
            validToCreate: true,
            modal: false,
            med: {},

        }
    },
    methods: {
        getAllTenders: function(){
            this.axios.get("http://localhost:50202/api/Tender")
                .then(response => {
                    this.tenders = response.data;
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response);
                });
        },

        getAllMedications: function () {
            var medication = []
            medication.forEach(element => this.allMedication.push(element.name + " " + element.dosage));
            // TODO(Jovan): Use envvar?
            this.axios.get("http://localhost:56764/api/Medication")
                .then(response => {
                    var medication = response.data;
                    for (let index = 0; index < medication.length; ++index) {
                        let d = { id: medication[index].id, name: medication[index].med, dosage: medication[index].dosage };
                        this.allMedication.push(d);
                    }
                    console.log(this.allMedication);
                })
                .catch(response => {
                    console.log(response.data);
                })
        },

        add: function () {
            console.log(this.med);
            this.requiredMedications.push({ medicationId: this.med.id, medicationName: this.med.name, medicationDosage: this.med.dosage, medicationQuantity: this.medicationQuantity });
            this.med = "";
            this.medicationQuantity = "";
        },

        deleteMedication: function (id) {
            var list = []
            console.log(this.requiredMedications);
            for (let index = 0; index < this.requiredMedications.length; ++index) {
                if (this.requiredMedications[index].id != id) {
                    list.push({ medicationId: this.requiredMedications[index].id, medicationName: this.requiredMedications[index].name, medicationDosage: this.requiredMedications[index].dosage, medicationQuantity: this.requiredMedications[index].medicationQuantity });
                }          
            }
            console.log(list);
            this.requiredMedications = list;
        },

        createTender: function () {
            let tender = { endDate: this.date, tenderMedications: this.requiredMedications, tenderDescription: this.tenderDescription }
            this.axios.post("http://localhost:50202/api/Tender", tender)
                .then(response => {
                    this.show = !this.show;
                    this.getAllTenders();
                    console.log(response.data);
                })
                .catch(response => {
                    console.log(response.data);
                })
        }
        
    },
    mounted() {
        this.getAllTenders();
        this.getAllMedications();
    }
}
</script>

<style scoped>
    
   #tenders-content {
		display: grid;
		grid-template-columns: 1fr auto;
	}

	#tenders-main {
		display: grid;
		place-items: center;
		height: 100%;
	}

	#tenders-card {
		display: grid;
		grid-template-columns: auto 1fr;
	}

    #tenders-btn{
        margin: 0 auto;
        min-width: 100%;
        margin-top: 3%;
    }

	#tenders-table {
		margin-top: 5%;
		display: flex;
		flex-direction: column;
		justify-content: space-between;
	}

    #tender-add-new-btn{
        margin: 0;
        margin-top: -6%;
    }

    #tenders-add {
		display: flex;
		flex-direction: column;
		justify-content: space-between;
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