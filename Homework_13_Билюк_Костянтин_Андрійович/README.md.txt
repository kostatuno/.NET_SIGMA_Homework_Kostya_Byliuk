# Project Title

Simple overview of use/purpose.
The UKRAINE cinema network. It performs the function of manipulating data such as: halls, movies, users, showtimes and bookings. All the syntax of the project is built on PostgreSQL

## Description

The project works with users who are able to buy reservations for a certain movie. As a result, a reservation object is created, which contains the following information: price, booker, name of the movie, address of the hall and place in it.

## Database structure

### Entities

- User (FirstName,LastName,PhoneNumber)
- Movie (Name, ReleaseYear)
- Hall (Address)

### Connection tables

- Bookings(Booker, Hall, Showtime, Price, MovieName, PositionHall)
- Showtimes(Showtime, Price, MovieName, PositionHall)
- Hall_positions (Needed to store a place in the hall and refer to it (address))

## Authors

Kostya Byliuk