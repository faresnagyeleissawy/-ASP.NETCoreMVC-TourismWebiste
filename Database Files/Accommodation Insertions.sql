-- Insertion Example
INSERT INTO "InterestingPlaceType" ("Type") Values ('Medical');
-- End Of Insertion Example


--
-- Types
--
INSERT INTO "Acctype" ("Type") Values('Hotel');
INSERT INTO "Acctype" ("Type") Values('Resort');
INSERT INTO "Acctype" ("Type") Values('Motel');
/* Accommodation Types IDs ----> 
Hotel = 1
Resort = 2
Motel = 3
*/


--
--Hotels
--
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('The St. Regis Cairo', 'The St. Regis Cairo', 7000, 1, 'Hotel.png', 5, 30.8, 31.1);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('The St. Regis Cairo', 'The St. Regis Cairo', 7000, 1, 'Hotel.png', 5, 30.8, 31.1);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('The St. Regis Cairo', 'The St. Regis Cairo', 7000, 1, 'Hotel.png', 5, 30.8, 31.1);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('The St. Regis Cairo', 'The St. Regis Cairo', 7000, 1, 'Hotel.png', 5, 30.8, 31.1);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('The St. Regis Cairo', 'The St. Regis Cairo', 7000, 1, 'Hotel.png', 5, 30.8, 31.1);
--
--Resorts
--
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Caesar Bay Resort', 'Caesar Bay Resort', 4800, 2, 'Hotel.png', 4, 30.5, 28.3);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Caesar Bay Resort', 'Caesar Bay Resort', 4800, 2, 'Hotel.png', 4, 30.5, 28.3);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Caesar Bay Resort', 'Caesar Bay Resort', 4800, 2, 'Hotel.png', 4, 30.5, 28.3);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Caesar Bay Resort', 'Caesar Bay Resort', 4800, 2, 'Hotel.png', 4, 30.5, 28.3);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Caesar Bay Resort', 'Caesar Bay Resort', 4800, 2, 'Hotel.png', 4, 30.5, 28.3);
--
-- Motels 
--
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Dahab Hostel', 'Dahab Hostel', 2800, 3, 'Hotel.png', 3, 30, 31.2);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Dahab Hostel', 'Dahab Hostel', 2800, 3, 'Hotel.png', 3, 30, 31.2);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Dahab Hostel', 'Dahab Hostel', 2800, 3, 'Hotel.png', 3, 30, 31.2);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Dahab Hostel', 'Dahab Hostel', 2800, 3, 'Hotel.png', 3, 30, 31.2);
Insert INTO "Accommodations" ("Name", "Description", "Price", "TypeId", "Image", "Rate", "X", "Y")
Values ('Dahab Hostel', 'Dahab Hostel', 2800, 3, 'Hotel.png', 3, 30, 31.2);