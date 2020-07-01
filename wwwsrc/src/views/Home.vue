<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-3">card selector</div>
      <div class="col-7">ATM</div>
    </div>
    <div class="row">
      <div class="col-12">menu</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {},
  data() {
    return {};
  },
  computed: {},
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {}
};
</script>

<style>
</style>