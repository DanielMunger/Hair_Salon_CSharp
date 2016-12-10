
| Behavior                                                                                                | Input                                    | Output                                   |
|---------------------------------------------------------------------------------------------------------|------------------------------------------|------------------------------------------|
| The application has an empty database with two separate tables.                                         | null                                     | null                                     |
| The application is able t o save a Stylist to the Stylist table, and confirm that the object was saved.  | "Jim"                                    | "Jim"                                    |
| The application shows a list of all Stylists and their information                                      | 'Show Stylists'                          | "Jim" , "Jimbo", "Jimmy" , "Gym"         |
| The application finds a specific Stylist.                                                               | "Jim"                                    | "Jim"                                    |
| The application allows the user to edit information about a specific Stylist. Including adding Clients. | Stylist: "Jim" Clients: "Nancy", "Drew"  | Stylist: "Jimbo" Clients: "Billy", "Bob" |
| A user can edit information for a specific Client.                                                      | Client: "Mary"                           | Client: "Maury"                          |
| A user can delete a Stylist from the database.                                                          | Stylist: "Jimbo" Clients: "Billy", "Bob" | null                                     |
| A user can delete a Client from the database.                                                           | Client: "Mary"                           | null      



# _{Hair Salon}_

#### _{Creates Database for Hair Salon }, {12/9/2016}_

#### By _**{Daniel Munger}**_

## Description

_{This application is hosted on a local server and uses a local database to store user information. The user inputs information about a Hair Salon. The program takes the inputted information, adds it to a local database, and then displays it on the website. The user is able to modify information which actively changes the database. The program meets the defined specifications above.}_


## Setup/Installation Requirements

  * _Clone this program from my GitHub_
  * _Run 'dnu restore' to create a project.lock.json file_
  ** Using MSSM
  * Instructions in SQL:
  * CREATE DATABASE hair_salon;
  *  GO
  * USE hair_salon;
  * GO
  * CREATE TABLE stylists
  * (id INT IDENTITY(1,1), stylist_name VARCHAR(50),
  * work_hours VARCHAR(50),
  * days_of_week VARCHAR(100));
  * CREATE TABLE clients
  * (id INT IDENTITY(1,1),
  * client_name VARCHAR(50),
  * stylist_id INT);
  * GO
  * _Run 'dnx kestrel' to start server_
  * _Open the webpage 'localhost:5004'_
  * _Follow website instructions_


## Known Bugs

_{There are no known bugs at this time.}_

## Technologies Used

_{Written in Atom in C#, complied using MicroSoft PowerShell, uses Microsoft SQl Server Management Studio}_

### License

*{ This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.}*

Copyright (c) 2016 **_{Daniel Munger}_*
