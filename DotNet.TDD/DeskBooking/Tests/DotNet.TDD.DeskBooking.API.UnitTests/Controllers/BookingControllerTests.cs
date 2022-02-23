using AutoFixture;
using DotNet.TDD.DeskBooking.API.Controllers;
using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.Exceptions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace DotNet.TDD.DeskBooking.API.UnitTests.Controllers
{
    public class BookingControllerTests
    {
        [Test]
        public void Add_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();

            var bookingService = Substitute.For<IBookingService>();

            var sut = new BookingController(bookingService);

            // Act
            var result = sut.Add(bookingRequest);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void Add_ValidRequest_ReturnsCorrectId()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();
            var newBookingId = fixture.Create<long>();

            var bookingService = Substitute.For<IBookingService>();
            bookingService
                .Add(Arg.Any<BookingRequest>())
                .Returns(newBookingId);

            var sut = new BookingController(bookingService);

            // Act
            var result = (OkObjectResult) sut.Add(bookingRequest);

            // Assert
            result.Value.Should().Be(newBookingId);
        }

        [Test]
        public void Add_UserOrUserDontExist_ReturnsNotFoundObjectResult()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();

            var bookingService = Substitute.For<IBookingService>();
            bookingService
                .Add(Arg.Any<BookingRequest>())
                .Returns(x => { throw new DataNotFoundException(); });

            var sut = new BookingController(bookingService);

            // Act
            var result = sut.Add(bookingRequest);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Test]
        public void Add_UnableToBook_ReturnsNotFoundObjectResult()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();

            var bookingService = Substitute.For<IBookingService>();
            bookingService
                .Add(Arg.Any<BookingRequest>())
                .Returns(x => { throw new DuplicateDataException(); });

            var sut = new BookingController(bookingService);

            // Act
            var result = sut.Add(bookingRequest);

            // Assert
            result.Should().BeOfType<UnprocessableEntityObjectResult>();
        }
    }
}
