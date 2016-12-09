
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
