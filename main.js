const {app, BrowserWindow} = require('electron');
const path = require('path');
const url = require('url');

let win;

function createWindow () {
  win = new BrowserWindow({width: 1280, height: 720});

  if (process.env.NODE_ENV === "development") { console.log("DEV ENVIRONMENT DETECTED - Waiting until Webpack finishes...") }

  win.loadURL(`file://${__dirname}/app/index.html`);

  // Dev tools
  // win.webContents.openDevTools()

  win.on('closed', () => {
    win = null
  })
}

app.on('ready', createWindow);

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit()
  }
});

app.on('activate', () => {
  if (win === null) {
    createWindow()
  }
});