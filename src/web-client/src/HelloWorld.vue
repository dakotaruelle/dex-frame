<template>
  <v-app>
    <v-main>
      <v-container>
        <div :class="$style['hello-world']">{{ getMessage() }}</div>
        <v-btn color="primary" @click='toggleDarkTheme'>Toggle dark theme</v-btn>
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';
import Vuetify from 'vuetify/lib';
import Component from 'vue-class-component';

@Component
export default class HelloWorld extends Vue {
  message = 'Hello from Vue';

  getMessage(): string {
    return this.message;
  }

  toggleDarkTheme(): void {
    this.$vuetify.theme.dark = !this.$vuetify.theme.dark;
  }
}
</script>

<style lang="scss" module>
@use './Colors';

.hello-world {
  color: Colors.$vue-green;
}
</style>
