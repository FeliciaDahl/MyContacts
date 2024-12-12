﻿
using Business.Entites;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;

public static class ContactEntityFactory
{
    
    public static ContactEntity Create(ContactModel contact, IGenerateUniqeId generateId)
    {
        return new ContactEntity
        {
            Id = generateId.GenerateId(),
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            Phone = contact.Phone,
            Address = contact.Address,
            PostalCode = contact.PostalCode,
            City = contact.City,
            CreatedDate = DateTime.Now
        };
    }

    public static ContactModel Create(ContactEntity entity)
    {
        return new ContactModel
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            Address = entity.Address,
            PostalCode = entity.PostalCode,
            City = entity.City
        };
    }
}
