<template>
  <h1 class="text-2xl font-bold text-center my-4">{{ text }}</h1>
</template>

<script setup>
defineProps({
  text: {
    type: String,
    required: true,
  },
});
</script>
