﻿using BookingManagementApp.Data;
using BookingManagementApp.Models;
using APBookingManagementAppI.Contracts;

namespace BookingManagementApp.Repositories;

public class EducationRepository : IEducationRepository
{
    private readonly BookingManagementDbContext _context;
    //injeksi dependensi
    public EducationRepository(BookingManagementDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Education> GetAll()
    {
        return _context.Set<Education>().ToList();
    }

    public Education? GetByGuid(Guid guid)
    {
        return _context.Set<Education>().Find(guid);
    }

    public Education? Create(Education education)
    {
        try
        {
            _context.Set<Education>().Add(education);
            _context.SaveChanges();
            return education;
        }
        catch
        {
            return null;
        }
    }

    public bool Update(Education education)
    {
        try
        {
            _context.Set<Education>().Update(education);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(Education education)
    {
        try
        {
            _context.Set<Education>().Remove(education);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}