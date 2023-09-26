#!/bin/bash

dotnet build App/ECommerceInfrastructure/ --configuration Release

dotnet publish App/ECommerceInfrastructure/ -c Release -o dist

cp App/ECommerceInfrastructure/appsettings.development.json dist/appsettings.development.json

dotnet dist/ECommerceInfrastructure.dll