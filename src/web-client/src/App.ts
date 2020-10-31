import Vue from 'vue';
import HelloWorld from './HelloWorld.vue';
import Vuetify from './plugins/vuetify';

new Vue({
  vuetify: Vuetify,
  render: createApp => createApp(HelloWorld),
}).$mount('#vue-app');
