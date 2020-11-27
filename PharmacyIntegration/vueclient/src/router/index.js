import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Pharmacy from '../views/Pharmacy.vue'
import Messages from '../views/Messages.vue'
import MedicationUsageReport from '../views/MedicationUsageReport.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/pharmacy/:id',
    name: 'Pharmacy',
    component: Pharmacy,
    },
    {
        path: '/messages',
        name: 'Messages',
        component: Messages,
    },
    {
        path: '/medication_usage_report',
        name: 'MedicationUsageReport',
        component: MedicationUsageReport,
    },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
