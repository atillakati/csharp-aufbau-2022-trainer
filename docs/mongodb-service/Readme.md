![Wifi Campus logo](https://github.com/atillakati/sw_developer_2020_Atilla/blob/main/docs/wifi_campus.PNG)
# Install Docker Desktop on Windows
To install Docker Desktop for Windows follow the steps mentioned here: https://docs.docker.com/docker-for-windows/install/

Befor you can test your installation, you will need to sign in to https://hub.docker.com/. Once you have an dockerhub account you can proceed with follwing steps:

- start docker desktop
- start power shell
- enter 'docker pull hello-world'
Eventually you have to enter your dockerhub credentials.

![Output](https://github.com/atillakati/sw_developer_2020_Atilla/blob/main/docs/mongodb-service/helloWorld.png)

To learn further details about what docker is about and how to use it, I can recomend following tutorial: https://www.youtube.com/watch?v=3c-iBn73dDE

## Installing portainer/portainer-ce
Portainer is a lightweight management UI which allows you to easily manage your Docker AND Kubernetes clusters. Portainer is meant to be as simple to deploy as it is to use. It consists of a single container that can run on any Cluster.
```
docker pull portainer/portainer-ce
```
Start the portainer container with following settings:
```
docker volume create portainer_data
docker run -d -p 8000:8000 -p 9000:9000 --name=portainer --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce
```
After starting the service, you have a graphical UI for maintain docker. Goto url http://{ip address}:9000/.

## Installing mongodb-service
To install and run, you can use the docker-compose file which is included in this folder. Enter following command to download and start mongodb-service:
```
docker-compose -f .\docker-compose.yaml up -d
```

![Docker-Compose Output](https://github.com/atillakati/sw_developer_2020_Atilla/blob/main/docs/mongodb-service/docker-compose_output.png)

After the steps above you can go to portainer and navigate to container page. You will see mongodb and mongodb-express services are up and running:

![portainer](https://github.com/atillakati/sw_developer_2020_Atilla/blob/main/docs/mongodb-service/portainer.png)
