# Installing the whole system
## Docker on Raspberry PI 4 with Ubuntu 20.04 LTS x64

## Installing OS
Use Raspberry PI Imager v1.4 to download and install the right image on a SD card.

## Installing docker on PI
For details please refer to following link: https://docs.docker.com/engine/install/ubuntu/

## Installing docker-compose on PI
Execute following commands:

```
sudo apt-get install python3-pip
sudo pip3 install docker-compose
```

See: https://stackoverflow.com/questions/58747879/docker-compose-usr-local-bin-docker-compose-line-1-not-command-not-found


## Create a shared folder with Raspberry PI
You will need a shared folder between your development system (e.g. Windows) and the Rasperry PI OS to be able to exchange files (docker-compose.yaml) between them.

For details see following link: https://www.thomas-krenn.com/de/wiki/Einfache_Samba_Freigabe_unter_Debian

## Installing portainer/portainer-ce

```
docker pull portainer/portainer-ce
```
Start the portainer container with following settings:
```
docker volume create portainer_data
docker run -d -p 8000:8000 -p 9000:9000 --name=portainer --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce
```
After starting the service, you have a graphical UI for maintain docker. Goto url http://{ip address}:9000/.

## Start with the application
To test and learn how to use the MongoDB with C# refer following git repository: https://github.com/histechup/guestlist-manager-cli-csharp

My implementation could be found here: https://github.com/atillakati/guest-list-manager

