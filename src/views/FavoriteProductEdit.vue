<template>
  <div class="container my-5">
    <Title :text="'編輯喜好金融商品'" />

    <form @submit.prevent="submit">
      <div class="row mb-4">
        <div class="col-md-6 mb-3">
          <label for="name" class="form-label">產品名稱</label>
          <input
            v-model="productInfo.name"
            type="text"
            class="form-control"
            id="name"
            placeholder="請輸入金融商品名稱"
            required
          />
        </div>
        <div class="col-md-6 mb-3">
          <label for="price" class="form-label">產品價格</label>
          <input
            v-model="productInfo.price"
            type="number"
            class="form-control"
            id="price"
            placeholder="請輸入價格"
            required
          />
        </div>
      </div>

      <div class="row mb-4">
        <div class="col-md-6 mb-3">
          <label for="feeRate" class="form-label">手續費率 (%)</label>
          <input
            v-model="productInfo.feeRate"
            type="number"
            class="form-control"
            id="feeRate"
            placeholder="請輸入手續費率"
            required
          />
        </div>
        <div class="col-md-6 mb-3">
          <label for="account" class="form-label">扣款帳號</label>
          <input
            v-model="productInfo.account"
            type="text"
            class="form-control"
            id="account"
            placeholder="請輸入扣款帳號"
            required
          />
        </div>
      </div>

      <div class="mb-4">
        <label for="quantity" class="form-label">購買數量</label>
        <input
          v-model="productInfo.quantity"
          type="number"
          class="form-control"
          id="quantity"
          placeholder="請輸入購買數量"
          required
        />
      </div>

      <hr class="my-5" />

      <div class="d-flex justify-content-center gap-3">
        <button type="button" class="btn btn-secondary w-25" @click="goBack">
          取消
        </button>
        <button type="submit" class="btn btn-success w-25">送出</button>
      </div>
    </form>
  </div>
</template>

<script setup>
import Title from "@/components/componentUI/Title.vue";
import { reactive, onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { useCommon } from "@/stores";
import { getFavoriteProduct, putFavoriteProduct } from "@/apis";

const commonStore = useCommon();
const { setIsLoading } = commonStore;
const router = useRouter();
const route = useRoute();
const id = route.params.id;

const productInfo = reactive({
  id: 0,
  name: "",
  price: null,
  feeRate: null,
  account: "",
  quantity: null,
});

const fetchProductDetail = async () => {
  try {
    setIsLoading(true);
    const res = await getFavoriteProduct(id);
    if (!res.data.ok) return;

    productInfo.id = res.data.data.id;
    productInfo.name = res.data.data.name;
    productInfo.price = res.data.data.price;
    productInfo.feeRate = res.data.data.feeRate;
    productInfo.account = res.data.data.account;
    productInfo.quantity = res.data.data.quantity;

    setIsLoading(false);
  } catch (error) {
    console.error(error);
    setIsLoading(false);
  }
};

const submit = async () => {
  try {
    if (
      !productInfo.name ||
      !productInfo.price ||
      !productInfo.account ||
      !productInfo.quantity ||
      !productInfo.feeRate
    ) {
      alert("請完整填寫所有欄位");
      return;
    }

    setIsLoading(true);
    const payload = { ...productInfo };
    const res = await putFavoriteProduct(id, payload);
    setIsLoading(false);

    if (!res.data.ok) {
      alert(res.data.message || "更新失敗");
      return;
    }

    alert("更新成功");
    router.push({ name: "FavoriteProductList" });
  } catch (err) {
    console.error(err);
    setIsLoading(false);
    alert("送出失敗，請稍後再試");
  }
};

const goBack = () => {
  router.push({ name: "FavoriteProductList" });
};

onMounted(() => {
  fetchProductDetail();
});
</script>
