<template>
  <div>
    <nav-bar>
        <template v-slot:menuActivator>
             <b-button v-b-toggle.sidebar-1>Toggle Sidebar</b-button>
        </template>
    </nav-bar>
   
    <b-sidebar id="sidebar-1" title="Sidebar" shadow>
      <b-nav vertical class="w-25">
        <b-nav-item
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
  data() {
    return {
      navItems: [
        {
          text: "Overzicht",
          route: "Home",
        },
        {
          text: "Oefeningen",
          route: "Exercises",
        },
        {
          text: "Statistieken",
          route: "Statistics",
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
      }
  }
};
</script>
