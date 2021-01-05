<template>
  <div>
    <v-card class="mb-2">
      <v-card-title>{{ warframe.name }}</v-card-title>
    </v-card>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import Warframe from './Warframe'

const WarframeCardProps = Vue.extend({
  props: {
    warframe: {
      type: Object as () => Warframe,
    },
  },
})

@Component
export default class WarframeCard extends WarframeCardProps {
  message = 'Hello from Vue'
}
</script>
