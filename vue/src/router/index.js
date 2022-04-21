import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import Plot from '../views/Plot.vue'
import CreatePlot from '../views/CreatePlot.vue'
import Plant from '../views/Plant.vue'
import AllPlants from '../views/AllPlants.vue'
import AllUsersPlots from '../views/AllUsersPlots.vue'
import CreatePlant from '../views/CreatePlant.vue'



Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/plot',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/plot/:plotId",
      name: 'Plot',
      component: Plot,
      meta:{
        requiresAuth: false
      }
    },
    {
      path: '/plot/create',
      name: 'CreatePlot',
      component: CreatePlot,
      meta:{
        requiresAuth: false
      }
    },
    {
      path: '/plot/allplots',
      name: 'AllUsersPlots',
      component: AllUsersPlots,
      meta:{
        requiresAuth: false
      }
    },
    {
      path: '/plant/create',
      name: 'CreatePlant',
      component: CreatePlant,
      meta:{
        requiresAuth: false
      }
    },
    {
      path: '/plant/:plantId',
      name: 'Plant',
      component: Plant,
      meta:{
        requiresAuth: false
      }
    },
    {
      path: '/plant/all',
      name: 'AllPlants',
      component: AllPlants,
      meta:{
        requiresAuth: false
      }
    },
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
