import Vue from 'vue'
import App from './App.vue'
import Vuetify from './plugins/vuetify'

const vm = new Vue({
  vuetify: Vuetify,
  render: createApp => createApp(App),
})

vm.$mount('#vue-app')
