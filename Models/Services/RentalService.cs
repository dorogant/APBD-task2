using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;

namespace APBD_TASK2.Models.Services;

public class RentalService : IRentalService
{
    private readonly IRentalRepository _rentalRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEquipmentRepository _equipmentRepository;

    private const double PenaltyPerDay = 10.0;

    public RentalService(
        IRentalRepository rentalRepository,
        IUserRepository userRepository,
        IEquipmentRepository equipmentRepository)
    {
        _rentalRepository = rentalRepository;
        _userRepository = userRepository;
        _equipmentRepository = equipmentRepository;
    }

    public Rental RentEquipment(int userId, int equipmentId, int days)
    {
        var user = _userRepository.GetById(userId);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        var equipment = _equipmentRepository.GetById(equipmentId);
        if (equipment == null)
        {
            throw new Exception("Equipment not found.");
        }

        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new Exception("Equipment is not available for rental.");
        }

        int activeRentalsCount = _rentalRepository
            .GetAll()
            .Count(r => r.User.Id == userId && r.Returned == null);

        int limit = user.Role == UserRole.Student ? 2 : 5;

        if (activeRentalsCount >= limit)
        {
            throw new Exception("User has exceeded the active rental limit.");
        }

        var rental = new Rental(
            user,
            equipment,
            DateTime.Now,
            DateTime.Now.AddDays(days)
        );

        equipment.Status = EquipmentStatus.Unavailable;

        _rentalRepository.Add(rental);
        _equipmentRepository.Update(equipment);

        return rental;
    }

    public void ReturnEquipment(int rentalId)
    {
        var rental = _rentalRepository.GetById(rentalId);
        if (rental == null)
        {
            throw new Exception("Rental not found.");
        }

        if (rental.Returned != null)
        {
            throw new Exception("This rental has already been returned.");
        }

        rental.Returned = DateTime.Now;

        if (rental.Returned > rental.DueTo)
        {
            int lateDays = (rental.Returned.Value.Date - rental.DueTo.Date).Days;
            rental.Penalty = lateDays * PenaltyPerDay;
        }

        rental.Equipment.Status = EquipmentStatus.Available;

        _rentalRepository.Update(rental);
        _equipmentRepository.Update(rental.Equipment);
    }

    public List<Rental> GetActiveRentalsForUser(int userId)
    {
        return _rentalRepository
            .GetAll()
            .Where(r => r.User.Id == userId && r.Returned == null)
            .ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentalRepository
            .GetAll()
            .Where(r => r.Returned == null && r.DueTo < DateTime.Now)
            .ToList();
    }

    public string GenerateReport()
    {
        var rentals = _rentalRepository.GetAll();
        var equipments = _equipmentRepository.GetAll();
        var users = _userRepository.GetAll();

        int totalEquipment = equipments.Count;
        int availableEquipment = equipments.Count(e => e.Status == EquipmentStatus.Available);
        int unavailableEquipment = equipments.Count(e => e.Status == EquipmentStatus.Unavailable);
        int activeRentals = rentals.Count(r => r.Returned == null);
        int overdueRentals = rentals.Count(r => r.Returned == null && r.DueTo < DateTime.Now);

        return
            $"Users: {users.Count}\n" +
            $"Equipment total: {totalEquipment}\n" +
            $"Available equipment: {availableEquipment}\n" +
            $"Unavailable equipment: {unavailableEquipment}\n" +
            $"All rentals: {rentals.Count}\n" +
            $"Active rentals: {activeRentals}\n" +
            $"Overdue rentals: {overdueRentals}";
    }
}