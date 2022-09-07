﻿using Core.Entities.Abstract;

namespace Entities.DTOs;

public class ProductDetailDto:IDto
{
    public int ProductId { get; set; }
    public string? CategoryName { get; set; }
    public string? ProductName { get; set; }
    public short UnitsInStock { get; set; }
}