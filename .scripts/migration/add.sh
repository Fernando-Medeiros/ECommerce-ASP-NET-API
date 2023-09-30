#!/bin/bash

name=$1
context=$2

cd App/ECommerceInfrastructure

dotnet ef migrations add $name -o Persistence/Migrations/"$context"Migrations -c $context