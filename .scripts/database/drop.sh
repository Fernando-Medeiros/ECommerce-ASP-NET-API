#!/bin/bash

context=$1

cd App/ECommerceAPI

dotnet ef database drop -c $context