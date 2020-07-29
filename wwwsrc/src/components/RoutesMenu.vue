<template>
  <div class="menu row">
    <div class="col-3 offset-2">
      <router-link to="/" class="links">
        <button class="btn">ATM</button>
      </router-link>
    </div>
    <div class="col-3">
      <router-link to="/editor" class="links">
        <button class="btn">Editor</button>
      </router-link>
    </div>
    <div class="col-3">
      <router-link to="/about" class="links">
        <button class="btn">About</button>
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
</style>