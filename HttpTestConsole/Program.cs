// See https://aka.ms/new-console-template for more information


using HttpTestConsole.Models;
using HttpTestConsole.RequestCreators;


var studentRequest = new StudentGetRequest();
var models = studentRequest.GetStudent(1);
	Console.WriteLine(models);


Console.ReadKey();