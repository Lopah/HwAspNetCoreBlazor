using HwAspNetCoreBlazor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HwAspNetCoreBlazor.Data
{
    public static class HwAspNetCoreBlazorDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HwAspNetCoreBlazorDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<HwAspNetCoreBlazorDbContext>>()))
            {
                if (context.Rooms.Any()
                    || context.Reservations.Any())
                    return;

                context.Rooms.AddRange(
                    new Room
                    {
                        Name = "UCL1",
                        Description = "AHOJ!",
                        OpeningTimeFrom = 7,
                        OpeningTimeTo = 19,
                        Reservations = new List<Reservation>
                        {
                            new Reservation
                            {
                                ClientEmail = "ClientMail1",
                                ClientName = "ClientName1",
                                ClientSurname = "ClientSurname1",
                                ClientPhone = "+420 123 123 123",
                                ReservationDateTime = DateTime.Now.AddDays(-2),
                                Notes = "testNote1"
                            },
                            new Reservation
                            {
                                ClientEmail = "ClientMail2",
                                ClientName = "ClientName2",
                                ClientSurname = "ClientSurname2",
                                ClientPhone = "+420 123 456 123",
                                ReservationDateTime = DateTime.Now.AddDays(-3),
                                Notes = "testNote2"
                            }
                        }
                    },
                    new Room
                    {
                        Name = "UCL2",
                        Description = "AHOJ!!",
                        OpeningTimeFrom = 8,
                        OpeningTimeTo = 20,
                        Reservations = new List<Reservation>
                        {
                            new Reservation
                            {
                                ClientEmail = "ClientMail3",
                                ClientName = "ClientName3",
                                ClientSurname = "ClientSurname3",
                                ClientPhone = "+420 123 123 123",
                                ReservationDateTime = DateTime.Now.AddDays(2),
                                Notes = "testNote3"
                            },
                            new Reservation
                            {
                                ClientEmail = "ClientMail4",
                                ClientName = "ClientName4",
                                ClientSurname = "ClientSurname4",
                                ClientPhone = "+420 123 456 123",
                                ReservationDateTime = DateTime.Now.AddDays(10),
                                Notes = "testNote4"
                            }
                        }
                    });
            }
        }
    }
}
