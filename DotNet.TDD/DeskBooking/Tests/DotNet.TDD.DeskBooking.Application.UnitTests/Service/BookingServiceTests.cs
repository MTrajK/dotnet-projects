using AutoFixture;
using DotNet.TDD.DeskBooking.Application.Service;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.Entities;
using DotNet.TDD.DeskBooking.Domain.Exceptions;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;

namespace DotNet.TDD.DeskBooking.Application.UnitTests.Service
{
    public class BookingServiceTests
    {
        [Test]
        public void Add_EmployeeDoesntExist_ThrowsDataNotFoundException()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();

            var employeePersistance = Substitute.For<IEmployeePersistance>();
            employeePersistance
                .Get(bookingRequest.EmployeeId)
                .Returns(x => { throw new DataNotFoundException(); });
            var deskPersistance = Substitute.For<IDeskPersistance>();
            var bookingPersistance = Substitute.For<IBookingPersistance>();

            var sut = new BookingService(employeePersistance, deskPersistance, bookingPersistance);

            // Act & Arrange
            Action action = () => sut.Add(bookingRequest);
            action.Should().Throw<DataNotFoundException>();
        }

        [Test]
        public void Add_DeskDoesntExist_ThrowsDataNotFoundException()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();

            var employeePersistance = Substitute.For<IEmployeePersistance>();
            var deskPersistance = Substitute.For<IDeskPersistance>();
            deskPersistance
                .Get(bookingRequest.DeskId)
                .Returns(x => { throw new DataNotFoundException(); });
            var bookingPersistance = Substitute.For<IBookingPersistance>();

            var sut = new BookingService(employeePersistance, deskPersistance, bookingPersistance);

            // Act & Arrange
            Action action = () => sut.Add(bookingRequest);
            action.Should().Throw<DataNotFoundException>();
        }

        [Test]
        public void Add_CheckIfEmployeeHasBookingOnDate_ThrowsDataNotFoundException()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();

            var employeePersistance = Substitute.For<IEmployeePersistance>();
            var deskPersistance = Substitute.For<IDeskPersistance>();
            var bookingPersistance = Substitute.For<IBookingPersistance>();
            bookingPersistance
                .CheckIfEmployeeHasBookingOnDate(bookingRequest.EmployeeId, Arg.Is<DateTime>(d => DateTime.Compare(d, bookingRequest.Date.Date) == 0))
                .Returns(true);

            var sut = new BookingService(employeePersistance, deskPersistance, bookingPersistance);

            // Act & Arrange
            Action action = () => sut.Add(bookingRequest);
            action.Should().Throw<DuplicateDataException>();
        }

        [Test]
        public void Add_DeskFullCapacity_ThrowsDataNotFoundException()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();
            var deskEntity = fixture.Create<DeskEntity>();
            deskEntity.Capacity = 4;

            var employeePersistance = Substitute.For<IEmployeePersistance>();
            var deskPersistance = Substitute.For<IDeskPersistance>();
            deskPersistance
                .Get(bookingRequest.DeskId)
                .Returns(deskEntity);
            var bookingPersistance = Substitute.For<IBookingPersistance>();
            bookingPersistance
                .CheckIfEmployeeHasBookingOnDate(bookingRequest.EmployeeId, Arg.Is<DateTime>(d => DateTime.Compare(d, bookingRequest.Date.Date) == 0))
                .Returns(false);
            bookingPersistance
                .NumberOfBookingsForDeskOnDate(bookingRequest.DeskId, Arg.Is<DateTime>(d => DateTime.Compare(d, bookingRequest.Date.Date) == 0))
                .Returns(deskEntity.Capacity);

            var sut = new BookingService(employeePersistance, deskPersistance, bookingPersistance);

            // Act & Arrange
            Action action = () => sut.Add(bookingRequest);
            action.Should().Throw<DuplicateDataException>();
        }

        [Test]
        public void Add_ValidBooking_ReturnsBookingId()
        {
            // Arrange
            var fixture = new Fixture();
            var bookingRequest = fixture.Create<BookingRequest>();
            var deskEntity = fixture.Create<DeskEntity>();
            deskEntity.Capacity = 4;
            var newBookingId = 5;

            var employeePersistance = Substitute.For<IEmployeePersistance>();
            var deskPersistance = Substitute.For<IDeskPersistance>();
            deskPersistance
                .Get(bookingRequest.DeskId)
                .Returns(deskEntity);
            var bookingPersistance = Substitute.For<IBookingPersistance>();
            bookingPersistance
                .CheckIfEmployeeHasBookingOnDate(bookingRequest.EmployeeId, Arg.Is<DateTime>(d => DateTime.Compare(d, bookingRequest.Date.Date) == 0))
                .Returns(false);
            bookingPersistance
                .NumberOfBookingsForDeskOnDate(bookingRequest.DeskId, Arg.Is<DateTime>(d => DateTime.Compare(d, bookingRequest.Date.Date) == 0))
                .Returns(deskEntity.Capacity - 1);
            bookingPersistance
                .Add(Arg.Any<BookingEntity>())
                .Returns(newBookingId);

            var sut = new BookingService(employeePersistance, deskPersistance, bookingPersistance);

            // Act
            var result = sut.Add(bookingRequest);

            // Arrange
            result.Should().Be(newBookingId);
        }
    }
}
