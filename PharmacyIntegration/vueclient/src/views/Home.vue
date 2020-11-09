<template>
	<div id="main-div">
		<main-navigation></main-navigation>
		<div id="header">
			<h1>Pharmacy database</h1>
		</div>
		<div class="content">
			<div id="ph-add">
				<b class="error">{{errors.id}}</b>
				<v-text-field v-model="id"
								label="Pharmacy ID"
								hide-details />
				<b class="error">{{errors.apiKey}}</b>
				<v-text-field v-model="apiKey"
								label="Pharmacy API Key"
								hide-details />
				<v-btn elevation="2" @click="add">
					Add
				</v-btn>
			</div>
				<div id="ph-table">
					<v-text-field v-model="search"
									label="Search pharmacies"
									hide-details />
					<v-data-table :headers="headers"
									:items="pharmacies"
									:search="search">
						<template v-slot:item="row">
							<tr>
								<td>{{row.item.id}}</td>
								<td>{{row.item.apiKey}}</td>
								<td>
									<v-btn elevation="0" @click="remove(row.item.id)">
										X
									</v-btn>
								</td>
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
					{ text: "Remove" },
				],
				search: [],
				id: "",
				apiKey: "",
				errors: {
					id: "",
					apiKey: "",
				},
				status: ""
			}
		},
		methods: {
			validateId: function () {
				if (!this.id) {
					this.errors.id = "Enter ID!";
					return false;
				}
				return true;
			},
			validateAPIKey: function () {
				if (!this.apiKey) {
					this.errors.apiKey = "Enter API key!";
					return false;
				}
				return true;
			},
			validateInputs: function () {
				this.errors = {
					id: "",
					apiKey: "",
				};
				let validId = this.validateId();
				let validAPIKey = this.validateAPIKey();

				return validId && validAPIKey;
			},
			add: function () {
				if (!this.validateInputs())
					return;
				this.status = "";

				let pharmacy = {
					Id: this.id,
					APIKey: this.apiKey,
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
	.error {
		color: #fff;
		font-weight: 500;
	}
	h1 {
		font-size: 3rem;
		text-align: center;
		color: #3e3e3e;
	}

	label {
		font-size: 1rem;
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