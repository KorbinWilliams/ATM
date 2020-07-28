<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-3">card selector</div>
      <div class="col-7">ATM</div>
    </div>
    <div class="row">
      <div class="col-12">
        <menu />
      </div>
    </div>
  </div>
</template>

<script>
// TODO The home page contains most of the ATM's controller-like functions that interact with the back-end. Contains a similar if not same card selector as the editor.
import menu from "../components/Menu";
export default {
  name: "home",
  mounted() {},
  data() {
    return {};
  },
  computed: {},
  methods: {
    // NOTE Should I go without a user login? Stay true to a functioing ATM design, or go for ease of use?
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    menu
  }
};
</script>

<style>
</style>