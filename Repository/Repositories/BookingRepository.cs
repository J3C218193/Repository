﻿using BookingManagementApp.Data;
using BookingManagementApp.Models;
using APBookingManagementAppI.Contracts;

namespace BookingManagementApp.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly BookingManagementDbContext _context;
    //injeksi dependensi
    public BookingRepository(BookingManagementDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Booking> GetAll()
    {
        return _context.Set<Booking>().ToList();
    }

    public Booking? GetByGuid(Guid guid)
    {
        return _context.Set<Booking>().Find(guid);
    }

    public Booking? Create(Booking booking)
    {
        try
        {
            _context.Set<Booking>().Add(booking);
            _context.SaveChanges();
            return booking;
        }
        catch
        {
            return null;
        }
    }

    public bool Update(Booking booking)
    {
        try
        {
            _context.Set<Booking>().Update(booking);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(Booking booking)
    {
        try
        {
            _context.Set<Booking>().Remove(booking);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}