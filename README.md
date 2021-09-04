# RestaurantAPI

## Description
This project is a **.NET 5** implemented Web API for a small restaurant management.
Uses the RESTful api rules and clean architecture.

**RestaurantAPI** enables communication with any database using **Entity Framework Core** consisting of sending and receiving data regarding orders and dishes, the database that is being used is a local sql database.


## Stack
It uses **Entity Framework Core** to communicate with a database, which contains required data tables like:
* Orders - where information about orders are stored 
* Dishes -  where information about dishes are stored

## How to use
* Open the solution and run it.
* You can either use the swagger or postman or any other posting methods to get and post from the api.
* There is the following functionality :
* POST a new dish to the menu(/api/dishes), 
* GET what dishes are on the menu(/api/dishes), 
* GET a dish by id(/api/dishes/{id}), 
* POST a new order(/api/orders), 
* GET all orders(/api/orders) with an option to check orders from the past by adding the amount of days to go back, 
* GET order by id(/api/orders/{id}), 
* PUT a new dish in an order (/api/orders/{orderId}/dishes/{dishId}),
* PUT to change the order paid status from false to true(/api/orders/{orderId}/payment)

