module.exports = {
  root: true,

  env: {
    es6: true,
    node: true,
    browser: true,
  },

  parser: 'babel-eslint',

  parserOptions: {
    ecmaVersion: 2020,
    sourceType: 'module',
    ecmaFeatures: {
      impliedStrict: true,
    },
  },

  extends: ['eslint:recommended', 'prettier', 'prettier/babel'],

  plugins: ['babel', 'prettier'],

  globals: {
    require: 'readonly',
    module: 'readonly',
  },

  rules: {
    'prettier/prettier': 'warn',
  },
}
