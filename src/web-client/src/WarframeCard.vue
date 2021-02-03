<template>
  <div>
    <v-card class="mb-3">
      <div class="d-flex flex-no-wrap justify-space-between">
        <div>
          <v-card-title class="headline" v-text="warframe.name"></v-card-title>

          <v-card-actions>
            <v-switch v-model="obtained" label="Obtained" class="mr-5"></v-switch>
            <v-switch v-model="mastered" label="Mastered"></v-switch>
          </v-card-actions>
        </div>

        <v-avatar size="150" tile class="mr-10">
          <v-img :src="`https://cdn.warframestat.us/img/${warframe.imageName}`" max-height="100" contain></v-img>
        </v-avatar>
      </div>
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
  obtained = false
  mastered = false
}
</script>
