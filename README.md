# ABCVendingMachine-WebApi
ABC Vending Machine Web Api
Code Exercise
As the owner of ABC Vending LLC, an application is needed to track the inventory of our
collection of vending machines across the globe. The application will keep track of the products in our
multiple warehouses, as well as each individual vending machine.
Each vending machine will contain multiple categories of products. Each product will have its’
own price. The products will be stored in one of the warehouses owned by ABC Vending in different
parts of the world.
Architecture
 Front End – Angular
 API/Microservice Layer – C#
 Database – Provide an ERD
o The API can return hard-coded data from memory to avoid having to spend time
creating a SQL database

 At least one unit test for the front-end and one for the API is to be provided
User Stories
User Story 1
Given that the managers at each warehouse location need to view the list of inventory in their
warehouse by category
When the user opens the application they should be able to view a list of products in their warehouse by
category and product
Acceptance Criteria
 The Warehouse Inventory interface should display a way to view up-to-date product counts
by category, and by warehouse
User Story 2
Given that a truckload of products leave a given warehouse
When the truck has been loaded the user needs a way to update the inventory of that warehouse and
adjust the number of products accordingly

Acceptance Criteria
 The Warehouse Inventory interface should provide the ability to update total inventory
which should be displayed by total products, categories, and individual product counts. All
the warehouses should be in sync as it comes to product quantities because they are all
stored in a centralized data store.
