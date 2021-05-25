<template>
  <div>
    <nav-bar bg-blue>
        <template v-slot:menuActivator>
             <b-button v-b-toggle.sidebar-1 variant="transparent"><img src="@/assets/hamburger.png" class="hamburger_icon" /></b-button>
        </template>
    </nav-bar>
   
    <b-sidebar bg-variant="dark" id="sidebar-1" title="Sidebar" shadow>
      <b-nav vertical>
        <b-nav-item
          bg-variant='light'
          v-for="(item, index) in navItems"
          v-bind:key="index"
          :active="checkActive(item)"
          :disabled="checkActive(item)"
          @click="$router.push({ name: item.route })"
          >{{item.text}}</b-nav-item
        >
      </b-nav>
      <b-btn @click="signOut">Uitloggen</b-btn>
    </b-sidebar>
  </div>
</template>
<script>
import NavBar from './NavBar.vue';
export default {
  components: { NavBar },
  computed: {
    role(){
     return this.$store.getters['authentiction/get_user'].role;
    }
  },
  data() {
    return {
      navItems: [
        {
          text: "Overzicht",
          route: "Home",
          role: 'all'
        },
        {
          text: "Oefeningen",
          route: "Exercises",
          role: 'all'
        },
        {
          text: "Statistieken",
          route: "Statistics",
          role: 'all'
        },
        {
          text: "Admin",
          route: "Admin",
          role: 'admin'
        },
      ],
    };
  },
  methods: {
      checkActive(item) {
          return item.route === this.$route.name;
      },
      signOut(){
          this.$store.dispatch('authentication/signOut');
      },
      checkRole(role){
        if(role === 'all'){
          return true;
        }
        if(this.role === 'admin' || this.role === role){
          return true;
        }
        if(this.role === 'therapist'){
          if(role === 'therapist') {
            return true
          }
        }
        return false;
      }
  }
};
</script>
<style>
.hamburger_icon {
  display: inline;
  max-width: 40px;
  max-height: 40px;
  min-width: 40px;
  min-height: 40px;
  padding: 10px;
}
</style>
