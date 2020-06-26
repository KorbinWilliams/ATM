<template>
  <div class="home container-fluid bg-main">
    <div class="row">
      <div class="col text-center">
        <h1 class="home-title">Home</h1>
      </div>
    </div>
    <div class="row">
      <div class="col-3 text-white">
        <!-- <p>This is where the filters will go</p> -->
        <div class="createKeep">
          <p>Create your own keep.</p>
          <div class="form-group">
            <label class="text-center" for="newKeep">Image</label>
            <input type="text" v-model="newKeep.img" class="form-control" placeholder="img" />
            <label class="text-center" for="newKeep">Title</label>
            <input type="text" v-model="newKeep.name" class="form-control" placeholder="title" />
            <label class="text-center" for="newKeep">Description</label>
            <input
              type="text"
              v-model="newKeep.description"
              class="form-control"
              placeholder="description"
            />
            <label class="text-center" for="newKeep">Private</label>
            <input
              type="text"
              v-model="booleon.istPrivate"
              class="form-control"
              placeholder="Is it private? (yes or no)."
            />
            <button class="btn-submit" @click="createKeep">Submit</button>
          </div>
        </div>
      </div>
      <div class="col-9">
        <div class="row">
          <keep
            class="col-3"
            v-for="keep in keeps"
            :key="keep.id"
            :keepData="keep"
            v-show="keep.isPrivate == false"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/keep";

export default {
  name: "home",
  mounted() {
    this.$store.dispatch("get", {
      commit: "setItem",
      address: "keeps",
      commitAddress: "publicKeeps"
    });
  },
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: false
      },
      booleon: {
        istPrivate: ""
      }
    };
  },
  computed: {
    // user() {
    //   return this.$auth.user.;
    // },
    keeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    createKeep() {
      if (this.newKeep.img.length < 5) {
        this.newKeep.img = "http://placehold.it/200x200";
      }
      if (this.booleon.istPrivate == "yes") {
        this.newKeep.isPrivate = true;
      }
      this.$store.dispatch("create", {
        address: "keeps",
        data: this.newKeep,
        commit: "addItem",
        commitAddress: "publicKeeps"
      });
      this.newKeep = {
        name: "",
        description: "",
        img: ""
      };
    }
  },
  components: {
    Keep
  }
};
</script>
<style>
.bg-main {
  background-color: #011640;
  background-size: cover;
  height: 100vh;
}
.home-title {
  color: whitesmoke;
  text-shadow: 2px 2px rgb(46, 129, 97);
}
.createKeep {
  background-color: #3e7c71;
  padding: 0, 2rem, 0, 2rem;
}
.btn-submit {
  background-color: #011640;
  color: whitesmoke;
}
</style>