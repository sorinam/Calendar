var http = require('http');

var fs = require('fs');
var htmlFile;

fs.readFile('./Calendar.html', function (err, data) {
    if (err) {
        throw err;
    }
    htmlFile = data;
});


var port = process.env.port || 8800;
http.createServer(function (request, response) {
    response.writeHead(200, { "Content-Type": "text/html" });
    response.end(htmlFile);   
}).listen(port);



