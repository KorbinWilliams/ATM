<template>
  <div class="menu row">
    <div v-if="i" class="col-3 offset-2">
      <router-link to="/home" class="links">
        <button class="btn">ATM</button>
      </router-link>
    </div>
    <div v-if="i" class="col-3">
      <router-link to="/editor" class="links">
        <button class="btn">Editor</button>
      </router-link>
    </div>
    <div v-if="i" class="col-3">
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
  name: "menu",
};
</script>

<style>
</style>