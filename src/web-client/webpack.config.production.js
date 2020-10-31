const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const nonScopedStyles = require('./nonScopedStyles.js');

module.exports = {
  // Sets Webpack's build mode to production which has specific optimizations
  mode: 'production',

  plugins: [
    new MiniCssExtractPlugin({
      filename: 'css/[name].css',
    }),
  ],

  // Enable source maps for browser debugging
  // https://webpack.js.org/configuration/devtool/
  devtool: 'none',

  // Controls the amount of output shown in the Webpack build
  stats: 'verbose',

  // This section is similar to the matching section in webpack.config.development.js but has some production specific configuration (e.g. linting all files before build)
  module: {
    rules: [
      {
        enforce: 'pre',
        test: /\.(js|jsx|ts|tsx|vue)$/,
        exclude: /node_modules/,
        use: {
          loader: 'eslint-loader',
          options: {
            cache: true,
            fix: false,
            emitWarning: true,
            emitError: true,
            failOnError: true,
            failOnWarning: true,
          },
        },
      },

      {
        test: /\.ts(x?)$/,
        exclude: /node_modules/,
        loader: 'ts-loader',
        options: { appendTsSuffixTo: [/\.vue$/] },
      },

      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: [
          {
            loader: 'babel-loader',
            options: {
              presets: ['@babel/preset-env'],
            },
          },
        ],
      },

      {
        test: /\.vue$/,
        exclude: /node_modules/,
        loader: 'vue-loader',
        options: {
          esModule: true,
        },
      },

      {
        test: /\.scss$/,
        exclude: /node_modules/,
        oneOf: [
          {
            test: nonScopedStyles,
            use: [MiniCssExtractPlugin.loader, 'css-loader', 'sass-loader'],
          },
          {
            use: [
              MiniCssExtractPlugin.loader,
              {
                loader: 'css-loader',
                options: {
                  modules: true,
                },
              },
              'sass-loader',
            ],
          },
        ],
      },

      {
        test: /\.css$/,
        exclude: /node_modules/,
        oneOf: [
          {
            test: nonScopedStyles,
            use: [MiniCssExtractPlugin.loader, 'css-loader'],
          },
          {
            use: [
              MiniCssExtractPlugin.loader,
              {
                loader: 'css-loader',
                options: {
                  modules: true,
                },
              },
            ],
          },
        ],
      },
    ],
  },
};
