module.exports = {
  parser: 'vue-eslint-parser',

  parserOptions: {
    parser: '@typescript-eslint/parser',
  },

  extends: ['plugin:@typescript-eslint/recommended', 'plugin:vue/base', 'prettier/@typescript-eslint', 'prettier/vue'],

  plugins: ['@typescript-eslint', 'vue'],
}