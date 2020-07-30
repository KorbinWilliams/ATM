<template>
  <div class="routesmenu row justify-content-around">
    <div class="col-3 d-flex justify-content-center">
      <router-link to="/" class="links">
        <button class="btn linkbtn">ATM</button>
      </router-link>
    </div>
    <div class="col-3 d-flex justify-content-center">
      <router-link to="/editor" class="links">
        <button class="btn linkbtn">Editor</button>
      </router-link>
    </div>
    <div class="col-3 d-flex justify-content-center">
      <router-link to="/about" class="links">
        <button class="btn linkbtn">About</button>
      </router-link>
    </div>
  </div>
</template>

<script>
// TODO Needs props to determine which one to exclude based on current page.
// NOTE Sretch goal: make choosing options game-like with arrow keys moving a selector.
export default {
  name: "routesmenu",
};
</script>

<style>
.routesmenu {
  background-image: linear-gradient(to bottom right, blue, black);
}
.linkbtn {
  color: white;
  text-shadow: 2px 2px black;
}
</style>