import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost") ? "https://localhost:5001/" : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    // for viewing your vaults
    activeKeep: {},
    // just for the f***ing delete
    activeKeeps: [],
    myKeeps: [],
    vaults: [],
    activeVault: {}
    // do I need vaultkeeps??? I don't think so. Screw sql
  },
  mutations: {
    addItem(state, payload) {
      state[payload.address].push(payload.data);
    },
    setItem(state, payload) {
      state[payload.address] = payload.data;
    },
    removeItem(state, payload) {
      state[payload.address].filter(item => item.id == payload.data.id)
    },
    changeItem(state, payload) {
      state[payload.address].filter(item => item.id == payload.data.id)
      if (!state[payload.address].find(i => i.id == payload.data.id)) {
        payload.address = state.myKeeps
      }
      state[payload.address].push(payload.data)
    },
    resetState(state) {
      state = {
        publicKeeps: [],
        activeKeep: {},
        activeKeeps: [],
        myKeeps: [],
        vaults: [],
        activeVault: {}
      }
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    // payload.address = url
    // payload.commit = mutation
    // data = data usually res.data
    // payload.commitAddress = store.state. <----
    get({ commit }, payload) {
      api
        .get("" + payload.address)
        .then(res => {
          commit(payload.commit, {
            data: res.data,
            address: payload.commitAddress
          });
        })
        .catch(e => console.error(e));
    },
    getOne({ commit }, payload) {
      api
        .get("" + payload.address + "/" + payload.data.id)
        .then(res => {
          commit(payload.commit, {
            data: res.data,
            address: payload.commitAddress
          });
        })
        .catch(e => console.error(e));
    },
    // for using ref's. address 1 is where the id/ref comes from, address 2 is what youre looking for, commitAddress is where it's going in the state.
    getOneByAnother({ commit }, payload) {
      api
        .get(
          "" +
          payload.address1 +
          "/" +
          this.state.activeVault.id +
          "/" +
          payload.address2
        )
        .then(res => {
          console.log(res.data)
          commit(payload.commit, {
            data: res.data,
            address: payload.commitAddress
          });
        });
    },
    create({ commit }, payload) {
      api
        .post("" + payload.address, payload.data)
        .then(res => {
          commit(payload.commit, {
            data: res.data,
            address: payload.commitAddress
          });
        })
        .catch(e => console.error(e));
    },
    edit({ commit }, payload) {
      api
        .put(
          "" + payload.address + "/" + payload.data.id || payload.id,
          payload.data
        )
        .then(res => {
          commit(payload.commit, {
            data: res.data,
            address: payload.commitAddress
          });
        })
        .catch(e => console.error(e));
    },
    delete({ commit }, payload) {
      api.delete("" + payload.address + "/" + payload.data.id).then(res => {
        commit(payload.commit, {
          data: res.data,
          address: payload.commitAddress
        });
      });
    },
    setActive({ commit }, payload) {
      commit(payload.commit, {
        data: payload.data,
        address: payload.commitAddress
      })
    },
    async createVaultKeep({ commit }, vaultKeep) {
      try {
        await api.post("vaultKeeps", vaultKeep);
        // commit("setItem", {
        //   data: res.data,
        //   address: "activeKeeps"
        // })
      } catch (error) {
        console.error(error);
      }
    }
  }
});
