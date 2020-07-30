<template>
  <div class="about container-fluid">
    <div class="row top align-items-center">
      <div class="col-10 offset-1 infoBox">
        <div class="row">
          <div class="col-12 d-flex justify-content-center">
            <h1>About</h1>
          </div>
        </div>
        <div class="row">
          <div class="col-12">
            <h5>ATM: The atm is based on real atms, and if you need help figuring out how to use it, ask your local bank.</h5>
          </div>
        </div>
        <div class="row">
          <div class="col-12">
            <h5>Editor: To use the editor, first select a card or click create a card. Click on the part of the card you would like to edit on the picture and enter your desired changes. Press apply when you're done.</h5>
          </div>
        </div>
      </div>
    </div>
    <div class="row bottom">
      <div class="col-12 menuBox">
        <routesmenu class="ht-100" />
      </div>
    </div>
  </div>
</template>

<script>
// TODO Make an about page that describes the overall project idea and has how-to instructions. Background-color-black?
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
.infoBox {
  color: greenyellow;
  background-color: black;
  border: 2px solid black;
  height: 50vh;
  margin-top: 10vh;
  margin-bottom: 10vh;
}
.about {
  background-color: black;
}
</style>