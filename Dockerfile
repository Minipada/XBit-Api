FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app
EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.csproj ./
COPY *.dcproj ./
RUN dotnet restore XBit-Api.csproj

# copy everything else and build app
COPY . ./
RUN dotnet publish -f netcoreapp2.1 -c Release -o out XBit-Api.csproj

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "XBit-Api.dll"]
