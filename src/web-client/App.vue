<template>
  <div>Hello from {{ name }}</div>
</template>

<script>
import { ref } from 'vue'

export default {
  setup() {
    const name = ref('Vue 3')

    return { name }
  }
}
</script>