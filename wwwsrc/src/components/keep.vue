<template>
  <div class="keep keep-text" @mouseover="setActiveKeep()">
    <router-link :to="{ name: 'KeepDetails'}">
      <h3 @click="raiseViews">{{keepData.name}}</h3>
    </router-link>
    <img type="button" :src="keepData.img" alt="keep image" />
    <h5>{{keepData.description}}</h5>
    <p>
      -
      <span class="text-danger">Views: {{keepData.views}}</span>
      -
      <span class="text-warning">Keeps: {{keepData.keeps}}</span>
      -
      <span class="text-primary">Shares: {{keepData.shares}}</span>
    </p>
    <div class="list-group">
      <button
        type="button"
        @click="addToVault"
        class="list-group-item list-group-item-action"
      >Add to current vault</button>
      <router-link :to="{ name: 'KeepDetails'}">
        <button
          type="button"
          class="list-group-item list-group-item-action"
          @click="raiseViews"
        >View</button>
      </router-link>
      <button
        type="button"
        class="list-group-item list-group-item-action"
        @click="deleteKeep"
      >Delete</button>
      <button
        type="button"
        class="list-group-item list-group-item-action"
        @click="raiseShares"
      >Share</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"],
  data() {
    return {
      inActiveKeep: false
    };
  },
  methods: {
    setActiveKeep() {
      this.$store.dispatch("setActive", {
        data: this.keepData,
        commitAddress: "activeKeep",
        commit: "setItem"
      });
    },
    deleteKeep() {
      let keep = this.$store.state.activeKeep;
      console.log(keep);
      // this.inActiveCheck();
      this.$store.dispatch("delete", {
        address: "keeps",
        data: keep,
        commit: "removeItem",
        commitAddress: "publicKeeps"
      });
    },
    addToVault() {
      // DON'T MESS WITH THIS, IT WORKS NOW.
      this.$store.dispatch("createVaultKeep", {
        vaultId: this.$store.state.activeVault.id,
        keepId: this.$store.state.activeKeep.id
      });
      this.raiseKeeps();
    },
    raiseViews() {
      console.log(this.$props.data);
      this.keepData.views += 1;
      this.$store.dispatch("edit", {
        address: "keeps",
        commit: "changeItem",
        commitAddress: "publicKeeps",
        data: this.keepData
      });
    },
    raiseKeeps() {
      this.keepData.keeps += 1;
      this.$store.dispatch("edit", {
        address: "keeps",
        commit: "changeItem",
        commitAddress: "publicKeeps",
        data: this.keepData
      });
    },
    raiseShares() {
      this.keepData.shares += 1;
      this.$store.dispatch("edit", {
        address: "keeps",
        commit: "changeItem",
        commitAddress: "publicKeeps",
        data: this.keepData
      });
    }
  }
};
</script>

<style>
.keep-text {
  color: whitesmoke;
}
</style>
