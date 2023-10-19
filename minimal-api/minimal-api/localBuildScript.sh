# build image
docker build -t dotnet-image-name -f Dockerfile .
# create container (dotnet default on port 80 in container)
docker create -p 8080:8080  --name service-name dotnet-image-name