import express from "express";
import path from "path"
import cors from "cors"

const app = express();
const port = 3000;

app.use(express.static('public'));
app.use(cors)

app.get('/', (req, res) => {
    res.sendFile(path.resolve('./public/index.html'));
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});