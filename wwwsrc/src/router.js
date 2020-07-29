import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Editor from "../src/views/Editor.vue";
// @ts-ignore
import About from "../src/views/About.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    {
      path: "/editor",
      name: "editor",
      component: Editor,
    },
    {
      path: "/about",
      name: "about",
      component: About,
    },
  ],
});
