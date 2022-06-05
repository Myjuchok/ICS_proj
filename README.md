# The C\# Programming Language University Course 2022

# Project theme - Carpooling
The theme of this year's project will be the creation of an application enabling its users to carry out carpooling.

## Data
We will require at least the following data within the data that will be worked with.

### User
- Name
- Surname
- Photo (URL format)
- (Owned cars)
- (Carpooling from the driver's POV)
- (Carpooling from the rider's POV)

### Ride
- Meeting point (town, location)
- Destination (town, location)
- Time of start
- Estimated end time or estimated travel time
- (Driver)
- (Passengers)
- (Auto)
  
### Auto
- Manufacturer
- Type
- Date of first registration
- Photo
- Number of seats
- (Owner, ie. user)

# Reviews 
## Review from 06.03.2022
### Details of the work performed
- completed work with entities
- finalization of tests

## Review from 10.04.2022
### !!!LEFT TODO:
- ~~fix DbContext build~~
- ~~create migrations based on fixed DbContext~~

## 11.04.2022 01:00 update
Fixed DbContext and Migrations are in a branch [Migrations_with_workingDB](https://dev.azure.com/ics-2022-team0049/project/_git/project?version=GBMigrations_with_workingDB).

### Work performed:
- Models
- Facades
- Tests (including seeds and factories, also facades tests)
- UnitOfWork
- Minor project structure changes
- Review1 fixes 
