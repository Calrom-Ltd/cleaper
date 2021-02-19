#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MessageBoardAPI.csproj", "MessageBoardAPI/"]
RUN dotnet restore "MessageBoardAPI/MessageBoardAPI.csproj"
WORKDIR "/src/MessageBoardAPI"
COPY . .
RUN dotnet build "MessageBoardAPI.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "MessageBoardAPI.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessageBoardAPI.dll"]