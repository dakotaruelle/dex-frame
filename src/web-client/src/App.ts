import Vue from 'vue'
import HelloWorld from './HelloWorld.vue'
import Vuetify from './plugins/vuetify'

const vm = new Vue({
  vuetify: Vuetify,
  render: createApp => createApp(HelloWorld),
})

vm.$mount('#vue-app')
