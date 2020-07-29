<template>
  <div class="about container-fluid">
    <div class="row">
      <div class="col-8 offset-2">about info</div>
    </div>
    <div class="row">
      <div class="col-12">
        <routesmenu />
      </div>
    </div>
  </div>
</template>

<script>
// TODO Make an about page that describes the overall project idea and has how-to instructions.
// NOTE make only information box scrollable.
import routesmenu from "../components/RoutesMenu";
export default {
  name: "about",
  components: {
    routesmenu,
  },
};
</script>

<style>
</style>