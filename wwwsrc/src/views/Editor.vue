<template>
  <div class="editor container-fluid">
    <div class="row top align-items-center">
      <div class="col-12 col-md-6">
        <div class="row justify-content-around">
          <div class="box col-4 col-md-8">
            <cardselector />
          </div>
          <div class="box col-4 col-md-8 offset-md-0">card-info?</div>
        </div>
      </div>
      <div class="col-10 offset-2 col-md-6 offset-md-0">
        <editorbox />
      </div>
    </div>
    <routesmenu class="menuBox bottom" />
  </div>
</template>

<script>
// TODO Make an editor that displays current cards. Clicking on a card displays that card information on the right card picture and on the bottom left display. The editor component has the card picture as well as a singular edit form. Background-image-simple-color.
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
.editor {
  background-color: lightblue;
}
.top {
  height: 93vh;
}
.bottom {
  height: 7vh;
}
.box {
  border: 2px solid black;
  height: 15vh;
}
</style>