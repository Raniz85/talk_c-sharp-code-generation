<script setup lang="ts">
import Default from '../layouts/default.vue'
import { defineComponent } from 'vue'
import { computed } from 'vue'
import { handleBackground } from '../layoutHelper'
import Attribution from "../components/Attribution.vue";

const props = defineProps<{
  video: string
}>()

const components = defineComponent({ Default })
</script>

<template>
  <SlidevVideo class="h-full w-full" :src="props.video" controls>
  </SlidevVideo>
</template>

