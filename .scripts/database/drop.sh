#!/bin/bash

context=$1

cd App/ECommerceInfrastructure

dotnet ef database drop -c $context