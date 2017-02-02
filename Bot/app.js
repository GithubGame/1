var restify = require('restify');
var builder = require('botbuilder')

var server = restify.createServer();

// server.listen(process.env.port || process.env.PORT || 3978, function () {
// 	console.log("%s listening to port %s", server.name, server.url);
// });

function call() {
	server.get("http://localhost:5000/api/message", function (responce) {
		console.log("logged");
		console.log(responce);
	});
}

setInterval(call,1000);

console.log(process.env.MICROSOFT_APP_ID);
console.log(process.env.MICROSOFT_APP_PASSWORD);

var connector = new builder.ChatConnector({
	appId: process.env.MICROSOFT_APP_ID,
	appPassword: process.env.MICROSOFT_APP_PASSWORD
});

var bot = new builder.UniversalBot(connector);
server.post('/api/messages', connector.listen());

bot.dialog("/", function (session) {
	session.send("Hello, World!");
})