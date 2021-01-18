<template>
	<div id="navapp">
		<nav id="navbar">
			<div id="nav" :class="{sticky:active}">
				<div class="nav-container" :class="toggleNavClass()">
					<!-- NOTE(Jovan): Logo -->
					<div class="navbar-item logo">
						MIA
					</div>
					
				</div>
			</div>
		</nav>
	</div>
</template>
<script>
	module.exports =
	{
		data: function()
		{
			return{
				active: false,
			}

		},
		methods:
		{
			toggleNavClass()
			{
				if(this.active == false)
				{
					return "navbar";
				}
					else
				{
					return "navbar-sticky";
				}
			},
		},
		computed:
		{
		},
        mounted()
        {
            window.document.onscroll = () =>
            {
                let searchbar = document.getElementById("searchbar");
                if(!searchbar)
                {
                    // TODO(Jovan): Fix issue where this is called globally?!
                    return;
                }
                if(window.scrollY > searchbar.offsetTop)
                {
                    this.active = true;
                }
                else
                {
                    this.active = false;
                }
            };
        },
	}
</script>
<style scoped>
	.navbar {
		transition: 100ms;
		padding: 0px 25px 0px 25px;
	}

	.navbar-sticky {
		transition: 100ms;
		padding: 0px 25px 0px 25px;
	}

	#nav {
		transition: 150ms;
		height: 10vh;
		width: 100%;
		/*background-color: #fff;*/
		position: fixed;
		top: 0;
		z-index: 3;
	}

		#nav.sticky {
			transition: 150ms;
			background-color: #fff;
			box-shadow: 0px 1px 10px #999;
		}

	.navbar-list, .header-list, .footer-list {
		list-style-type: none;
	}

	.nav-container {
		display: flex;
		flex-direction: row;
		flex-wrap: wrap;
		align-items: center;
		justify-content: space-between;
	}

	.sticky > .nav-container {
		flex-wrap: nowrap;
	}

	.nav-container > * {
		min-height: 10vh;
		flex-basis: 50%;
	}

	.navbar-list {
		display: none;
		float: right;
		position: absolute;
		text-align: center;
		min-width: 160px;
		background: #fff;
		box-shadow: 0px 8px 16px 0px rgb(0, 0, 0, 0.2);
		z-index: 1;
		overflow: auto;
	}

	.navbar-dropdown:hover .navbar-list {
		display: block;
		top: 7vh;
	}

	.navbar-list a {
		float: none;
		color: black;
		text-decoration: none;
		display: block;
		text-align: center;
		border: none;
		font-size: 1.5rem;
		border: none;
		text-transform: capitalize;
		font-weight: 400;
		color: #000;
		padding: 5px;
	}

	.navbar-item {
		margin: 0;
		padding: 0;
	}

	.logo {
		flex-grow: 1;
		display: flex;
		align-items: center;
	}

	.navbar-sticky > .logo {
		max-width: 13rem;
	}

	.nav-container {
		max-width: 80vw;
		margin: auto;
	}

	.navbar-dropdown {
		max-width: 8rem;
		display: flex;
		justify-content: center;
		align-items: center;
	}

	#nav > .nav-container > .navbar-dropdown > .navdropbtn {
		font-size: 1.8rem;
		border: none;
		color: #fff;
		text-transform: capitalize;
		font-weight: 600;
	}

	#nav.sticky > .nav-container > .navbar-dropdown > .navdropbtn {
		font-size: 1.8rem;
		border: none;
		text-transform: capitalize;
		font-weight: 400;
		color: #000;
	}

	#nav > .nav-container > .logo {
		font-family: "Poppins";
		font-size: 1.5rem;
		border: none;
		color: #fff;
		text-transform: uppercase;
		font-weight: 600;
	}

	.navbar-list a {
	}

		.navbar-list a:hover {
			color: #ff5722;
		}

	.navbar-list hr {
		padding: 0px;
		margin: 0px;
	}

	#nav.sticky > .nav-container > .logo{
		font-size: 1.8rem;
		border: none;
		color: #ff5722;
		text-transform: uppercase;
		font-weight: 600;
	}
</style>