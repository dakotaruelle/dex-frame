const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const nonScopedStyles = require('./nonScopedStyles.js')

module.exports = {
  mode: 'production',

  plugins: [
    new MiniCssExtractPlugin({
      filename: 'css/[name].css',
    }),
  ],

  devtool: 'none',

  stats: 'verbose',

  module: {
    rules: [
      // Linting
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
            failOnWarning: false,
          },
        },
      },

      // Typescript
      {
        test: /\.ts$/,
        exclude: /node_modules/,
        loader: 'ts-loader',
        options: { appendTsSuffixTo: [/\.vue$/] },
      },

      // Javascript
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

      // Vue
      {
        test: /\.vue$/,
        exclude: /node_modules/,
        loader: 'vue-loader',
        options: {
          esModule: true,
        },
      },

      // Sass
      {
        test: /\.s(a|c)ss$/,
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

      // Css
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
}
