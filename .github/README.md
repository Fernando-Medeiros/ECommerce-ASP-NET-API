# ASP.NET - REST API

| name                                            | version | optional |
| :---------------------------------------------- | :-----: | :------: |
| Docker Desktop                                  |   ^4    |          |
| Docker Compose                                  |   ^2    |          |
| Microsoft.NETCore.App                           |   ^7    |          |
| Microsoft.AspNetCore.App                        |   ^7    |          |
| Dotnet EF                                       |   ^7    |          |
| VSCode [extensions](../.vscode/extensions.json) |  1.8^   |    x     |

---

```sh
# Bash or Git Bash
find ./.scripts -type f -name "*.sh" -exec chmod +x {} \;
```

```sh
dotnet tool install --global dotnet-ef
```

---


> Authentication
- JWT Token [ *Bearer* ]
- JWT Token Scope [ *Access, Refresh, RecoverPassword, AuthenticateEmail* ]
- CustomerIdentity

> Authorization
- Role [ *Customer, Manager, Employee* ]
- EmployeeIdentity

---

> Routes
- Auth
  - auth/email {**POST**, token: Authenticate, body: null}
  - auth/token {**POST**, token: null, body: SignInRequest}
- Customer
  - customer {**GET**, token: Access, body: null}
  - customer {**DELETE**, token: Access, body: null}
  - customer {**POST**, token: null, body: CustomerRequest}
  - customer {**PATCH**, token: Access, body: UpdateCustomerName}
  - customer/address {**POST**, token: Access, body: AddressRequest}
  - customer/address {**GET all**, token: Access, body: null}
  - customer/address/{id} {**GET, DELETE**, token: Access, body: null}
  - customer/address/{id} {**PATCH**, token: Access, body: AddressRequest}
- Password
  - password {**PATCH**, token: Access, body: PasswordRequest}
  - password/reset {**PATCH**, token: Recover, body: PasswordRequest}
  - password/recover {**POST**, token: null, body: EmailRequest}

---

[appsettings.development.Example](../App/ECommerceAPI/appsettings.development.Example)

```sh
  # copy appsettings.development.Example to appsettings.development.json
  cp App/ECommerceAPI/appsettings.development.Example App/ECommerceAPI/appsettings.development.json

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
  MAIL_USER=< !! E-MAIL !! >
  MAIL_PASS=< !! PASSWORD !! >
  DB_DEFAULT_CONNECTION="Server=localhost;Database=ECommerce;UserId=root;Password=12345;"
```

---

- Docker [.docker-compose](../.docker/postgres/docker-compose.yml)
  ```sh
    .scripts/up-docker-compose.sh
  ```

- Migration :: Create
  ```sh
    .scripts/migration/add.sh < Name > < Context >
  ```

- Migration :: Remove Last
  ```sh
    .scripts/migration/remove.sh < Context >
  ```

- Migration :: List
  ```sh
    .scripts/migration/list.sh  < Context >
  ```

- Database :: Update
  ```sh
  .scripts/database/update.sh < Context >
  ```

- Database :: Drop
  ```sh
  .scripts/database/drop.sh < Context >
  ```

- Database :: Select all
  ```sh
  .scripts/cmd/select-table.sh < Name >
  ```

- Database :: Count
  ```sh
  .scripts/cmd/count-table.sh < Name >
  ```

- Database :: Truncate
  ```sh
  .scripts/cmd/truncate-table.sh < Name >
  ```

- Test :: Register Customers
  ```sh
  .scripts/tests/load-RegisterCustomer.sh
  ```

- Create and Publish :: Release Preview
  ```sh
  .scripts/mk-release-and-publish-preview.sh
  ```

- **ROOT USER**
  ```sh
  .scripts/add-database-root-user.sh
  ```

---


- Entities -> [Models](../App/ECommercePersistence/Model)
- Relationship -> [Database Context](../App/ECommercePersistence/Context/DatabaseContext.cs)
> ERD print 04/09/23

![ERD](ERD-ECommerce.png)