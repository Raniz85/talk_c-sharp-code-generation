<template>
  <div class="grid grid-cols-2 w-full h-full auto-rows-fr">
    <default class="default">
      <slot />
    </default>
    <div class="w-full w-full" :style="style" />
  </div>
</template>

<script setup lang="ts">
import { defineComponent, computed } from 'vue'
import Default from '../layouts/default.vue'
import { handleBackground } from '../layoutHelper'

const props = defineProps({
  image: {
    type: String,
  },
  class: {
    type: String,
  },
})

const style = computed(() => handleBackground(props.image))

const components = defineComponent({ Default })
</script>
