import Vue from 'vue';
import HelloWorld from './HelloWorld.vue'

new Vue({
  render: createApp => createApp(HelloWorld)
}).$mount('#vue-app');
