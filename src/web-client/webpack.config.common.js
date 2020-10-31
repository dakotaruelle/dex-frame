const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');
const PnpWebpackPlugin = require('pnp-webpack-plugin');
const VuetifyLoaderPlugin = require('vuetify-loader/lib/plugin')

module.exports = {
  entry: {
    Main: './src/Main.js',
    App: './src/App.ts',
  },

  output: {
    path: path.resolve(__dirname, 'wwwroot/dist/'),
    filename: 'js/[name].min.js',
    publicPath: '/dist',
  },

  resolve: {
    alias: {
      vue$: 'vue/dist/vue.runtime.esm.js',
    },

    extensions: ['*', '.css', '.scss', '.js', '.jsx', '.ts', '.tsx', '.vue'],

    plugins: [PnpWebpackPlugin],
  },

  resolveLoader: {
    plugins: [PnpWebpackPlugin.moduleLoader(module)],
  },

  plugins: [new VueLoaderPlugin(), new VuetifyLoaderPlugin()],
};
