FROM mysql:latest

ENV MYSQL_ROOT_PASSWORD=password

COPY ./Util/ /docker-entrypoint-initdb.d/ 