using Core.Classes;

namespace App;

class Program
{
    static void Main(string[] args)
    {
        var controller = new TaskController(new TaskContext(), new ViewGenerator());
        controller.Run();
    }
}
