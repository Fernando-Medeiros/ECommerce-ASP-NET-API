# **ECommerce** - ASP.NET - [ API ]

## Dependencies
- Docker Engine ^24.x
- Docker Desktop ^4.x
- Docker Compose  ^v2.x
- Microsoft.NETCore.App 7^
- Microsoft.AspNetCore.App 7^
- Packages -> [pkg ECommerce](../src/ECommerce.csproj) | [pkg ECommerceTests](../tests/ECommerceTests.csproj)

## Current Features

 - [x] **Authentication**:
   - [x] JWT Token [ *Bearer* ]
   - [x] CustomerIdentity
 - [x] **Authorization**:
   - [x] Using Roles [ *manager, employee* ]
   - [x] EmployeeIdentity
 - [x] **Resources**:
   - [x] Customers [ *owner* ]
     - [x] Carts [ *owner* ]
     - [x] Addresses [ *owner* ]
     - Post [ *public* ]  
   - [x] Categories:
     - Get [ *public* ]
     - Post, Patch, Delete [ *manager, employee* ]
   - [x] Products:
     - Get [ *public* ]
     - Post, Patch, Delete [ *manager, employee* ]
   - [x] Sales [ *manager* ]
   - [x] Session [ *public* ]



## Usage
- **Environment** in [env-example](../src/env-example):
  ```sh
    # copy env-example to .env
    # src/
    cp env-example .env
  ```

  ```sh
    PRIVATE_KEY="needs to contain 80 ~ 120"
    TOKEN_EXPIRES=5 # UtcNow + TOKEN_EXPIRES

    DB_HOST=localhost
    DB_NAME=ECommerce
    DB_USER=root
    DB_PASS=12345
  ```

- **Docker** in [.docker](../.docker/docker-compose.yml):
  - Build container with **mysql:latest**
    ```sh
    # rootUser=root / rootPassword=12345 / database=ECommerce
    # .docker/
    docker-compose up -d
    ```
  
  - After uploading the container **create** the first **migration** and update the database
    ```sh
    # src/
    dotnet ef migrations add initial

    dotnet ef database update
    ```

  - To access the instance in the container
    ```sh
    docker exec -it ecommerce-mysql mysql -uroot -p
    # or
    # .docker/
    docker compose exec mysql mysql -uroot -p
    ```

  - To **add** a customer and **make** them an **manager**
    ```sh
    # After uploading the container;
    # Run the project and register a customer;

    # After accessing the mysql instance of the container
    USE ECommerce;
    
    # Update
    UPDATE Customers
    SET Role = 'manager'
    WHERE email = '<CUSTOMER EMAIL>';
    ```

## Entity Relationship Diagram (ERD)

- See:
  - Entities -> [Models](../src/Models)
  - Relationship -> [Database Context](../src/Context/DatabaseContext.cs)
> ERD print 18/08/23

![ERD](ERD-ECommerce.png)