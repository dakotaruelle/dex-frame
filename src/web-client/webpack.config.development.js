const path = require('path');
const nonScopedStyles = require('./nonScopedStyles.js');

module.exports = {
  // Sets Webpack's build mode to development which has specific optimizations
  mode: 'development',

  // Enable source maps for browser debugging
  // https://webpack.js.org/configuration/devtool/
  devtool: 'eval-source-map',

  // Controls the amount of output shown in the Webpack build
  stats: 'minimal',

  // Options for the Webpack dev server, which serves the front-end of an application as its own app
  // This allows for things like automatic reloading of a page when there is a file change
  devServer: {
    port: 3000, // The port that the dev server runs on
    index: '', // specify to enable root proxying
    contentBase: path.resolve(__dirname, '../wwwroot/dist'),
    proxy: {
      context: () => true,              // Proxy all requests
      target: 'https://localhost:5001', // to ASP.NET Core backend
      secure: false,                    // don't verify the self-signed certificate
    },
  },

  module: {
    // All Webpack loaders are registered here, this is where the main bundling happens
    // Each loader has a type of file that it can process and configured options specific to it
    // Rules are processed top to bottom
    // If there are multiple loaders for a single file type, the loaders are processed right to left (or bottom to top depending on formatting)
    rules: [
      // Typescript and TSX files
      {
        test: /\.ts(x?)$/,
        exclude: /node_modules/,
        loader: 'ts-loader',
        options: { appendTsSuffixTo: [/\.vue$/] },
      },

      // Javascript and JSX files
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

      // Vue files
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
        test: /\.scss$/,
        exclude: /node_modules/,
        oneOf: [
          {
            test: nonScopedStyles,
            use: ['style-loader', 'css-loader', 'sass-loader'],
          },
          {
            use: [
              'style-loader',
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
            use: ['style-loader', 'css-loader'],
          },
          {
            use: [
              'style-loader',
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
