using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarworkshopRepository _repository;

        public EditCarWorkshopCommandHandler(ICarworkshopRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetByEncodedName(request.Name!);

            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;

            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode;
            carWorkshop.ContactDetails.Street = request.Street;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
