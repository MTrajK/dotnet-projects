using AutoFixture;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;
using DotNet.TDD.DeskBooking.Domain.Entities;
using DotNet.TDD.DeskBooking.Domain.Mappings;
using FluentAssertions;
using NUnit.Framework;

namespace DotNet.TDD.DeskBooking.Domain.UnitTests.Mappings
{
    public class BookingMappingTests
    {
        [Test]
        public void ToEntity_ValidBookingRequestObject_ReturnsBookingEntityObject()
        {
            // Assert
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();
            var bookingEntity = new BookingEntity()
            {
                DeskId = bookingRequest.DeskId,
                EmployeeId = bookingRequest.EmployeeId,
                Date = bookingRequest.Date.Date
            };

            // Act
            var result = bookingRequest.ToEntity();

            // Assert
            result.Should().BeEquivalentTo(bookingEntity);
        }

        [Test]
        public void ToResponse_ValidBookingEntityObject_ReturnsBookingResponseObject()
        {
            // Assert
            var fixture = new Fixture();
            var bookingEntity = fixture.Create<BookingEntity>();
            var bookingResponse = new BookingResponse()
            {
                Id = bookingEntity.Id,
                DeskId = bookingEntity.DeskId,
                EmployeeId = bookingEntity.EmployeeId,
                Date = bookingEntity.Date
            };

            // Act
            var result = bookingEntity.ToResponse();

            // Assert
            result.Should().BeEquivalentTo(bookingResponse);
        }
    }
}
