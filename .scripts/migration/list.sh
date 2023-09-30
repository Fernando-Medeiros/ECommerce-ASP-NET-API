#!/bin/bash

context=$1

cd App/ECommerceInfrastructure

dotnet ef migrations list -c $context