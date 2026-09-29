using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Validation;

namespace NestedValidation.Models;

[ValidatableType]
public sealed class Order
{
    public ShippingAddress ShippingAddress { get; set; } = new();
}

public sealed class ShippingAddress
{
    [Required(ErrorMessage = "Street is required.")]
    public string? Street { get; set; }
}
