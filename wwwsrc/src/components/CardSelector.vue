<template>
  <div class="cardselector row justify-content-around">
    <!-- NOTE Need data from back-end to do this. -->
    <!-- TODO v-for="(card, index) in cards" :key="index" -->
    <!-- NOTE strech-goal: make this sidescroll -->
    <div class="col-4 d-flex justify-content-center">card1</div>
    <div class="col-4 d-flex justify-content-center">card2</div>
  </div>
</template>

<script>
export default {
  name: "cardselector",
};
</script>

<style>
</style>