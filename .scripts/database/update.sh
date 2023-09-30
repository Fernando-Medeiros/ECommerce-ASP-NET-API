#!/bin/bash

context=$1

cd App/ECommerceInfrastructure

dotnet ef database update -c $context