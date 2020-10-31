<template>
  <div>
    <span :class="$style['hello-world']">{{ getMessage() }}</span>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';

@Component
export default class HelloWorld extends Vue {
  message: string = 'Hello World';

  getMessage(): string {
    return this.message;
  }
}
</script>

<style lang="scss" module>
@use './Colors';

.hello-world {
  color: Colors.$vue-green;
}
</style>
