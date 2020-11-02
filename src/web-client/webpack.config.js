const { merge } = require('webpack-merge')
const developmentConfig = require('./webpack.config.development')
const productionConfig = require('./webpack.config.production')
const commonConfig = require('./webpack.config.common')

module.exports = env => {
  let config

  if (env === 'development') {
    config = merge(commonConfig, developmentConfig)
  } else {
    config = merge(commonConfig, productionConfig)
  }

  return config
}
