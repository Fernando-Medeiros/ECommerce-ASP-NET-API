# ECommerce-ASP-NET-API

- [ECommerce-ASP-NET-API](#ecommerce-asp-net-api)
  - [Requirements](#requirements)
  - [Features](#features)
      - [Auth](#auth)
      - [Customer](#customer)
      - [CustomerCart \&  CustomerAddress](#customercart---customeraddress)
      - [CustomerPassword](#customerpassword)
      - [Products](#products)
      - [ProductCategory](#productcategory)
      - [Sales](#sales)
  - [DBOptions](#dboptions)
  - [Usage](#usage)
    - [Environment](#environment)
    - [Docker](#docker)
        - [MySQL or Postgres](#mysql-or-postgres)
        - [Create the first migration](#create-the-first-migration)
        - [Update Database](#update-database)
        - [To access the MySQL instance](#to-access-the-mysql-instance)
        - [To access the Postgres instance](#to-access-the-postgres-instance)
        - [Change a customer to a Manager](#change-a-customer-to-a-manager)
  - [Entity Relationship Diagram (ERD)](#entity-relationship-diagram-erd)


## Requirements
| name                                                     | version | optional |
| :------------------------------------------------------- | :-----: | :------: |
| Docker Engine                                            |   ^24   |          |
| Docker Desktop                                           |   ^4    |          |
| Docker Compose                                           |   ^2    |          |
| Microsoft.NETCore.App                                    |   ^7    |          |
| Microsoft.AspNetCore.App                                 |   ^7    |          |
| Dotnet EF                                                |   ^7    |          |
| VSCode [ex. recommendations](../.vscode/extensions.json) |  1.8^   |    x     |

## Features

> Authentication
- [x] JWT Token [ *Bearer* ]
- [x] JWT Token Scope [ *Access, Refresh, RecoverPassword, AuthenticateEmail* ]
- [x] CustomerIdentity

> Authorization
- [x] Using Roles [ *manager, employee* ]
- [x] EmployeeIdentity

> Resources

#### Auth 
| method |     name     | public |    tokenScope     |
| :----- | :----------: | :----: | :---------------: |
| Post   |    SignIn    |   x    |                   |
| Post   | Authenticate |        | AuthenticateEmail |

#### Customer 
| method | owner | public |
| :----- | :---: | :----: |
| Get    |   x   |        |
| Post   |       |   x    |
| Patch  |   x   |        |
| Delete |   x   |        |

#### CustomerCart &  CustomerAddress 
| method | owner |
| :----- | :---: |
| Get    |   x   |
| Post   |   x   |
| Patch  |   x   |
| Delete |   x   |

#### CustomerPassword
| method | name    | public |   tokenScope    |
| :----- | :------ | :----: | :-------------: |
| Post   | Recover |   x    |                 |
| Patch  | Reset   |        | RecoverPassword |
| Patch  | Update  |        | Access, Refresh |

#### Products
| method | public | manager | employee |
| :----- | :----: | :-----: | :------: |
| Get    |   x    |         |          |
| Post   |        |    x    |    x     |
| Patch  |        |    x    |    x     |
| Delete |        |    x    |    x     |

#### ProductCategory
| method | public | manager | employee |
| :----- | :----: | :-----: | :------: |
| Get    |   x    |         |          |
| Post   |        |    x    |    x     |
| Patch  |        |    x    |    x     |
| Delete |        |    x    |    x     |

#### Sales
| method | public | manager | employee |
| :----- | :----: | :-----: | :------: |
| Get    |        |    x    |          |
| Post   |        |    x    |          |
| Patch  |        |    x    |          |
| Delete |        |    x    |          |


## DBOptions

```xml
# Postgres
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="7^" />
# Mysql
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="7^" />
```

## Usage

> dotnet tool install --global dotnet-ef

### Environment

[appsettings.development.Example](../src/appsettings.development.Example)

```sh
  # copy appsettings.development.Example to appsettings.development.json
  # src/
  cp appsettings.development.Example appsettings.development.json
```

```sh
  PRIVATE_KEY="needs to contain 80 ~ 120"
  
  URL_AUTH_EMAIL=< Frontend To Receive Token > # url/ <-token AuthenticateEmail
  URL_RESET_PASS=< Frontend To Receive Token > # url/ <-token RecoverPassword

  TOKEN_ACCESS_EXP=12
  TOKEN_REFRESH_EXP=6
  TOKEN_RECOVER_PASS_EXP=0.10 # UtcNow.AddHours(0.10) += 5 minutes
  TOKEN_AUTH_EMAIL_EXP=6

  MAIL_HOST=smtp.gmail.com
  MAIL_PORT=587
  MAIL_ENCRYPTION=true
  MAIL_FROM_NAME=ECommerce
  MAIL_FROM_ADDRESS=noreply@ecommerce.com
  MAIL_USER=< !! YOUR GMAIL !! >
  MAIL_PASS=< !! YOUR SECRET_PASSWORD !! >
  DB_DEFAULT_CONNECTION="Server=localhost;Database=ECommerce;UserId=root;Password=12345;"
```

### Docker

[.docker](../.docker/docker-compose.yml)

##### MySQL or Postgres
  ```sh
  # cd .docker/mysql/
  docker-compose up -d
  # cd .docker/postgres/
  docker-compose up -d
  ```

##### Create the first migration
  ```sh
  # cd src/
  dotnet ef migrations add initial
  ```

##### Update Database
  ```sh
  # cd src/
  dotnet ef database update
  ```

##### To access the MySQL instance
  ```sh
  docker exec -it ecommerce-mysql mysql -uroot -p
  # or
  # cd .docker/mysql/
  docker compose exec mysql mysql -uroot -p
  ```

##### To access the Postgres instance
  ```sh
  docker exec -it ecommerce-postgres psql -U root ECommerce
  # or
  # cd .docker/postgres/
  docker compose exec postgres psql -U root ECommerce
  ```

##### Change a customer to a Manager
  ```sh
  # Run the project and register a customer;
  # After accessing the mysql or postgres instance
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
> ERD print 24/08/23

![ERD](ERD-ECommerce.png)