using AutoFixture;
using DotNet.TDD.DeskBooking.Domain.Entities;
using DotNet.TDD.DeskBooking.Domain.Exceptions;
using DotNet.TDD.DeskBooking.Infrastructure.Context;
using DotNet.TDD.DeskBooking.Infrastructure.Persistance;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System;

namespace DotNet.TDD.DeskBooking.Infrastructure.UnitTests.Persistance
{
    public class BookingPersistanceTests
    {
        [Test]
        public void Add_ValidBookingEntity_ReturnsNewBookingId()
        {
            // Arrange
            var fixture = new Fixture();
            var newBooking = fixture.Create<BookingEntity>();

            var bookings = Substitute.For<DbSet<BookingEntity>>();

            var dbContext = Substitute.For<IDeskBookingContext>();
            dbContext
                .Bookings
                .Returns(bookings);

            var sut = new BookingPersistance(dbContext);

            // Act
            var result = sut.Add(newBooking);

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void Get_IdExists_ReturnsBookingEntity()
        {
            // Arrange
            var bookingId = 5L;

            var fixture = new Fixture();
            var foundBookingEntity = fixture.Create<BookingEntity>();

            var bookings = Substitute.For<DbSet<BookingEntity>>();
            bookings
                .Find(bookingId)
                .Returns(foundBookingEntity);

            var dbContext = Substitute.For<IDeskBookingContext>();
            dbContext
                .Bookings
                .Returns(bookings);

            var sut = new BookingPersistance(dbContext);

            // Act
            var result = sut.Get(bookingId);

            // Assert
            result.Should().BeEquivalentTo(foundBookingEntity);
        }

        [Test]
        public void Get_IdDoesntExist_ThrowsDataNotFoundException()
        {
            // Arrange
            var bookingId = 5L;

            var bookings = Substitute.For<DbSet<BookingEntity>>();
            bookings
                .Find(bookingId)
                .Returns(x => null);
          
            var dbContext = Substitute.For<IDeskBookingContext>();
            dbContext
                .Bookings
                .Returns(bookings);

            var sut = new BookingPersistance(dbContext);

            // Act & Assert
            Action action = () => sut.Get(bookingId);
            action.Should().Throw<DataNotFoundException>();
        }
    }
}
