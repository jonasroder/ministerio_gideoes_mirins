import { createRouter, createWebHistory } from 'vue-router'

import HomeView from '@/views/HomeView.vue'
import AboutView from '@/views/AboutView.vue'  // ou qualquer outra página que queira

const routes = [
	{
		path: '/',
		name: 'Home',
		component: HomeView,
		meta: { requiresAuth: false }
	},
	{
		path: '/about',
		name: 'About',
		component: AboutView,
		meta: { requiresAuth: false }
	},
	// rota “catch-all”: redireciona tudo que não bater para a Home
	{
		path: '/:pathMatch(.*)*',
		redirect: '/'
	}
]

const router = createRouter({
	history: createWebHistory(), // modo “history” sem hash
	routes
})

// Se no futuro quiser adicionar guards de autenticação, faça algo assim:
// router.beforeEach((to, from, next) => {
//   const token = sessionStorage.getItem('access_token')
//   if (to.meta.requiresAuth && !token) {
//     return next({ name: 'Login' })
//   }
//   next()
// })

export default router
