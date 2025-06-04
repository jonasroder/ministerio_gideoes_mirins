import { createApp } from 'vue'
import App from './App.vue'

// Vuetify 3
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

// Router (opcional)
import router from '@/router' // se você já criou src/router/index.js

// API (Axios configurado)
import api from '@/services/api'

// Se existir JWT no sessionStorage, injeta no header do Axios
const savedToken = sessionStorage.getItem('access_token')
if (savedToken) {
	api.defaults.headers.common['Authorization'] = `Bearer ${savedToken}`
}

// Cria a instância do Vuetify
const vuetify = createVuetify({
	components,
	directives,
	// aqui você pode definir um tema customizado, por exemplo:
	// theme: {
	//   defaultTheme: 'light',
	//   themes: {
	//     light: {
	//       colors: {
	//         primary: '#1976D2',
	//         secondary: '#424242',
	//       },
	//     },
	//   },
	// },
})

const app = createApp(App)
app.use(vuetify)
app.use(router) // se estiver usando Vue Router
app.mount('#app')
