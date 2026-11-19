using TaskManager.Core.Controllers;
using TaskManager.Core.Models;
using TaskManager.Core.Views;

var context = new TaskContext();
var view = new ViewGenerator();

var controller = new TaskController(context, view);

controller.Run();
