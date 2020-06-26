<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-nav">
    <router-link class="navbar-brand" :to="{ name: 'home' }">Keepr</router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item" :class="{ active: $route.name == 'home' }">
          <router-link :to="{ name: 'home' }" class="nav-link">Home</router-link>
        </li>
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'dashboard' }"
        >
          <router-link class="nav-link" :to="{ name: 'dashboard' }">My-Dashboard</router-link>
        </li>
      </ul>
      <span class="navbar-text">
        <button class="btn btn-logout" @click="login" v-if="!$auth.isAuthenticated">Login</button>
        <button class="btn btn-login" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      await this.$auth.logout();
      this.$store.dispatch("resetBearer");
      this.$router.push({ name: "home" });
    }
  }
};
</script>

<style>
.bg-nav {
  background-color: #04d9b2;
}
.btn-login {
  background-color: #04d9b2;
  color: white;
  text-shadow: 2px 2px black;
}
.btn-logout {
  background-color: #022840;
  color: white;
  text-shadow: 2px 2px black;
}
</style>
// red #F20505 darkblue #011640 alsodarkbluebutwithgreysorta #022840
// lightblue #04D9B2 beige? #F2B872