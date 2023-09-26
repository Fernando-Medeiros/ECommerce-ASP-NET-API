#!/bin/bash

# Password=root1234

docker exec -it ecommerce-postgres psql -U root ECommerce -c "INSERT INTO \"Customers\" (\"Id\", \"Name\", \"FirstName\", \"LastName\", \"Email\", \"Password\", \"Role\", \"VerifiedOn\", \"UpdatedOn\", \"CreatedOn\")
VALUES (
    '207f419c-a67c-42c0-aa20-1b99b4b37d25', -- Id
    'root', -- Name
    'admin', -- FirstName
    'manager', -- LastName
    'root@mail.com', -- Email
    'd41ca9b3ff93b24da439c32ab28c24fd03220fbee13d3c4650f20125172ae72d', -- Password
    'manager', -- Role
    '2023-09-26 18:28:38+00',  -- VerifiedOn
    '2023-09-26 18:28:38+00', -- UpdatedOn
    '2023-09-26 18:28:38+00' -- CreatedOn
);"
