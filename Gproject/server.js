const express = require('express');
const app = express();
const port = 9999;

app.use(express.static('public'));
app.listen(port, () => {

 console.log(`Server draait op http://localhost:${port}`);
});

