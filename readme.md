# Tec Energy Home Project

![CSharp](https://img.shields.io/badge/C%23-v10.0-blue.svg)
![.NET](https://img.shields.io/badge/.NET-v6.0-blue.svg)
![PostgresSQL](https://img.shields.io/badge/Database-PostgresSQL-orange.svg)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](https://opensource.org/licenses/MIT)

## Idea

Download a CSV file from a Website and save it in a database (PostgresSQL).

## ⚡️ Quick start

First, [download](https://www.docker.com) and install docker.

It is recommended to install docker to use the docker compose for all local dependencies.

## 🐳 Running

Type on the root of this repository:

```shell
docker compose up --build
```

That's it! It will up our PostgresSQL instance, run the migration and start the application.

Closing:

```shell
docker compose down
```

## 📁 Project structure

    .
    ├── flyway                   # Tool to perform migrations
    │   └── sql                  # Sql migrations
    │    └──  V1__Initial.sql    # DDL that performs the create table
    ├── DownloadCsvOverHttp      # .NET Console Application (Open this in your IDE if you wanna code)
    │   ├── models               # Models and Enums
    │   ├── repository           # Request to DB and Insertion Query
    │   ├── services             # Service to Download the CSV
    │   ├── DockerFile           # File to create our .NET container
    │   └── Program.cs           # Web App to call other services
    ├── .env                     # Environment variables
    └── docker-compose.yml       # Setup the local infrastructure


## Connecting to Database

You can either use the container provided pgAdmin or another App.


### Locally:

- Go to http://localhost:5050/

```text
Email: admin@admin.com
Password: root
```

![Login PgAdmin](./login.png)

- And for connecting **inside** the container:

```text
Host: db
Port: 5432
Username: postgres
Password: postgres
```

![Server](./server.png)

### Using another tool:

For connections outside the container, use this:

```text
Host: localhost
Port: 5432
Username: postgres
Password: postgres
Database: localdb
```

![Server2](./server2.png)


## Insertion Query

The query performed inside the app is:

```postgresql
INSERT INTO public.operationallyavailablecapacitytw(id, loc, loc_zn, loc_name, loc_purp_desc, loc_qti, flow_ind, dc, opc, tsq, oac, it, auth_overrun_ind, nom_cap_exceed_ind, all_qty_avail, qty_reason)
VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);
```

## Observation

All fields that have a value filled in quantity reason are being ignored and stored in `validatedData.invalid` at `Program.cs`.


## License
[MIT](https://choosealicense.com/licenses/mit/)
