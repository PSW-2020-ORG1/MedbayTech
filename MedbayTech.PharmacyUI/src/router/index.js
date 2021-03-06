import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Pharmacy from '../views/Pharmacy.vue'
import Messages from '../views/Messages.vue'
import MedicationUsageReport from '../views/MedicationUsageReport.vue'
import DeanPanel from '../views/DeanPanel.vue'
import Pharmacies from '../views/Pharmacies.vue'
import Medication from '../views/Medication.vue'
import UrgentRequest from '../views/UrgentRequest.vue'
import UrgentOrder from '../views/UrgentOrder.vue'
import Tenders from '../views/Tenders.vue'
import Tender from '../views/Tender.vue'
import ActiveTender from '../views/ActiveTender.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/dean',
    name: 'DeanPanel',
    component: DeanPanel,
    children: [
        {
          path: '',
          name: 'Messages',
          component: Messages,
        },
        {
          path: 'pharmacies',
          name: 'Pharmacies',
          component: Pharmacies,
        },
        {
          path: 'pharmacies/:id',
          name: 'Pharmacy',
          component: Pharmacy,
        },
        {
          path: 'medication_usage_report',
          name: 'MedicationUsageReport',
          component: MedicationUsageReport,
        },
        {
          path: 'medication',
          name: 'Medication',
          component: Medication,
        },
        {
            path: 'urgentRequest',
            name: 'UrgentRequest',
            component: UrgentRequest,
        },
        {
            path: 'urgentOrder',
            name: 'UrgentOrder',
            component: UrgentOrder,
        },
        {
          path: 'tenders',
          name: 'Tenders',
          component: Tenders,
        },
        {
          path: 'tender/:id',
          name: 'Tender',
          component: Tender,
        },
        {
          path: 'activeTender',
          name: 'ActiveTender',
          component: ActiveTender,
        },
      ],
    }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
