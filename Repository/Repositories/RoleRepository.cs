﻿using BookingManagementApp.Data;
using BookingManagementApp.Models;
using APBookingManagementAppI.Contracts;

namespace BookingManagementApp.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly BookingManagementDbContext _context;
    //injeksi dependensi
    public RoleRepository(BookingManagementDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Role> GetAll()
    {
        return _context.Set<Role>().ToList();
    }

    public Role? GetByGuid(Guid guid)
    {
        return _context.Set<Role>().Find(guid);
    }

    public Role? Create(Role role)
    {
        try
        {
            _context.Set<Role>().Add(role);
            _context.SaveChanges();
            return role;
        }
        catch
        {
            return null;
        }
    }

    public bool Update(Role role)
    {
        try
        {
            _context.Set<Role>().Update(role);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(Role role)
    {
        try
        {
            _context.Set<Role>().Remove(role);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}