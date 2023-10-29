﻿using Inkwave.Domain.Common;

namespace Inkwave.Domain.Entities;


public class SubDescription: BaseEntity
{
    public string ISBN { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string Edition { get; set; } = string.Empty;
    public string Pages { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string SubCategory { get; set; } = string.Empty;
    public string Tags { get; set; } = string.Empty;
}