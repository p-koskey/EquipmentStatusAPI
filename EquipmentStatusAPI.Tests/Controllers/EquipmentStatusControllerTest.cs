using EquipmentStatusAPI.Controllers;
using EquipmentStatusAPI.DTOs;
using EquipmentStatusAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EquipmentStatusAPI.Tests.Controllers;

public class EquipmentStatusControllerTest
{
    [Fact]
    public async Task PostEquipmentStatus_ValidInput_ReturnsOkResult()
    {
        // Arrange
        var mockService = new Mock<IEquipmentStatusService>();
        var controller = new EquipmentStatusController(mockService.Object);
        var statusDto = new EquipmentStatusCreateDto
        {
            EquipmentId = "eqp123",
            Status = 1
        };

        var responseDto = new EquipmentStatusDto
        {
            EquipmentId = "eqp123",
            Status = 1,
            StatusDescription = "Running"
        };

        mockService.Setup(s => s.AddStatusAsync(statusDto)).ReturnsAsync(responseDto);

        // Act
        var result = await controller.Status(statusDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<EquipmentStatusDto>(okResult.Value);
        Assert.Equal(responseDto.EquipmentId, returnValue.EquipmentId);
        Assert.Equal(responseDto.Status, returnValue.Status);
        Assert.Equal(responseDto.StatusDescription, returnValue.StatusDescription);

    }
    
    [Fact]
    public async Task PostStatus_InvalidEquipmentId_ReturnsBadRequest()
    {
        // Arrange
        var mockService = new Mock<IEquipmentStatusService>();
        var controller = new EquipmentStatusController(mockService.Object);
        var statusDto = new EquipmentStatusCreateDto
        {
            EquipmentId = "", // invalid input
            Status = 1
        };
    
        // Act
        var result = await controller.Status(statusDto);
    
        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
    
    [Fact]
    public async Task PostStatus_InvalidStatus_ReturnsBadRequest()
    {
        // Arrange
        var mockService = new Mock<IEquipmentStatusService>();
        var controller = new EquipmentStatusController(mockService.Object);
        var statusDto = new EquipmentStatusCreateDto
        {
            EquipmentId = "eqp005", // invalid input
            Status = 100
        };
    
        // Act
        var result = await controller.Status(statusDto);
    
        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
    
    [Fact]
    public async Task GetStatus_ValidEquipmentId_ReturnsOkResult()
    {
        // Arrange
        var mockService = new Mock<IEquipmentStatusService>();
        var controller = new EquipmentStatusController(mockService.Object);
        var equipmentId = "eqp123";
        var responseDto = new EquipmentStatusDto
        {
            EquipmentId = equipmentId,
            Status = 1,
            StatusDescription = "Running"
        };
    
        mockService.Setup(s => s.GetCurrentStatusAsync(equipmentId)).ReturnsAsync(responseDto);
    
        // Act
        var result = await controller.GetStatus(equipmentId);
    
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<EquipmentStatusDto>(okResult.Value);
        Assert.Equal(responseDto.EquipmentId, returnValue.EquipmentId);
        Assert.Equal(responseDto.Status, returnValue.Status);
        Assert.Equal(responseDto.StatusDescription, returnValue.StatusDescription);
    }
    
    [Fact]
    public async Task GetStatus_InvalidEquipmentId_ReturnsNotFound()
    {
        // Arrange
        var mockService = new Mock<IEquipmentStatusService>();
        var controller = new EquipmentStatusController(mockService.Object);
        var equipmentId = "invalidId";
        
        // Act
        var result = await controller.GetStatus(equipmentId);
    
        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }
}
