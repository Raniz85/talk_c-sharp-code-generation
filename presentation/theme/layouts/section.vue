<template>
  <default class="section w-full h-full grid text-center">
    <slot />
  </default>
</template>

<script setup lang="ts">
import { defineComponent } from 'vue'
import Default from '../layouts/default.vue'

const components = defineComponent({ Default })
</script>
