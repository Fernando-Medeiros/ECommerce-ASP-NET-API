#!/bin/bash

context=$1

cd App/ECommerceAPI

dotnet ef migrations list -c $context