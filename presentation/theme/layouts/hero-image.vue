<template>
  <default class="full w-full h-full max-w-full max-h-full flex flex-col">
    <slot/>
    <div class="grow flex-basis-none" :style="style">
    </div>
  </default>
</template>

<script setup lang="ts">
import { defineComponent } from 'vue'
import Default from '../layouts/default.vue'
import {resolveAssetUrl} from "../layoutHelper";

const components = defineComponent({ Default })
const props = defineProps<{
  title: string,
  image: string,
}>();
const style = {
  background: `url(${resolveAssetUrl(props.image)}`,
  backgroundRepeat: 'no-repeat',
  backgroundPosition: 'center',
  backgroundSize: 'contain',
}
</script>
