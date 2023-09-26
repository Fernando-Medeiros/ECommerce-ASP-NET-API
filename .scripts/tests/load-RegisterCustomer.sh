#!/bin/bash

URL="http://localhost:5000/api/v1/customers"
DEFAULT_TOTAL_REQUESTS=500
TIMEOUT_SECONDS=10

STATS_FILE=$(mktemp)

start_time=$SECONDS

make_request() {
    local name="example"
    local firstName="firstname"
    local lastName="lastname"
    local email="$RANDOM.$RANDOM@mail.com"
    local password="password123"

    local payload=$(< <(cat <<EOF
{
  "name": "$name",
  "firstName": "$firstName",
  "lastName": "$lastName",
  "email": "$email",
  "password": "$password"
}
EOF
    ))

    local request_start_time=$(date +%s%N)

    local response=$(timeout $TIMEOUT_SECONDS curl -s -o /dev/null -w "%{http_code}" -X POST -H "Content-Type: application/json" -d "$payload" "$URL")

    local request_end_time=$(date +%s%N)
    local request_duration_ns=$((request_end_time - request_start_time))
    local request_duration_ms=$((request_duration_ns / 1000000))

    echo "$response $request_duration_ms" >> $STATS_FILE
}

print_statistics() {
    SUCCESSFUL_REQUESTS=0
    FAILED_REQUESTS=0
    MAX_REQUEST_TIME=0
    MIN_REQUEST_TIME=999999999999999999
    SUM_REQUEST_TIMES=0

    while read response request_duration_ms; do
        SUM_REQUEST_TIMES=$((SUM_REQUEST_TIMES + request_duration_ms))

        if [ "$request_duration_ms" -gt "$MAX_REQUEST_TIME" ]; then
            MAX_REQUEST_TIME=$request_duration_ms      
        fi

        if [ "$request_duration_ms" -lt "$MIN_REQUEST_TIME" ]; then
            MIN_REQUEST_TIME=$request_duration_ms     
        fi

        if [ "$response" -eq 201 ]; then
            SUCCESSFUL_REQUESTS=$((SUCCESSFUL_REQUESTS + 1))     
        else
            FAILED_REQUESTS=$((FAILED_REQUESTS + 1))
        fi
    done < $STATS_FILE

    AVERAGE_REQUEST_TIME=0
    
    if [ "$TOTAL_REQUESTS" -gt 0 ]; then
        AVERAGE_REQUEST_TIME=$(bc -l <<< "scale=2; $SUM_REQUEST_TIMES / $TOTAL_REQUESTS")
    fi

    ELAPSED_TIME=$((SECONDS - start_time))

    echo -e "\n\n----------------------------------------------------------------------"
    echo "Tempo total de execução do script: $ELAPSED_TIME segundos."
    echo "Tempo médio de requisição: $AVERAGE_REQUEST_TIME milissegundos."
    echo "Tempo mínimo de requisição: $MIN_REQUEST_TIME milissegundos."
    echo "Tempo máximo de requisição: $MAX_REQUEST_TIME milissegundos."
    echo "Total de requisições bem sucedidas: $SUCCESSFUL_REQUESTS"
    echo "Total de requisições mal sucedidas: $FAILED_REQUESTS"
    
    if [ "$TOTAL_REQUESTS" -gt 0 ]; then
        echo "Porcentagem de requisições bem sucedidas: $(bc -l <<< "scale=2; ($SUCCESSFUL_REQUESTS / $TOTAL_REQUESTS) * 100")%"
    else
        echo "Porcentagem de requisições bem sucedidas: 0%"
    fi
    echo "----------------------------------------------------------------------"
}


echo "Informe o número de solicitações a serem feitas (ou pressione Enter para usar $DEFAULT_TOTAL_REQUESTS):"
read user_total_requests
TOTAL_REQUESTS=${user_total_requests:-$DEFAULT_TOTAL_REQUESTS}

echo "Iniciando $TOTAL_REQUESTS solicitações para $URL com um limite de tempo de $TIMEOUT_SECONDS segundos por solicitação"
echo "Progresso:"

for ((i = 1; i <= TOTAL_REQUESTS; i++)); do
    make_request &
    
    while (( $(jobs -r | wc -l) >= 8 )); do 
        sleep 0.1; 
    done
done

wait 

print_statistics

rm $STATS_FILE