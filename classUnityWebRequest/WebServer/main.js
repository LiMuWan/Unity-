var express = require("express");
var path = require("path");
var app = express();  
app.listen(8080); // http://127.0.0.1:8080/   https://www.baidu.com/ --->baidu.com--->DNS服务器解析成ip地址，443, 80端口
app.use("/", express.static(path.join(process.cwd(), "www_root"))); // http://127.0.0.1:6080/version.txt

app.get("/uploadData", function(req, res) { // http://127.0.0.1:6080/uploadData
	console.log(req.query);
	res.send("BYCWUnityWebRequest!");
});

var fs = require("fs");
app.put("/UploadFile", function(req, res) {
	// 打开一个文件
	var fd = fs.openSync("./upload/80000.mp3", "w");
	req.on("data", function(data) {
		// 我就把数据写入到文件去;
		fs.write(fd, data, 0, data.length, function() {});
	});
	
	req.on("end", function() {
		
		res.send("UploadSucess");
		fs.close(fd, function() {});
	})
});