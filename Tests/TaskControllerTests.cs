using Moq;

namespace Tests;

/* Her bruker vi en nuget pakke som heter Mock
for å hjelpe oss å lage dummydata / mock data for vieweren og contexten vår. */
public class TaskControllerTests
{
    private readonly Mock<TaskContext> _mockContext;
    private readonly Mock<ViewGenerator> _mockView;
    private readonly TaskController _controller;

    public TaskControllerTests()
    {
        _mockContext = new Mock<TaskContext>();
        _mockView = new Mock<ViewGenerator>();
        _controller = new TaskController(_mockContext.Object, _mockView.Object);
    }

    [Fact]
    public void ViewAllTasksCallsRepositoryAndView()
    {
        //Arrange
        List<UserTask> taskList = [
            new Usertask(){1, "Test", "Description", DateTime.Now.AddDays(1)}
        ];
        _mockContext.Setup(context => context.GetAllTasks()).Returns(taskList);

        //Act
        _controller.ViewAllTasks();

        //Assert
        /* Mock kan gjøre ting som å se hvor mange ganger en metode er callet i Act steppet.
        Vi kan dermed verifye at vår context og viewGenerator har kjørt og gjort sitt en gang. */
        _mockContext.Verify(context => context.GetAllTasks(), Times.Once);
        _mockView.Verify(view => view.DisplayTasks(taskList, HeaderOptions.AllTasks), Times.Once);
    }
}