const path = require('path')
const nonScopedStyles = require('./nonScopedStyles.js')

module.exports = {
  mode: 'development',

  devtool: 'eval-source-map',

  stats: 'minimal',

  devServer: {
    port: 3000,
    index: '', // specify to enable root proxying
    contentBase: path.resolve(__dirname, '../wwwroot/dist'),
    proxy: {
      context: () => true, // Proxy all requests
      target: 'https://localhost:5001', // to ASP.NET Core backend
      secure: false, // don't verify the self-signed certificate
    },
  },

  module: {
    rules: [
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
            use: ['style-loader', 'css-loader', 'sass-loader'],
          },
          {
            use: [
              'vue-style-loader',
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
              'vue-style-loader',
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
