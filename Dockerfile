FROM microsoft/dotnet:2.1-sdk AS build

# copy csproj and restore as distinct layers
COPY *.sln .
COPY *.csproj .
COPY *.dcproj .
RUN dotnet restore XBit-Api.sln

# copy everything else and build app
COPY . .
RUN dotnet publish -f netcoreapp2.1 -c Release -o /out XBit-Api.csproj

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR .
COPY --from=build /out .
ENTRYPOINT ["dotnet", "xbitapi.dll"]