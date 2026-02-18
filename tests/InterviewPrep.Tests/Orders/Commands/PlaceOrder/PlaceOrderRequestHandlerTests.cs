using FluentAssertions;
using InterviewPrep.Application.Orders.Commands.PlaceOrder;
using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure.Repositories.OrderRepository;
using InterviewPrep.Infrastructure.Repositories.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace InterviewPrep.Tests.Orders.Commands.PlaceOrder;

[TestFixture]
public class PlaceOrderRequestHandlerTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private Mock<IOrderRepository> _orderRepositoryMock;
    private PlaceOrderRequestHandler _handler;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _orderRepositoryMock = new Mock<IOrderRepository>();

        _unitOfWorkMock
            .Setup(u => u.Orders)
            .Returns(_orderRepositoryMock.Object);

        _handler = new PlaceOrderRequestHandler(_unitOfWorkMock.Object);
    }

    [Test]
    public async Task Handle_Should_Create_Order_And_Save()
    {
        // Arrange

        var orderLines = new List<OrderLineDto>
        {
            new OrderLineDto(1, 2),
            new OrderLineDto(2, 3)
        };
        var request = new PlaceOrderRequest(orderLines);

        Order? capturedOrder = null;

        _orderRepositoryMock
            .Setup(r => r.AddOrderAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
            .Callback<Order, CancellationToken>((order, _) =>
            {
                capturedOrder = order;

                // simulate DB identity assignment
                order.GetType()
                     .GetProperty("OrderId")!
                     .SetValue(order, 123L);
            })
            .Returns(Task.CompletedTask);

        _unitOfWorkMock
            .Setup(u => u.CommitAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().Be(123L);

        capturedOrder.Should().NotBeNull();
        capturedOrder!.OrderLines.Should().HaveCount(2);

        _orderRepositoryMock.Verify(r =>
            r.AddOrderAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()),
            Times.Once);

        _unitOfWorkMock.Verify(u =>
            u.CommitAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }
}