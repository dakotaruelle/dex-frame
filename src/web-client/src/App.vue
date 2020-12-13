<template>
  <v-app>
    <v-app-bar
      absolute
      shrink-on-scroll
      color="#6A76AB"
      dark
      app
      prominent
      src=""
      scroll-target="#scrolling-techniques-3"
    >
      <template v-slot:img="{ props }">
        <v-img v-bind="props" gradient="to top right, rgba(100,115,201,.7), rgba(25,32,72,.7)"></v-img>
      </template>

      <v-app-bar-nav-icon></v-app-bar-nav-icon>

      <v-toolbar-title>Title</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn icon>
        <v-icon>mdi-dots-vertical</v-icon>
      </v-btn>
    </v-app-bar>

    <!-- Sizes your content based upon application components -->
    <v-main>
      <!-- Provides the application the proper gutter -->
      <v-container fluid>
        <div>Main content</div>
        <div>User is authenticated: {{ rootVueAppProps.userIsAuthenticated }}</div>
        <form method="post" action="/Home/Login">
          <button type="submit">Login</button>
        </form>

        <h1>Warframes</h1>
        <div v-for="warframe in warframes" :key="warframe.id">
          <span>id: {{ warframe.id }}</span>
          <span>name: {{ warframe.name }}</span>
        </div>
      </v-container>
    </v-main>

    <v-footer app> Footer </v-footer>
  </v-app>
</template>

<script lang="ts">
/* eslint-disable @typescript-eslint/no-explicit-any */

import Vue from 'vue'
import Component from 'vue-class-component'

interface RootVueAppProps {
  userIsAuthenticated?: boolean
}

interface Warframe {
  id: number
  name: string
}

@Component
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
    const data = await fetch('https://framedex-api.azurewebsites.net/warframes').then(response => response.json())

    this.warframes = data

    this.rootVueAppProps = (window as any).rootVueAppProps
  }
}
</script>

<style lang="scss" module>
@use './Colors';

.hello-world {
  color: Colors.$vue-green;
}
</style>
