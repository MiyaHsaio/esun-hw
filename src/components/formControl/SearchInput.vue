<template>
  <v-text-field
    v-model="localValue"
    variant="solo"
    density="compact"
    placeholder="搜尋關鍵字"
    append-inner-icon="mdi-magnify"
    hide-details="auto"
    @click:append-inner="emit('search')"
    @keyup.enter="emit('search')"
  ></v-text-field>
</template>

<script setup>
import { ref, watch } from "vue";

const props = defineProps({
  modelValue: String,
});

const emit = defineEmits(["update:modelValue", "search"]);

const localValue = ref(props.modelValue);

watch(localValue, (newValue) => {
  emit("update:modelValue", newValue);
});

watch(
  () => props.modelValue,
  (newValue) => {
    localValue.value = newValue;
  }
);
</script>
