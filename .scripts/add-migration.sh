#!/bin/bash

name=$1

cd App/ECommerceInfrastructure

dotnet ef migrations add $name -o Persistence/Migrations