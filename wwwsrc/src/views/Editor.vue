<template>
  <div class="editor container-fluid">
    <div class="row">
      <div class="col-md-3 md-offset-1">
        <div class="row">
          <div class="col-12">
            <cardselector />
          </div>
          <div class="col-12">card-info?</div>
          <div class="col-12 offset-1">
            <editorbox />
          </div>
          <div class="col-12 menuBox">
            <routesmenu />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// TODO Make an editor that displays current cards. Clicking on a card displays that card information on the right card picture and on the bottom left display. The editor component has the card picture as well as a singular edit form.
import editorbox from "../components/EditorBox";
import cardselector from "../components/CardSelector";
import routesmenu from "../components/RoutesMenu";
export default {
  name: "editor",
  components: {
    routesmenu,
    cardselector,
    editorbox,
  },
};
</script>

<style>
</style>