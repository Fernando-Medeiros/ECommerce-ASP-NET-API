#!/bin/bash

name=$1
context=$2

cd App/ECommerceInfrastructure

dotnet ef migrations add $name -o Migrations/"$context"Migrations -c $context