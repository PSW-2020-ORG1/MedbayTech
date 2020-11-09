<template>
	<div class="container">
		<h1>Medbay Pharmacy Integration</h1>
		<ul>
			<li v-for="ph in pharmacies" :key="ph">{{ph.Id}} {{ph.APIKey}}</li>
		</ul>
	</div>
</template>

<script>
	module.exports = {
		data: function () {
			return {
				pharmacies: [],
			}
		},
		mounted(): {
			// axios.get("api/Pharmacy")
		}
	}
</script>