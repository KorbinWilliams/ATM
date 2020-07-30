<template>
  <div class="home container-fluid">
    <div class="row top">
      <div class="col-12">
        <cardselector />
      </div>
      <div class="col-12 col-md-12">
        <atm />
      </div>
    </div>
    <div class="row bottom">
      <div class="col-12 menuBox">
        <routesmenu class="ht-100" />
      </div>
    </div>
  </div>
</template>

<script>
// TODO The home page contains most of the ATM's controller-like functions that interact with the back-end. Contains a similar if not same card selector as the editor. Background-image-bricks.
import cardselector from "../components/CardSelector";
import atm from "../components/ATM";
import routesmenu from "../components/RoutesMenu";
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
    },
  },
  components: {
    routesmenu,
    atm,
    cardselector,
  },
};
</script>

<style>
.home {
  background-image: url(https://images-na.ssl-images-amazon.com/images/I/81p05eM68hL._AC_SY355_.jpg);
}
.menuBox {
  border: 2px solid black;
}
.ht-100 {
  height: 100%;
}
</style>