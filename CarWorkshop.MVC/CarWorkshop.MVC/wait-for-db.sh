#!/bin/sh
set -e

HOST=$1
PORT=$2
shift 2   # usuń pierwsze dwa argumenty (host i port)

echo "⏳ Czekam na bazę danych $HOST:$PORT..."
until pg_isready -h $HOST -p $PORT; do
  sleep 2
done

echo "✅ Baza danych dostępna!"
exec "$@"
