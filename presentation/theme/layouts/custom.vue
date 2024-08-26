<template>
  <div class="full w-full h-full">
    <slot />
    <factor10-logo></factor10-logo>
  </div>
</template>

<script setup lang="ts">
import { defineComponent } from 'vue'
import Default from '../layouts/default.vue'
import Factor10Logo from "../components/Factor10Logo.vue";

const components = defineComponent({ Default })
</script>
