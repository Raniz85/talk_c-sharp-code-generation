<script setup lang="ts">
import Default from '../layouts/default.vue'
import { defineComponent } from 'vue'
import { computed } from 'vue'
import { handleBackground } from '../layoutHelper'
import Attribution from "../components/Attribution.vue";

const props = defineProps({
  background: {
    // random image from a curated Unsplash collection by Anthony
    default: 'https://source.unsplash.com/collection/94734566/1920x1080',
  },
  dim: {
    default: true,
  },
  attribution: {
    default: null
  },
})

const style = computed(() => handleBackground(props.background, props.dim))
const components = defineComponent({ Default })
</script>

<template>
  <default class="cover h-full grid place-content-center" :style="style">
    <slot />
    <template v-slot:outer>
      <Attribution v-if="props.attribution">{{ props.attribution }}</Attribution>
    </template>
  </default>
</template>

