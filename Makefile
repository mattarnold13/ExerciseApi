#Build Docker Image from dockerfile
build:
	docker build -t mysql_exercise_db .

#Docker create volume
volume:
	docker volume create exercise-volume

#Run Docker
mysql:
	docker run -d -p 3306:3306 mysql_exercise_db

#Compose Docker
docker_compose:
	docker compose up -d --build --force-recreate