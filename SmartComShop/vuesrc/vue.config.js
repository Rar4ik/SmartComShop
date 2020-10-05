var path = require('path')
var fs = require('fs');
const express = require('express');
const { createProxyMiddleware } = require('http-proxy-middleware');


const app = express();

var baseAppPath = './viewmodels/'

var jsEntries = {}

fs.readdirSync(baseAppPath).forEach(function (name, i) {
    var mainFolder = baseAppPath + name
    fs.readdirSync(mainFolder).forEach(function (subName) {
        var mainFile = mainFolder + '/' + subName + '/index.js'
        if (fs.existsSync(mainFile)) { jsEntries[subName] = mainFile }
    })
});



app.use('/*', createProxyMiddleware({target: 'http://localhost:44321/', changeOrigin: true}));


module.exports = {
    outputDir: path.resolve(__dirname, 'Scripts/'),
    configureWebpack: {
        entry: jsEntries,
        output: {
            filename: '[name].js'
        },
        devtool: '#eval-source-map',
        optimization: {
            splitChunks: {
                chunks: 'all'
            }
        },
        resolve: {
            extensions: ['.js', '.vue', '.json'],
            alias: {
                'vue$': 'vue/dist/vue.esm.js',
                '@': path.join(__dirname, baseAppPath)
            }
        },
    },
    filenameHashing: false,
    productionSourceMap: true,
    chainWebpack: config => {
        config.module
            .rule('vue')
            .use('vue-loader')
            .loader('vue-loader')
            .end();

        config.module
            .rule('js')
            .test(/\.js$/)
            .use('babel-loader')
            .end();
    }
}
