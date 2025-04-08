import FavoriteProductCreate from "../views/FavoriteProductCreate.vue";
import FavoriteProductEdit from "../views/FavoriteProductEdit.vue";
import FavoriteProductList from "../views/FavoriteProductList.vue";

export const favoriteProductRoutes = [
  {
    path: "/favorite-product/create",
    name: "FavoriteProductCreate",
    component: FavoriteProductCreate,
  },
  {
    path: "/favorite-product/edit/:id",
    name: "FavoriteProductEdit",
    component: FavoriteProductEdit,
  },
  {
    path: "/favorite-product/list",
    name: "FavoriteProductList",
    component: FavoriteProductList,
  },
];