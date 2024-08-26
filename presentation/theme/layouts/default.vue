<template>
  <div class="bg-main slidev-layout">
    <slot name="outer"></slot>
    <div :class="props.class">
      <slot />
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineComponent } from 'vue'
import Factor10Logo from '../components/Factor10Logo.vue'

const components = defineComponent({
  Factor10Logo,
})
const props = withDefaults(defineProps<{
  class: string,
}>(), {
  class: "my-auto"
});
</script>