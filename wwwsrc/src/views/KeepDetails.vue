<template>
  <div class="KeepDetails container-fluid bg-blue text-white">
    <div class="d-flex centerPiece">
      <div class="row">
        <div class="col-12"></div>
        <div class="col-12 text-center">
          <img :src="keep.img" alt="keep image" />
          <h3>{{keep.name}}</h3>
          <h5>{{keep.description}}</h5>
          <h6>views:{{keep.views}} keeps:{{keep.keeps}} shares: {{keep.shares}}</h6>
        </div>
        <div class="col-12"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "KeepDetails",
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  }
};
</script>

<style>
html,
body {
  height: 100vh;
  width: 100vw;
}
.bg-blue {
  height: 100vh;
  background-color: rgb(46, 46, 128);
  background-size: cover;
}
.centerPiece {
  justify-content: center;
  align-content: center;
  height: 100vh;
}
</style>