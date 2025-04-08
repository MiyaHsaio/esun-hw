<template>
  <v-btn
    :icon="sortByAsc ? 'mdi-arrow-up' : 'mdi-arrow-down'"
    variant="flat"
    size="small"
    @click="emit('changeSort')"
  ></v-btn>
</template>

<script setup>
defineProps({
  sortByAsc: Boolean,
});

const emit = defineEmits(["changeSort"]);
</script>
