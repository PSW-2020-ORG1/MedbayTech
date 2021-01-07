<template>
	<div id="home-main">
		<main-navigation />
		<div id="header">
			<div id="header-text">
				<div id="header-title"><h1>Medbay Integration Adapters</h1></div>
				<div id="header-desc">
					<p>Making sure there are no sus pharmacies</p>
					<router-link to="/dean" v-slot="{href, navigate}">
						<v-btn color=accent :href="href" @click="navigate" id="mainbtn" elevation="1">Manage pharmacies</v-btn>
					</router-link>
				</div>
			</div>
			<div id="header-img">
				<img src="img/among_us.svg" alt="Header image">
			</div>
		</div>
	</div>
</template>

<style scoped>
	#home-main {
		height: 100%;
		width: 100%;
		background: linear-gradient(69deg, rgba(63,81,181,1) 5%, rgba(197,202,233,1) 100%); 
	}

	#header {
		display: flex;
		flex-direction: row;
		justify-content: flex-start;
		margin-top: 10vh;
	}

	#header-text {
		display: flex;
		flex-direction: column;
		justify-content: center;
		padding-left: 10vw;
	}

	#header-title h1 {
		font-family: "Poppins", sans-serif;
		font-weight: 500;
		font-size: 3.5rem;
		color: #fff;
	}

	#header-desc p {
		font-size: 1.5rem;
		color: #fff;
	}

	#header-img {
		margin-left: auto;
		height: 100%;
		width: 50%;
	}

	#header-img img {
		width: 100%;
		height: 100%
	}
</style>

