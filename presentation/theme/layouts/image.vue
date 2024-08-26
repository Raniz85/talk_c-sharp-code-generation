<script setup lang="ts">
import { defineComponent, computed } from 'vue'
import Factor10Logo from '../components/Factor10Logo.vue'
import { handleBackground } from '../layoutHelper'
const props = defineProps({
  image: {
    type: String,
  },
  size: {
    type: String,
    default: "contain"
  }
})
const style = computed(() => handleBackground(props.image, false, props.size))
const components = defineComponent({ Factor10Logo, })
</script>

<template>
  <div class="bg-main w-full h-full p-0">
    <factor10-logo></factor10-logo>
    <div class="h-full w-full max-w-full max-h-full slidev-layout" :style="style">
      <div class="myauto">
        <slot />
      </div>
    </div>
  </div>
</template>