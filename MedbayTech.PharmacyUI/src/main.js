import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import App from './App.vue'
import vuetify from './plugins/vuetify';
import router from './router'
import MainNavigation from './components/MainNavigation'
import FloatingLabel from './components/FloatingLabel'
import Sidebar from './components/Sidebar'

Vue.use(VueAxios, axios)
Vue.config.productionTip = false
Vue.component('main-navigation', MainNavigation)
Vue.component('floating-label', FloatingLabel)
Vue.component('sidebar', Sidebar, {
	props: ["title", "user"],
})

new Vue({
	vuetify,
	router,
	render: h => h(App),
}).$mount('#app')
