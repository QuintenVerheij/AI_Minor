<template>
  <div>
    <nav-bar bg-blue>
        <template v-slot:menuActivator>
             <b-button v-b-toggle.sidebar-1 variant="transparent"><img src="@/assets/hamburger.png" class="hamburger_icon" /></b-button>
        </template>
    </nav-bar>
   
    <b-sidebar bg-variant="dark" id="sidebar-1" title="Sidebar" position="fixed" shadow>
      <template v-slot:header-close>
        <b-icon-x variant="white"></b-icon-x>
      </template>

      <b-nav vertical>
          <b-nav-item
           class="text-left bg-custom text-custom mb-3"
          >
          <div class="d-flex flex-row">
          <b-avatar variant="primary" text="ET" size="1.5em" class="mr-1"></b-avatar> {{user.first_name}} {{user.last_name}}
          </div>
          </b-nav-item>
        </b-nav>
      <b-nav vertical>
        <b-nav-item
          class="text-left bg-custom text-custom"
          v-for="(item, index) in navItems"
          v-bind:key="index"
          :active="checkActive(item)"
          :disabled="checkActive(item)"
          @click="$router.push({ name: item.route })"
          
          >
          <div class="ml-4">
            {{item.text}}
          </div>
          </b-nav-item
        >
      </b-nav>
      <template v-slot:footer >
         <b-btn variant="text text-white" @click="signOut">Uitloggen</b-btn>
      </template>
     
    </b-sidebar>
  </div>
</template>
<script>
import NavBar from './NavBar.vue';
export default {
  components: { NavBar },
  computed: {
    user() {
      return this.$store.getters['authentication/get_user']
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
<style lang="scss" scoped>
.hamburger_icon {
  display: inline;
  max-width: 40px;
  max-height: 40px;
  min-width: 40px;
  min-height: 40px;
  padding: 10px;
}

.bg-custom {
  background-color: var(--dark-2);
}

.bg-custom:hover {
  background-color: var(--blue);
}
.text-custom a{
  color: white;
}

.nav-link.disabled {
  color: var(--pink) !important
}
</style>
