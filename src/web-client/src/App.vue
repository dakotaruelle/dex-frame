<template>
  <v-app>
    <!-- Sizes your content based upon application components -->
    <v-app-bar
      color="grey darken-4"
      dense
      fixed
      prominent
      shrink-on-scroll
      fade-img-on-scroll
      src="/images/banner2.jpg"
      height="500"
    >
      <v-app-bar-nav-icon class="main-app-bar" style="margin-left: -8px">
        <v-img src="/images/logo.png" contain max-height="48"></v-img>
      </v-app-bar-nav-icon>

      <v-toolbar-title>Dex Frame</v-toolbar-title>

      <v-spacer></v-spacer>

      <v-menu left bottom>
        <template v-slot:activator="{ on, attrs }">
          <v-btn icon v-bind="attrs" v-on="on">
            <v-icon :color="rootVueAppProps.userIsAuthenticated ? 'blue' : 'white'">mdi-account</v-icon>
          </v-btn>
        </template>

        <v-list>
          <div class="pb-4 pl-4">Logged in as:</div>
          <v-list-item v-if="!rootVueAppProps.userIsAuthenticated" @click="login" class="px-10">
            <form id="login-form" method="POST" action="/Home/Login"></form>
            <v-list-item-title>Login</v-list-item-title>
          </v-list-item>
          <v-list-item v-else @click="logout" class="px-10">
            <form id="logout-form" method="POST" action="/Home/Logout"></form>
            <v-list-item-title>Logout</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>

    <v-main>
      <!-- Provides the application the proper gutter -->
      <v-container fluid>
        <!-- <div>User is authenticated: {{ rootVueAppProps.userIsAuthenticated }}</div>
        <form method="post" action="/Home/Login">
          <button type="submit">Login</button>
        </form> -->

        <div style="height: 575px"></div>

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

declare const document: any

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
  rootVueAppProps: RootVueAppProps = {}
  warframes: Warframe[] = []

  toggleDarkTheme(): void {
    this.$vuetify.theme.dark = !this.$vuetify.theme.dark
  }

  login(): void {
    document.getElementById('login-form').submit()
  }

  logout(): void {
    // document.getElementById('logout-form').submit()
    console.log('logout')
  }

  async mounted(): Promise<void> {
    this.rootVueAppProps = (window as any).rootVueAppProps

    this.warframes = await fetch(`${this.rootVueAppProps.apiProjectUrl}/warframes`).then(response => response.json())

    console.log('user authenticated: ', this.rootVueAppProps.userIsAuthenticated)
  }
}
</script>

<style lang="scss" module>
@use './Colors';

.hello-world {
  color: Colors.$vue-green;
}
</style>
