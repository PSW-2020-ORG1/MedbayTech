<template>
    <div id="main-div">
		<div class="content">
			<v-form id="ph-add" v-model="valid">
				<v-text-field v-model="id"
								label="Pharmacy ID"
								:rules="idRules"
								hide-details />
				<v-text-field v-model="apiKey"
								label="Pharmacy API Key"
								:rules="apiKeyRules"
								hide-details />
				<v-text-field v-model="apiEndpoint"
								label="Pharmacy API Endpoint"
								:rules="apiEndpointRules"
								hide-details />
				<v-btn :disabled="!valid" elevation="2" @click="add" class="deep-orange white--text">
					Add
				</v-btn>
			</v-form>
            <div id="ph-table">
                <v-text-field v-model="search"
                                label="Search pharmacies"
                                hide-details />
                <v-data-table :headers="headers"
                                :items="pharmacies"
                                :search="search">
                    <template v-slot:item="row">
						<tr>
							<td><router-link :to="{name:'Pharmacy', params: {id: row.item.id}}">{{row.item.id}}</router-link></td>
							<td>{{row.item.apiKey}}</td>
							<td>{{row.item.apiEndpoint}}</td>
							<td>
								<v-btn class="white red--text" elevation="0" @click="remove(row.item.id)">
									<i class="fa fa-trash" aria-hidden="true"></i>
								</v-btn>
							</td>
							<td v-if="row.item.recieveNotificationFrom"><v-btn class="white red--text" elevation="0" v-on:click="changeSendMessagePermision(row.item)">Don't allow</v-btn></td>
							<td v-else><v-btn class="white green--text" elevation="0" v-on:click="changeSendMessagePermision(row.item)">Allow</v-btn></td>
						</tr>
                    </template>
                </v-data-table>
            </div>
		</div>
	</div>
</template>

<script>
	module.exports = {
		data: function () {
			return {
				pharmacies: [],
				headers: [
					{ text: "Id", value: "id", },
					{ text: "API_Key", value: "apiKey", },
					{ text: "API_Endpoint", value: "apiEndpoint", },
					{ text: "Remove" },
                    { text: "Get notification" },
				],
				search: [],
				valid: false,
				id: "",
				idRules: [
					v => !!v || "Id is required",
				],
				apiKey: "",
				apiKeyRules: [
					v => !!v || "API Key is required",
				],
				apiEndpoint: "",
				apiEndpointRules: [
					v => !!v || "API Endpoint is required",
				],
				status: "",
			}
		},
		methods: {

			add: function () {
				if (!this.valid) return;
				this.status = "";

				let pharmacy = {
					Id: this.id,
					APIKey: this.apiKey,
					APIEndpoint: this.apiEndpoint,
				};

				this.axios.post("http://localhost:50202/api/Pharmacy/", pharmacy)
					.then(response => {
						this.status = "Added!";
						this.getPharmacies();
						console.log(response);
					})
					.catch(response => {
						this.status = "Failed!";
						console.log(response);
					});
			},
			remove: function (id) {
				this.status = "";
				console.log(id);
				this.axios.delete("http://localhost:50202/api/Pharmacy?id=" + id)
					.then(response => {
						this.status = "Deleted";
						this.getPharmacies();
						console.log(response);
					})
					.catch(response => {
						this.status = "Failed deletion";
						console.log(response);
					});
			},
			changeSendMessagePermision: function (pharmacy) {
				pharmacy.recieveNotificationFrom = !pharmacy.recieveNotificationFrom;
                this.axios.post("http://localhost:50202/api/Pharmacy/update", pharmacy)
                    .then(response => {
                        this.status = "Changed!";
                        this.getPharmacies();
                        console.log(response);
                    })
                    .catch(response => {
                        this.status = "Failed!";
                        console.log(response);
                    });
			},
			getPharmacies: function () {
				this.axios.get("http://localhost:50202/api/pharmacy")
					.then(response => {
						this.pharmacies = response.data;
					});
			},

		},
		mounted() {
			this.getPharmacies();
		}
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

	#ph-add {
		display: flex;
		flex-direction: column;
		justify-content: space-between;
	}

	#ph-table {
		margin-left: 2%;
		display: flex;
		flex-direction: column;
		justify-content: space-between;
	}

	.content {
		display: flex;
		flex-direction: row;
		justify-content: space-between;
		max-width: 70%;
		margin: 0 auto;
	}
</style>