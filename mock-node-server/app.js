const express = require('express')
const app = express()
const port = 9001
const { readJSONFile, writeJSONFile } = require('./fileio-stuff');
app.use(express.json()) // for parsing application/json


// RUN THIS FILE WITH `node app.js` 

//Database Server Setup
var database = readJSONFile('./database.json'); 


//Express Server Stuff
app.get('/', (req, res) => {
  console.log(database);
  res.send('Hello World From Mock Node Server!')
})

app.get('/readDatabase', (req, res) => {
  res.send(database);
});

app.post('/writeDatabase', (req, res) => {
  const newObject = req.body
  database.push(newObject);
  writeJSONFile('./database.json', JSON.stringify(database));
  database = readJSONFile('./database.json');
  res.sendStatus(200);
})

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})
