<template>
  <v-app>
    <!-- Sizes your content based upon application components -->
    <v-main>
      <!-- Provides the application the proper gutter -->
      <v-container fluid>
        <!-- <div>User is authenticated: {{ rootVueAppProps.userIsAuthenticated }}</div>
        <form method="post" action="/Home/Login">
          <button type="submit">Login</button>
        </form> -->

        <v-row justify="center">
          <v-col v-for="warframe in warframes" :key="warframe.id" cols="5">
            <warframe-card :warframe="warframe"></warframe-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
/* eslint-disable @typescript-eslint/no-explicit-any */

import Vue from 'vue'
import Component from 'vue-class-component'
import WarframeCard from './WarframeCard.vue'
import Warframe from './Warframe'

interface RootVueAppProps {
  userIsAuthenticated?: boolean
  apiProjectUrl?: string
}

@Component({
  components: {
    'warframe-card': WarframeCard,
  },
})
export default class App extends Vue {
  message = 'Hello from Vue'
  rootVueAppProps: RootVueAppProps = {}
  warframes: Warframe[] = []

  getMessage(): string {
    return this.message
  }

  toggleDarkTheme(): void {
    this.$vuetify.theme.dark = !this.$vuetify.theme.dark
  }

  async mounted(): Promise<void> {
    this.rootVueAppProps = (window as any).rootVueAppProps

    this.warframes = await fetch(`${this.rootVueAppProps.apiProjectUrl}/warframes`).then(response => response.json())
  }
}
</script>

<style lang="scss" module>
@use './Colors';

.hello-world {
  color: Colors.$vue-green;
}
</style>
