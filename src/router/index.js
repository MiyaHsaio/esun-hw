import { createRouter, createWebHistory } from "vue-router";
import { favoriteProductRoutes } from "./favoriteProduct";

const routes = [
  ...favoriteProductRoutes,
  {
    path: "/",
    redirect: "/favorite-product/list",
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;