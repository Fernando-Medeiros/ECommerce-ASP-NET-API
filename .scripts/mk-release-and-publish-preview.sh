#!/bin/bash

dotnet build App/ECommerceAPI/ --configuration Release

dotnet publish App/ECommerceAPI/ -c Release -o dist

cp App/ECommerceAPI/appsettings.development.json dist/appsettings.development.json

dotnet dist/ECommerceAPI.dll