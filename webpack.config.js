const webpack = require('webpack');
const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    devtool: 'eval',
    entry: {
        app: ['./app/index.js']
    },
    output: {
        path: __dirname + '/dist',
        filename: 'bundle.js',
        publicPath: 'http://localhost:8080/'
    },
    devServer: {
        contentBase: './app',
        publicPath: 'http://localhost:8080/'
    },
    module: {
        loaders:
            [
                {
                    test: /\.js?$/,
                    loader: 'babel-loader',
                    exclude: /node_modules/,
                    query: {
                        presets: ['es2015', 'stage-1', 'react']
                    }
                },
                {
                    test: /\.less$/,
                    loader: 'style-loader!css-loader!less-loader',
                    exclude: /node_modules/,
                    include: path.resolve(__dirname, 'app')
                }
            ]
    },
    plugins: [
        new HtmlWebpackPlugin({
            title: "EvilToolkit - Webpack",
            filename: "app/index.html"
        }),
    ]
};