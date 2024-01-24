using RentCar.Application.Abstraction.Validators;
using RentCar.Infrastructure.Data;

namespace RentCar.Application.Payment.Validators;

public sealed class PaymentIdValidator(ApplicationDbContext context)
    : IdValidator<Core.Entities.Vehicle>(context, "SELECT Id FROM Payments WHERE Id = {0}");
