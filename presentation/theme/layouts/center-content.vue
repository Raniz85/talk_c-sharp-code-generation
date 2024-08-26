<template>
  <default class="full w-full h-full max-w-full max-h-full flex flex-col">
    <slot />
    <div class="grow flex-basis-none table">
      <div class="table-cell vertical-middle">
        <slot name="content"/>
      </div>
    </div>
  </default>
</template>

<script setup lang="ts">
import { defineComponent } from 'vue'
import Default from '../layouts/default.vue'

const components = defineComponent({ Default })
</script>
