FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-receiver

#COPY
WORKDIR /app
COPY . .

#Restore
RUN dotnet restore AzurePractice.RequestReceiver.sln

#Build dotnet
WORKDIR /app/AzurePractice.RequestReceiver
RUN dotnet build AzurePractice.RequestReceiver.csproj -c Release --no-restore
#End Build dotnet

#Pulbish
RUN dotnet publish AzurePractice.RequestReceiver.csproj -c Release -o /app/out --no-build --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80

COPY --from=build-receiver /app/out .

ENTRYPOINT ["dotnet", "AzurePractice.RequestReceiver.dll"]
