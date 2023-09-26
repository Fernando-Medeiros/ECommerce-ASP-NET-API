#!/bin/bash

table=$1

docker exec -it ecommerce-postgres psql -U root ECommerce -c 'SELECT COUNT(*) FROM "'$table'";'