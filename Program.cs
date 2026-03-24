using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;
using APBD_TASK2.Models.Services;

IEquipmentRepository equipmentRepository = new EquipmentRepo();
IUserRepository userRepository = new UserRepository();
IRentalRepository rentalRepository = new RentalRepository();

IEquipmentService equipmentService = new EquipmentService(equipmentRepository);
IUserService userService = new UserService(userRepository);
IRentalService rentalService = new RentalService(rentalRepository, userRepository, equipmentRepository);

// Add users
var student = new User("Anna", "Nowak", UserRole.Student);
var employee = new User("Jan", "Kowalski", UserRole.Employee);

userService.AddUser(student);
userService.AddUser(employee);

// Add equipment
var laptop = new Laptop("MacBook Air", 16, 15);
var camera = new Camera("Nicon", 32, 11);
var projector = new Projector("Sony", 4200, "1920x1080");

equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(camera);
equipmentService.AddEquipment(projector);

// Show all equipment
Console.WriteLine("ALL EQUIPMENT:");
foreach (var equipment in equipmentService.GetAllEquipment())
{
    Console.WriteLine($"{equipment.Id} - {equipment.Name} - {equipment.Status}");
}

Console.WriteLine();

// Correct rental
var rental1 = rentalService.RentEquipment(student.Id, laptop.Id, 7);
Console.WriteLine($"Rental created: user {student.Name} rented {laptop.Name}");

Console.WriteLine();

// Invalid operation: renting unavailable equipment
try
{
    rentalService.RentEquipment(employee.Id, laptop.Id, 3);
}
catch (Exception ex)
{
    Console.WriteLine($"Invalid rental blocked: {ex.Message}");
}

Console.WriteLine();

// Another rentals for student
var rental2 = rentalService.RentEquipment(student.Id, camera.Id, 5);
Console.WriteLine($"Rental created: user {student.Name} rented {camera.Name}");

try
{
    rentalService.RentEquipment(student.Id, projector.Id, 4);
}
catch (Exception ex)
{
    Console.WriteLine($"Limit blocked: {ex.Message}");
}

Console.WriteLine();

// Return on time
rentalService.ReturnEquipment(rental1.Id);
Console.WriteLine($"Rental {rental1.Id} returned. Penalty: {rental1.Penalty}");

Console.WriteLine();

// Create overdue rental manually for demo
var overdueRental = new Rental(employee, projector, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-5));
rentalRepository.Add(overdueRental);
projector.Status = EquipmentStatus.Unavailable;

// Show overdue rentals
Console.WriteLine("OVERDUE RENTALS:");
foreach (var rental in rentalService.GetOverdueRentals())
{
    Console.WriteLine($"Rental {rental.Id}: {rental.User.Name} {rental.User.Surname} -> {rental.Equipment.Name}, due {rental.DueTo}");
}

Console.WriteLine();

// Return overdue rental
rentalService.ReturnEquipment(overdueRental.Id);
Console.WriteLine($"Overdue rental returned. Penalty: {overdueRental.Penalty}");

Console.WriteLine();

// Final report
Console.WriteLine("FINAL REPORT:");
Console.WriteLine(rentalService.GenerateReport());