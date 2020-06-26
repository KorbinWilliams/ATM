<template>
  <div class="dashboard container-fluid main">
    <div class="row">
      <div class="col-12 d-flex justify-content-center">
        <h1 class="text-white">{{this.$auth.userInfo.nickname}}'s Dashboard</h1>
      </div>
    </div>
    <div class="row text-white">
      <div class="col-12 d-flex justify-content-center">
        <h2 v-show="myKeepsToggle == 1">vault keeps</h2>
        <h2 v-show="myKeepsToggle == 2">my keeps</h2>
        <h2 v-show="myKeepsToggle == 3">public keeps</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-2 vaults">
        <div>
          <div v-for="vault in vaults" :key="vault._id">
            <br />
            <p class="btn vaultBtn" @click="setActiveVault(vault)">{{vault.name}}</p>
            <br />
            <button class="btn btn-danger" @click="deleteVault(vault)">Delete {{vault.name}}</button>
          </div>
        </div>
        <div class="form-group">
          <label for="vault-group">Create a vault</label>
          <input type="text" v-model="newVault.name" class="form-control" placeholder="Name" />
          <input
            type="text"
            v-model="newVault.description"
            class="form-control"
            placeholder="Description"
          />
          <button class="sBtn" @click="createVault">Submit</button>
          <button class="bBtn" @click="toggleKeeps">Toggle keeps</button>
        </div>
      </div>
      <div class="col-2 text-white">
        <h1 class="d-flex justify-content-center">{{this.$store.state.activeVault.name}}</h1>
        <p>{{this.$store.state.activeVault.name}}</p>
      </div>
      <div class="col-8">
        <div class="row">
          <!-- <div class="col-2"> -->
          <!-- active keepS AND OR myKeeps -->
          <keep
            class="col-2"
            v-for="activeKeep in activeKeeps"
            :key="activeKeep._id"
            :keepData="activeKeep"
            v-show="myKeepsToggle == 1"
          />
          <!-- </div> -->
        </div>
        <div class="row">
          <!-- <div class="col-2"> -->
          <keep
            class="col-2 offset-1"
            v-for="mykeep in mykeeps"
            :key="mykeep.id"
            :keepData="mykeep"
            v-show="myKeepsToggle == 2"
          />
          <!-- </div> -->
        </div>
        <div class="row">
          <!-- <div class="col-2"> -->
          <keep
            class="col-2 offset-1"
            v-for="publicKeep in publicKeeps"
            :key="publicKeep.id"
            :keepData="publicKeep"
            v-show="myKeepsToggle == 3"
          />
          <!-- </div> -->
        </div>
      </div>
    </div>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
import Keep from "../components/keep";

export default {
  // name: "dashboard",
  mounted() {
    this.$store.dispatch("get", {
      address: "vaults",
      commit: "setItem",
      commitAddress: "vaults"
    });
    this.$store.dispatch("get", {
      address: "keeps/mine",
      commit: "setItem",
      commitAddress: "myKeeps"
    });
  },
  data() {
    return {
      newVault: {
        name: "",
        description: ""
      },
      myKeepsToggle: 1
    };
  },
  methods: {
    createVault() {
      this.$store.dispatch("create", {
        data: this.newVault,
        address: "vaults",
        commitAddress: "vaults",
        commit: "addItem"
      });
    },
    setActiveVault(vault) {
      this.$store
        .dispatch("setActive", {
          data: vault,
          commitAddress: "activeVault",
          commit: "setItem"
        })
        .then(res =>
          setTimeout(
            this.$store.dispatch("getOneByAnother", {
              address1: "vaultkeeps",
              address2: "keeps",
              commit: "setItem",
              commitAddress: "activeKeeps"
            }),
            3000
          )
        );
    },
    deleteVault(vault) {
      console.log(vault);
      this.$store
        .dispatch("delete", {
          address: "vaults",
          data: vault,
          commit: "removeItem",
          commitAddress: "vaults"
        })
        .then(res =>
          setTimeout(
            this.$store.dispatch("get", {
              address: "vaults",
              commit: "setItem",
              commitAddress: "vaults"
            }),
            2000
          )
        );
    },
    toggleKeeps() {
      this.$store.dispatch("getOneByAnother", {
        address1: "vaultkeeps",
        address2: "keeps",
        commit: "setItem",
        commitAddress: "activeKeeps"
      });
      if (this.myKeepsToggle == 1) {
        this.myKeepsToggle = 2;
      } else if (this.myKeepsToggle == 2) {
        this.myKeepsToggle = 3;
      } else {
        this.myKeepsToggle = 1;
      }
    },
    getKeeps() {
      this.$store.dispatch("getOneByAnother", {
        address1: "vaultkeeps",
        address2: "keeps",
        commit: "setItem",
        commitAddress: "activeKeeps"
      });
    }
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    activeKeeps() {
      return this.$store.state.activeKeeps;
    },
    mykeeps() {
      return this.$store.state.myKeeps;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  components: {
    Keep
  }
};
</script>

<style scoped>
html,
body {
  height: 100vh;
  width: 100vw;
}
.main {
  background-color: #011640;
  background-size: cover;
  height: 100vh;
}
.vaults {
  background-color: #3e7c71;
}
.vaultBtn {
  border-radius: 2px;
  border-color: black;
  text-shadow: 1px 1px red;
}
.vaultBtn:hover {
  border-radius: 2px;
  border-color: black;
  text-shadow: 1px 1px rgb(38, 0, 255);
}
.bBtn {
  margin-top: 2rem;
}
.sBtn {
  margin-top: 1.25rem;
}
</style>
