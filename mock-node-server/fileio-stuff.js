const fs = require('fs')


exports.readJSONFile = (filePath) => {
    try {
        const jsonString = fs.readFileSync(filePath);
        const parsedJSON = JSON.parse(jsonString);
        return parsedJSON;
    } catch(err) {
        console.log(err);
        return
    }
};

exports.writeJSONFile = (filePath, jsonString) => {
    fs.writeFileSync(filePath, jsonString);
} 