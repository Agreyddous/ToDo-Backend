FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /

COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o Release

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /
COPY --from=build-env /Release .
ENTRYPOINT [ "dotnet", "ToDo.API.dll" ]