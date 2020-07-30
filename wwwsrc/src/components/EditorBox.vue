<template>
  <div class="editorbox row">
    <div class="col-10 cardImage">top</div>
    <div class="col-10 editBox">bottom</div>
  </div>
</template>

<script>
export default {
  name: "editorbox",
};
</script>

<style>
.cardImage {
  border: 2px solid black;
  height: 20vh;
}
.editBox {
  border: 2px solid black;
  height: 20vh;
}
</style>