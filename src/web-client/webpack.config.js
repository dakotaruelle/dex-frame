const path = require('path')
const VueLoader = require('vue-loader')
const PnpWebpackPlugin = require('pnp-webpack-plugin')

module.exports = {
  mode: 'development',

  devServer: {
    contentBase: path.join(__dirname, 'dist'),
    compress: true,
    port: 7000,
  },

  entry: {
    app: './App.js',
  },
  
  module: {
    rules: [
      {
        test: /\.vue$/,
        exclude: /(node_modules)/,
        use: 'vue-loader'
      }
    ],
  },

  plugins: [
    new VueLoader.VueLoaderPlugin(),
  ],

  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: 'js/[name].js',
    publicPath: '/'
  },

  resolve: {
    alias: {
      'vue$': 'vue/dist/vue.runtime.esm-bundler.js',
    },
    plugins: [
      PnpWebpackPlugin,
    ],
  },
  resolveLoader: {
    plugins: [
      PnpWebpackPlugin.moduleLoader(module),
    ],
  },
}