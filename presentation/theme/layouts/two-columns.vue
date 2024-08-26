<template>
  <default class="default w-full">
    <div class="w-full">
      <slot name="default"/>
    </div>
    <div class="grid grid-cols-2">
      <div class="w-full">
        <slot name="left"/>
      </div>
      <div class="w-full">
        <slot name="right"/>
      </div>
    </div>
  </default>
</template>

<script setup lang="ts">
import { defineComponent, computed } from 'vue'
import Default from '../layouts/default.vue'
import { handleBackground } from '../layoutHelper'

const components = defineComponent({ Default })
</script>
