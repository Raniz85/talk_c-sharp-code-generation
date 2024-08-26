<template>
  <default class="intro">
    <slot />
  </default>
</template>

<script setup lang="ts">
import { defineComponent } from 'vue'
import Default from '../layouts/default.vue'

const components = defineComponent({ Default })
</script>
