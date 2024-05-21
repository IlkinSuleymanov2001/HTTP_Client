// See https://aka.ms/new-console-template for more information


using HttpTestConsole.Models;
using HttpTestConsole.RequestCreators;

var getReq = new GetRequestCreator();
var models = getReq.GetModelsList();
foreach (var model in models) 
{ 
	Console.WriteLine(model.title);
}


var postReq = new PostRequestCreator();
var createdModel = postReq.PostRequestForCreateModel( new TestModel 
{ 
	userId = 1,
	body = "hello",
	title = "hello"
});

Console.WriteLine(createdModel.id);

Console.ReadKey();