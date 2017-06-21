const webpack = require('webpack');
const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: [
        './app/index.js'
    ],
    output: {
        path: __dirname + '/dist',
        filename: 'bundle.js',
        publicPath: '/'
    },
    module: {
        loaders:
            [
                {
                    test: /.js?$/,
                    loader: 'babel-loader',
                    include: path.join(__dirname, 'app'),
                    exclude: /node_modules/,
                    query: {
                        presets: ['es2015', 'stage-1', 'react']
                    }
                }
            ]
    },
    plugins: [
        new webpack.optimize.UglifyJsPlugin({
            minimize: true,
            compress: {
                warnings: false
            }
        }),
        new HtmlWebpackPlugin({
            title: "EvilPanel",
            filename: "index.html"
        }),
    ]
};