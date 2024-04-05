using AutoMapper;
using Eng_assessment.Configuration;
using Eng_assessment.Repositories.Interface;
using Eng_assessment.Services;
using Models.Entities.User;
using Models.Entities.User.RequestDTOs;
using Models.Entities.User.ResponseDTOs;
using Moq;

namespace Models
{
    public class UserTests
    {
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfiguration>());
            mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task GetAllUsers_ReturnsEmptyList_WhenRepositoryFindsNoUsers() 
        {

            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<User>());
            
            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            IEnumerable<UserGetDTO> result = await userService.GetAll();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetUserById_ReturnsUser_WhenRepositoryFindsIt()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            User newUser = new User() { Id = 33, Name = "Test User", Active = true };

            userRepositoryMock.Setup(x => x.GetAsync(33, false)).ReturnsAsync(newUser);

            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            UserGetDTO result = await userService.GetById(33);

            Assert.That(result.Id, Is.EqualTo(33));
            Assert.That(result.Name, Is.EqualTo("Test User"));
            Assert.That(result.Active, Is.True);
        }
        [Test]
        public async Task GetUserById_ThrowsKeyNotFoundException_WhenRepositoryFindsNoUser()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(x => x.GetAsync(33, false)).ReturnsAsync((User)null);

            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            Assert.ThrowsAsync<KeyNotFoundException>(() => userService.GetById(33));
        }

        [Test]
        public async Task CreateUser_ReturnsCreatedUser_WhenRepositoryCreatesIt()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            UserCreateDTO newUser = new UserCreateDTO() { Name = "Test User", Active = true };
            User createdUser = new User() { Id = 33, Name = "Test User", Active = true };

            userRepositoryMock.Setup(x => x.AddAsync(It.IsAny<User>())).Callback<User>(x => x.Id = 33);
            userRepositoryMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            User result = await userService.Create(newUser);

            Assert.That(result.Id, Is.EqualTo(33));
            Assert.That(result.Name, Is.EqualTo("Test User"));
            Assert.That(result.Active, Is.True);
        }

        [Test]
        public async Task UpdateUser_ReturnsUpdatedUser_WhenRepositoryUpdatesIt()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            UserUpdateDTO updatedUser = new UserUpdateDTO() {Active = false };
            User existingUser = new User() { Id = 33, Name = "Old User", Active = true };

            userRepositoryMock.Setup(x => x.GetAsync(33, true)).ReturnsAsync(existingUser);
            userRepositoryMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            UserGetDTO result = await userService.Update(33, updatedUser);

            Assert.That(result.Id, Is.EqualTo(33));
            Assert.That(result.Active, Is.False);
        }

        [Test]
        public async Task UpdateUser_ThrowsKeyNotFoundException_WhenRepositoryFindsNoUser()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            UserUpdateDTO updatedUser = new UserUpdateDTO() { Active = false };

            userRepositoryMock.Setup(x => x.GetAsync(33, true)).ReturnsAsync((User)null);

            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            Assert.ThrowsAsync<KeyNotFoundException>(() => userService.Update(33, updatedUser));
        }

        [Test]
        public async Task DeleteUser_DeletesUser_WhenRepositoryDeletesIt()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            User existingUser = new User() { Id = 33, Name = "Old User", Active = true };

            userRepositoryMock.Setup(x => x.GetAsync(33, true)).ReturnsAsync(existingUser);
            userRepositoryMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            await userService.Delete(33);

            userRepositoryMock.Verify(x => x.DeleteAsync(existingUser), Times.Once);
            userRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteUser_ThrowsKeyNotFoundException_WhenRepositoryFindsNoUser()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(x => x.GetAsync(33, true)).ReturnsAsync((User)null);

            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            Assert.ThrowsAsync<KeyNotFoundException>(() => userService.Delete(33));
        }

        [Test]
        public async Task ToggleUserActive_TogglesUserActive_WhenRepositoryFindsIt()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            User existingUser = new User() { Id = 33, Name = "Old User", Active = true };

            userRepositoryMock.Setup(x => x.GetAsync(33, true)).ReturnsAsync(existingUser);
            userRepositoryMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            UserService userService = new UserService(userRepositoryMock.Object, mapper);

            UserGetDTO result = await userService.ToggleUserActiveAsync(33);

            Assert.That(result.Id, Is.EqualTo(33));
            Assert.That(result.Active, Is.False);
        }
    }
}