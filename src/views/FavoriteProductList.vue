<template>
  <div class="container my-5">
    <div class="blank"></div>

    <router-link
      :to="{ name: 'FavoriteProductCreate' }"
      class="btn btn-primary mb-4"
    >
      新增
    </router-link>

    <div class="row justify-content-between align-items-center mb-4">
      <div class="col-auto">當前顯示：{{ dataInfo.table.length }} 筆</div>
      <div class="col-auto d-flex flex-wrap gap-3">
        <button class="btn btn-outline-secondary" @click="changeSort">
          {{ dataInfo.sortByAsc ? "升序" : "降序" }}
        </button>

        <select
          v-model="dataInfo.sortName"
          class="form-select"
          @change="fetchList"
        >
          <option
            v-for="option in options.sortName"
            :key="option.id"
            :value="option.id"
          >
            {{ option.name }}
          </option>
        </select>

        <input
          v-model="dataInfo.keyword"
          type="text"
          class="form-control"
          placeholder="搜尋關鍵字"
          @keyup.enter="fetchList"
        />

        <button class="btn btn-outline-primary" @click="clearFilter">
          清除條件
        </button>
      </div>
    </div>

    <table class="table table-striped">
      <thead>
        <tr>
          <th class="text-center">編輯</th>
          <th class="text-center">刪除</th>
          <th class="text-center">產品名稱</th>
          <th class="text-center">預計扣款帳號</th>
          <th class="text-center">預計扣款總金額</th>
          <th class="text-center">總手續費用</th>
          <th class="text-center">使用者聯絡電子信箱</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in dataInfo.table" :key="item.id">
          <td class="text-center">
            <router-link
              :to="{ name: 'FavoriteProductEdit', params: { id: item.id } }"
              class="btn btn-sm btn-outline-primary"
            >
              編輯
            </router-link>
          </td>
          <td class="text-center">
            <button
              class="btn btn-sm btn-outline-danger"
              @click="deleteFavoriteProductFn(item.id)"
            >
              刪除
            </button>
          </td>
          <td class="text-center">{{ item.name }}</td>
          <td class="text-center">{{ item.account }}</td>
          <td class="text-center">{{ item.totalAmount }}</td>
          <td class="text-center">{{ item.totalFee }}</td>
          <td class="text-center">{{ item.email }}</td>
        </tr>
      </tbody>
    </table>

    <div v-if="dataInfo.table.length <= 0" class="text-center mt-5 text-muted">
      查無資料
    </div>

    <nav v-else class="d-flex justify-content-center mt-4">
      <ul class="pagination">
        <li class="page-item" :class="{ disabled: dataInfo.pageIndex === 1 }">
          <button
            class="page-link"
            @click="
              dataInfo.pageIndex--;
              fetchList();
            "
          >
            上一頁
          </button>
        </li>
        <li
          v-for="page in dataInfo.totalPages"
          :key="page"
          class="page-item"
          :class="{ active: dataInfo.pageIndex === page }"
        >
          <button
            class="page-link"
            @click="
              dataInfo.pageIndex = page;
              fetchList();
            "
          >
            {{ page }}
          </button>
        </li>
        <li
          class="page-item"
          :class="{ disabled: dataInfo.pageIndex === dataInfo.totalPages }"
        >
          <button
            class="page-link"
            @click="
              dataInfo.pageIndex++;
              fetchList();
            "
          >
            下一頁
          </button>
        </li>
      </ul>
    </nav>
  </div>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import { useCommon } from "@/stores";
import { postFavoriteProductFilter, deleteFavoriteProduct } from "@/apis";

const commonStore = useCommon();
const { setIsLoading } = commonStore;

const options = reactive({
  sortName: [
    { id: "name", name: "產品名稱" },
    { id: "account", name: "預計扣款帳號" },
    { id: "totalAmount", name: "預計扣款總金額" },
    { id: "feeRate", name: "總續費用" },
    { id: "email", name: "使用者電子信箱" },
  ],
});

const dataInfo = reactive({
  pageIndex: 1,
  pageSize: 10,
  totalPages: 1,
  sortByAsc: true,
  sortName: options.sortName[0].id,
  keyword: "",
  table: [],
});

const changeSort = () => {
  dataInfo.sortByAsc = !dataInfo.sortByAsc;
  fetchList();
};

const clearFilter = () => {
  dataInfo.pageIndex = 1;
  dataInfo.pageSize = 10;
  dataInfo.totalPages = 1;
  dataInfo.sortByAsc = true;
  dataInfo.sortName = options.sortName[0].id;
  dataInfo.keyword = "";
  dataInfo.table = [];
  fetchList();
};

const setFilterItems = () => {
  const filterArray = [];
  if (dataInfo.keyword !== "") {
    filterArray.push({ name: "keyword", value: dataInfo.keyword });
  }
  return filterArray;
};

const fetchList = async () => {
  setIsLoading(true);
  try {
    const data = {
      pageIndex: dataInfo.pageIndex,
      pageSize: dataInfo.pageSize,
      sortByAsc: dataInfo.sortByAsc,
      sortName: dataInfo.sortName,
      filterItems: setFilterItems(),
    };

    const res = await postFavoriteProductFilter(data);
    setIsLoading(false);

    if (res.data.data === null) {
      dataInfo.table = [];
      dataInfo.pageIndex = 1;
      dataInfo.totalPages = 0;
      return;
    }

    if (!res.data.ok) return;

    dataInfo.pageIndex = res.data.data.pageIndex;
    dataInfo.totalPages = res.data.data.totalPages;
    dataInfo.table = res.data.data.items;
  } catch (error) {
    console.log(error);
  }
};

const deleteFavoriteProductFn = async (id) => {
  if (!confirm("確定要刪除此金融商品嗎？")) return;

  try {
    setIsLoading(true);
    const res = await deleteFavoriteProduct(id);
    setIsLoading(false);

    if (!res.data.ok) {
      alert(res.data.message || "刪除失敗");
      return;
    }

    alert("刪除成功");
    fetchList();
  } catch (error) {
    console.error(error);
    setIsLoading(false);
    alert("刪除失敗，請稍後再試");
  }
};

onMounted(() => {
  fetchList();
});
</script>

<style scoped>
.blank {
  margin-top: 50px;
}
</style>
