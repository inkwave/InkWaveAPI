﻿namespace Inkwave.Application.Features.Addresses.Commands.UpdateAddress;
public class UpdateAddressCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Governorate { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;


    public string Building { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Apartment { get; set; } = string.Empty;

    public string MarkingPlace { get; set; } = string.Empty;
}

