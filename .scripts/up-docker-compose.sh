#!/bin/bash

dirs=(".docker/postgres" ".docker/redis")

for dir in "${dirs[@]}"; do
    if [ -d "$dir" ]; then
        echo "Start command at $dir"
        cd $dir && docker-compose up -d && cd -
    else
        echo "Directory $dir not found"
    fi
done
