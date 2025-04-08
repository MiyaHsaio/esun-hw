import { defineStore } from "pinia";

export const useCommon = defineStore("common", {
  state: () => ({
    isLoading: false,
  }),
  actions: {
    setIsLoading(value) {
      this.isLoading = value;
    },
  },
});