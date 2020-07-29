<template>
  <div class="editor container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="row">
          <div class="col-3 offset-1">
            <div class="row">card-selector</div>
            <div class="row">card-info?</div>
          </div>
          <div class="col-7 offset-1">card editor/creator</div>
        </div>
        <routesmenu />
      </div>
    </div>
  </div>
</template>

<script>
// TODO Make an editor that displays current cards. Clicking on a card displays that card information on the right card picture and on the bottom left display. The editor component has the card picture as well as a singular edit form.
import routesmenu from "../components/RoutesMenu";
export default {
  name: "editor",
  components: {
    routesmenu,
  },
};
</script>

<style>
</style>