Entities represent core objects such as Equipment, User and Rental.

Services contain business logic and coordinate operations like renting, returning and validation.

Repositories provide access to data stored in memory using a Singleton.

Program acts as a controller that calls services and displays results.

Coupling is low because services depend on interfaces and not concrete classes.

Cohesion is high because each class has one clear responsibility.
